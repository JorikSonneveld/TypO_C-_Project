using System;
using System.Collections.Generic;
using System.Linq;
using Typo.Model;
using Typo.Model.Database;

namespace Typo.Controller
{
    public class DatabaseController
    {
        //Initialize a new DatabaseContext
        public ApplicationDatabase ApplicationDatabase = new ApplicationDatabase();

        //Save database
        private void SaveDb()
        {
            ApplicationDatabase.SaveChanges();
        }

        //Add mistakes to database
        public void AddMistakesToDb(List<string> mistakes)
        {
            foreach (var character in mistakes) //goes through every mistake made in the exercise 
            {
                var selection =
                    ApplicationDatabase.KeyMistakes.FirstOrDefault(keyMistake =>
                        keyMistake.Character == character+""); //gets the mistake with the same letter from the database
                if (selection != null) //checks is the mistake is already 
                    selection.Count++; //adds one to the count
                else
                    ApplicationDatabase.KeyMistakes.Add(new KeyMistake
                    {
                        Character = character.ToString(),
                        Count = 1
                    }); //adds the new mistake to the database

                SaveDb(); //saves the database after every letter
            }
        }

        //Add course to database
        public bool AddCourse(Course course)
        {
            if (ApplicationDatabase.Courses.Any(c => c.Title.Equals(course.Title)) || course.Text == string.Empty)
                return false;

            ApplicationDatabase.Courses.Add(course);
            SaveDb();
            return true;
        }

        //Delete course from Courses database table
        public void DeleteCourse(int courseid)
        {
            if (!ApplicationDatabase.Courses.Any(x => x.CourseID == courseid)) // check if it is in the db
                return;
            var course = ApplicationDatabase.Courses.Single(x => x.CourseID == courseid); // get the courses from the db
            ApplicationDatabase.Courses.Remove(course); // remove the course with the given id
            SaveDb();
        }

        //Retrieve most mistaken chars
        public List<string> RetrieveCommonMistakes(int mistakesAmount)
        {     
            //Check which char is often mistaken
            var mistakes = (from m in ApplicationDatabase.KeyMistakes
                           orderby m.Count descending
                           select m.Character).Take(mistakesAmount);
            //Add to list
            return mistakes.ToList();
        }

        //Return list of words most mistaken chars
        public List<Word> GenerateWords(int wordsAmount, int mistakesAmount)
        {
            var mistakeList = RetrieveCommonMistakes(mistakesAmount); // gets the most common mistakes

            //Get words that contain common mistaken char order by random
            var wordList = RetrieveRandomDbWords();

            var words = mistakeList.SelectMany(character =>
                    from w in wordList
                    where w.Characters.Contains(character)
                    orderby Guid.NewGuid()
                    select w).Take(wordsAmount); // select all the words wich have the most common mistakes in them

            return words.ToList();
        }

        //Function to edit existing course
        public bool EditCourse(Course course)
        {
            // check if the given title is the same and the Id does not or if the given text is empty
            if (ApplicationDatabase.Courses.Any(c => c.Title.Equals(course.Title) && c.CourseID != course.CourseID) ||
                course.Text == string.Empty)
                return false;

            // get the course with the given Id
            var selection = ApplicationDatabase.Courses.FirstOrDefault(c => c.CourseID == course.CourseID);
            if (selection == null) return false;

            //Set values
            selection.Title = course.Title;
            selection.Text = course.Text;
            selection.Official = course.Official;
            selection.StartDate = course.StartDate;
            selection.EndDate = course.EndDate;
            SaveDb();
            return true;
        }

        //Function to retrieve random words from the database
        public List<Word> RetrieveRandomDbWords()
        {
            var wordsList = new List<Word>();

            // Get words and add to db
            var words = ApplicationDatabase.Words.OrderBy(w => Guid.NewGuid()).Take(15);

            foreach (var word in words)
                wordsList.Add(word);
            return wordsList;
        }

        //Retrieve amount of random words from database
        public List<Word> RetrieveRandomDbWords(int numWords)
        {
            var wordsList = new List<Word>();

            // Get words and add to db
            var words = ApplicationDatabase.Words.OrderBy(w => Guid.NewGuid()).Take(numWords);

            foreach (var word in words)
                wordsList.Add(word);
            return wordsList;
        }

        //Function to retrieve all Courses from the database
        public List<Course> RetrieveAllDbCourses()
        {
            var courses = new List<Course>();

            //Linq query to select all courses from the database
            var selection = (from c in ApplicationDatabase.Courses select c).ToList();

            return selection;
        }

        //Compare courseID with result CourseID
        public bool CheckCourseWithStudent(Course course, Result result)
        {
            return course.CourseID == result.CourseID;
        }

        //Retrieve course that is currently available
        public Course RetrieveCourseCurrentlyAvailable(int userID)
        {
            List<Course> courses;
            List<Result> resultsPerStudent;
            courses = RetrieveAllDbCourses(); // add all the courses to a list
            resultsPerStudent = GetResultsPerStudent(userID).ToList();
            var currentTime = DateTime.Now; // get the current time
            var IsSameCourse = false;

            foreach (var course in courses)
            {
                foreach (var result in resultsPerStudent)
                    if (CheckCourseWithStudent(course, result))
                        IsSameCourse = true;
                if (course.StartDate <= currentTime && course.EndDate >= currentTime && course.Official &&
                    IsSameCourse == false
                ) // check for every course if the current time is in between the start and endtime of the course
                    return course;
                IsSameCourse = false;
            }
            return null; // if there are no courses in the timespan return null so that there will be no dialog
        }

        //Retrieve all words from database
        public List<Word> RetrieveAllWords()
        {
            return ApplicationDatabase.Words.ToList();
        }

        //crud queries voor StudentOverview
        //create new student account
        public void CreateStudent(string Username, string Surname, string Password, string Type, int TeacherId)
        {
            User user = new User
            {
                Username = Username,
                Password = LoginController.Hash(Password),
                Type = Type,
                Student = new Student
                {
                    Name = Username,
                    Surname = Surname,
                    TeacherID = TeacherId
                }
            };
            ApplicationDatabase.Users.Add(user);
            SaveDb();
        }

        //Edit student account without password
        public void EditStudent(string Username, string Surname, int StudentID) {
            Student student = GetStudentByID(StudentID);
            student.Name = Username;
            student.User.Username = Username;
            student.Surname = Surname;
            SaveDb();
        }

        //Edit student account with password
        public void EditStudent(string Username, string Surname, string Password, int StudentID)
        {
            Student student = GetStudentByID(StudentID);
            student.User.Password = LoginController.Hash(Password);
            EditStudent(Username, Surname, StudentID);
        }

        //delete student account
        public void DeleteStudent(int StudentID)
        {
            Student student = GetStudentByID(StudentID);
            ApplicationDatabase.Students.Remove(student);
            User selection = GetUserByID(StudentID);
            ApplicationDatabase.Users.Remove(selection);
            SaveDb();
        }

        //Retrieve user by userID
        public User GetUserByID(int UserID)
        {
            User selection = ApplicationDatabase.Users.Single(x => x.ID == UserID);
            return selection;
        }

        //Add users and courses if database is empty
        public void FillDatabase()
        {
            FillDatabaseWords();

            ApplicationDatabase.Users.Add(new User
            {
                Username = "Frens",
                Password = LoginController.Hash("Buning"),
                Type = "Student",
                Student = new Student
                {
                    Name = "Frens",
                    Surname = "Buning"
                }
            });

            ApplicationDatabase.Users.Add(new User
            {
                Username = "Admin",
                Password = LoginController.Hash("Admin"),
                Type = "Teacher",
                Teacher = new Teacher
                {
                    Name = "Thomas",
                    Surname = "Boose"
                }
            });

            ApplicationDatabase.Courses.Add(new Course
            {
                CourseID = 1,
                Title = "Titel",
                Text = "Dit is tekst",
                StartDate = new DateTime(2010, 8, 18),
                EndDate = new DateTime(2017, 12, 20),
                Official = true
            });
            SaveDb();
        }

        //Fill database with 1000 most used Dutch words
        public void FillDatabaseWords()
        {
            //Initialize a list of words to insert into the database
            Console.WriteLine("Check if first run of database, this can take a while...");
            var wordsString = "aan, aanbod, aanraken, aanval, aap, aardappel, aarde, aardig, acht, achter, actief, activiteit, ademen, af, afgelopen, afhangen, afmaken, afname, afspraak, afval, al, algemeen, alleen, alles, als, alsjeblieft, altijd, ander, andere, anders, angst, antwoord, antwoorden, appel, arm, auto, avond, avondeten, baan, baby, bad, bal, bang, bank, basis, bed, bedekken, bedreiging, bedreven, been, beer, beest, beetje, begin, begrijpen, begrip, behalve, beide, beker, bel, belangrijk, bellen, belofte, beneden, benzine, berg, beroemd, beroep, bescherm, beslissen, best, betalen, beter, bevatten, bewegen, bewolkt, bezoek, bibliotheek, bieden, bij, bijna, bijten, bijvoorbeeld, bijzonder, binnen, binnenkort, blad, blauw, blazen, blij, blijven, bloed, bloem, bodem, boek, boerderij, boete, boom, boon, boord, boos, bord, borstelen, bos, bot, bouwen, boven, branden, brandstof, breed, breken, brengen, brief, broer, broek, brood, brug, bruikbaar, bruiloft, bruin, bui, buiten, bureau, buren, bus, buurman, buurvrouw, cadeau, chocolade, cirkel, comfortabel, compleet, computer, conditie, controle, cool, correct, daar, daarom, dag, dak, dan, dansen, dapper, dat, de, deel, deken, deksel, delen, derde, deze, dichtbij, dienen, diep, dier, dik, ding, dit, dochter, doen, dom, donker, dood, door, doorzichtig, doos, dorp, draad, draaien, dragen, drie, drijven, drinken, drogen, dromen, droog, druk, dubbel, dun, dus, duur, duwen, echt, een, eend, eenheid, eenzaam, eerste, eeuw, effect, ei, eigen, eiland, einde, eis, elektrisch, elk, en, enkele, enthousiast, erg, eten, even, examen, extreem, falen, familie, feest, feit, fel, fijn, film, fit, fles, foto, fout, fris, fruit, gaan, gat, gebeuren, gebeurtenis, gebied, geboorte, geboren, gebruik, gebruikelijk, gebruiken, gedrag, gedragen, geel, geen, gehoorzamen, geit, geld, geliefde, gelijk, geloof, geluid, geluk, gemak, gemakkelijk, gemeen, genieten, genoeg, genot, gerecht, gereedschap, geschikt, gespannen, geur, gevaar, gevaarlijk, gevangenis, geven, gevolg, gewicht, gewoon, gezicht, gezond, gif, gisteren, glad, glas, glimlach, god, goed, goedkoop, goud, graf, grap, grappig, gras, grens, grijs, groeien, groen, groente, groep, grof, grond, groot, grootmoeder, grootvader, haan, haar, haast, hal, halen, half, hallo, hamer, hand, hard, hart, haten, hebben, heel, heet, helder, helft, help, hem, hemel, hen, herfst, herinneren, hert, het, heuvel, hier, hij, hobby, hoe, hoed, hoek, hoeveel, hoeveelheid, hoewel, hond, honderd, honger, hoofd, hoog, hoogte, hoop, horen, hotel, houden, huilen, huis, hun, huren, hut, huur, idee, ieder, iedereen, iemand, iets, ijs, ijzer, ik, instrument, ja, jaar, jagen, jas, jij, jong, jongen, jouw, jullie, kaars, kaart, kaas, kamer, kans, kant, kantoor, kap, kast, kasteel, kat, kennen, kennis, keuken, keus, kiezen, kijken, kind, kip, kist, klaar, klas, klasse, kleden, klein, kleren, kleur, klimmen, klok, kloppen, klopt, knie, knippen, koers, koffer, koffie, kok, koken, kom, komen, koning, koningin, koorts, kop, kopen, kort, kost, kosten, koud, kraam, kracht, krant, krijgen, kruis, kuil, kunnen, kunst, kurk, laag, laat, laatst, lach, lachen, ladder, laken, lamp, land, lang, langs, langzaam, laten, leeftijd, leeg, leerling, leeuw, leger, leiden, lenen, lengte, lepel, leren, les, leuk, leven, lezen, lichaam, licht, liefde, liegen, liggen, lijk, lijken, liniaal, links, lip, list, lomp, lood, lopen, los, lot, lucht, lui, luisteren, lunch, maag, maal, maaltijd, maan, maand, maar, maat, machine, maken, makkelijk, mama, man, mand, manier, map, markeren, markt, me, medicijn, meel, meer, meerdere, meest, meisje, melk, meneer, mengsel, mensen, mes, met, meubel, mevrouw, middel, midden, mij, mijn, miljoen, min, minder, minuut, mis, missen, mits, model, modern, moeder, moeilijk, moeten, mogelijk, mogen, moment, mond, mooi, moord, moorden, morgen, munt, muziek, na, naald, naam, naar, naast, nacht, nat, natuur, natuurlijk, nee, neer, negen, nek, nemen, net, netjes, neus, niet, niets, nieuw, nieuws, nobel, noch, nodig, noemen, nog, nood, nooit, noord, noot, normaal, nu, nul, nummer, oceaan, ochtend, oefening, of, offer, olie, olifant, om, oma, onder, onderwerp, onderzoek, oneven, ongeluk, ons, ontsnappen, ontbijt, ontdekken, ontmoeten, ontvangen, ontwikkelen, onze, oog, ooit, ook, oom, oor, oorlog, oorzaak, oost, op, opa, opeens, open, openlijk, opleiding, opnemen, oranje, orde, oud, ouder, over, overal, overeenkomen, overleden, overvallen, paar, paard, pad, pagina, pan, papa, papier, park, partner, pas, passeren, pen, peper, per, perfect, periode, persoon, piano, pijn, pistool, plaat, plaatje, plaats, plafond, plank, plant, plastic, plat, plattegrond, plein, plus, poes, politie, poort, populair, positie, postzegel, potlood, praten, presenteren, prijs, prins, prinses, proberen, probleem, product, provincie, publiek, punt, raak, raam, radio, raken, rapport, recht, rechtdoor, rechts, rechtvaardig, redden, reeds, regen, reiken, reizen, rekenmachine, rennen, repareren, rest, restaurant, resultaat, richting, rijk, rijst, rijzen, ring, rok, rond, rood, rook, rots, roze, rubber, ruiken, ruimte, samen, sap, schaap, schaar, schaduw, scheiden, scherp, schetsen, schieten, schijnen, schip, school, schoon, schouder, schreeuw, schreeuwen, schrijven, schudden, seconde, signaal, simpel, sinds, slaapkamer, slapen, slecht, sleutel, slim, slot, sluiten, smaak, smal, sneeuw, snel, snelheid, snijden, soep, sok, soms, soort, sorry, speciaal, spel, spelen, sport, spreken, springen, staal, stad, stap, start, station, steen, stelen, stem, stempel, ster, sterk, steun, stil, stilte, stoel, stof, stoffig, stom, stop, storm, straat, straffen, structuur, student, studie, stuk, succes, suiker, taal, taart, tafel, tak, tamelijk, tand, tante, tas, taxi, te, team, teen, tegen, teken, tekenen, telefoon, televisie, tellen, tennis, terug, terugkomst, terwijl, test, tevreden, thee, thuis, tien, tijd, titel, toekomst, toen, toename, totaal, traan, tram, trein, trekken, trouwen, trui, tuin, tussen, tweede, uit, uitleggen, uitnodigen, uitvinden, uitzoeken, uur, vaak, vaarwel, vader, vak, vakantie, vallen, vals, van, vandaag, vangen, vanmorgen, vannacht, varken, vast, vechten, veel, veer, veilig, ver, veranderen, verandering, verder, verdienen, verdrietig, verenigen, verf, vergelijkbaar, vergelijken, vergelijking, vergeten, vergeven, vergissen, verhaal, verhoging, verjaardag, verkeerd, verkopen, verlaten, verleden, verliezen, vernietigen, veroveren, verrassen, vers, verschil, verschrikkelijk, verspreiden, verstand, verstoppen, versturen, vertellen, vertrekken, vertrouwen, verwachten, verwijderen, verzamelen, verzameling, vet, vier, vierkant, vies, vijand, vijf, vijver, vinden, vinger, vis, vlag, vlees, vlieg, vliegtuig, vloer, voeden, voedsel, voelen, voet, voetbal, vogel, vol, volgende, volgorde, voor, voorbeeld, voorkomen, voorzichtig, voorzien, vork, vorm, vos, vouwen, vraag, vragen, vrede, vreemd, vreemde, vriend, vriendelijk, vriezen, vrij, vrijheid, vroeg, vroeger, vrouw, vullen, vuur, waar, waarom, waarschijnlijk, wachten, wakker, wanneer, want, wapen, warm, wassen, wat, water, we, week, weer, weg, welke, welkom, wens, wereld, werelddeel, werk, west, wetenschap, wie, wiel, wij, wijn, wijs, wild, willen, wind, winkel, winnen, winter, wissen, wit, wolf, wolk, wonder, woord, woud, wreed, zaak, zacht, zak, zand, zee, zeep, zeer, zeggen, zeil, zeker, zelfde, zes, zetten, zeven, ziek, ziekenhuis, ziel, zien, zij, zijn, zilver, zingen, zinken, zitten, zo, zoals, zoeken, zoet, zomer, zon, zonder, zonnig, zoon, zorg, zorgen, zou, zout, zuid, zulke, zullen, zus, zwaar, zwak, zwembad, zwemmen";
            var words = wordsString.Split(new[] { ", " }, StringSplitOptions.None).ToArray();
            var wordList = words.Select(word => new Word { Characters = word }).ToList();

            //Loop over each word in the wordlist to check if the word already exsists in the database
            foreach (var word in wordList)
                if (!ApplicationDatabase.Words.Any(w => w.Characters == word.Characters))
                    ApplicationDatabase.Words.Add(word);

            //Save the changes
            SaveDb();
            Console.WriteLine("Database Saved");
        }

        //Save exercise result to database
        public void SaveResult(int studentID, int keyScore, int accScore, string title)
        {
            SaveResult(studentID, keyScore, accScore, title, -1);
            SaveDb();
        }

        //Save course result to database
        public void SaveResult(int studentID, int keyScore, int accScore, string title, int courseID)
        {
            //if (!ApplicationDatabase.Results.Any(w => w.Title == title))
            if (courseID == -1)
                ApplicationDatabase.Results.Add(new Result
                {
                    AccScore = accScore,
                    CourseID = null,
                    KeyScore = keyScore,
                    StudentID = studentID
                });
            else
                ApplicationDatabase.Results.Add(new Result
                {
                    AccScore = accScore,
                    CourseID = courseID,
                    KeyScore = keyScore,
                    StudentID = studentID
                });
            SaveDb();
        }

        //Get a list of all students
        public List<Student> GetAllStudents()
        {
            return ApplicationDatabase.Students.ToList();
        }

        //Get student object by studentID
        public Student GetStudentByID(int ID)
        {
            return ApplicationDatabase.Students.Single(id => id.ID == ID);
        }

        //Get results of student by studentID
        public IEnumerable<Result> GetResultsPerStudent(int StudentID)
        {
            return ApplicationDatabase.Results.Where(x => x.StudentID == StudentID);
        }

        //Check entered login credentials
        public User CheckLogin(string Username, string Password)
        {
            //create logged in user
            var user = ApplicationDatabase.Users.FirstOrDefault(x => x.Username.Equals(Username, StringComparison.Ordinal) && x.Password.Equals(Password, StringComparison.Ordinal));
            return user;
        }

        //Retrieve all exercises
        public List<Course> RetrieveNonOfficialCourses()
        {
            return RetrieveAllDbCourses().Where(c => c.Official == false).Select(c => c)
                .ToList(); // select only the non-official courses
        }

        //Calculate average accuracy
        public int GetAverageAccuracy(int ID)
        {
            var results = GetResultsPerStudent(ID).ToList(); // gets all the results
            var avg = 0;

            if (results != null && results.Count != 0)
            {
                foreach (Result result in results) //go through all the results
                    avg += result.AccScore; // add all the results

                return avg / results.Count; // and devide them by the number of results
            }
            else
                return 0;
        }

        //Calculate average accuracy per minute
        public int GetAverageKeysPerMinute(int ID)
        {
            int avg = 0;
            var results = GetResultsPerStudent(ID).ToList(); // gets all the results

            if (results != null && results.Count != 0)
            {
                foreach (Result result in results) //go through all the results
                    avg += result.KeyScore; // add all the results

                return avg / results.Count; // and devide them by the number of results
            }
            else
                return 0;
        }

        //Get the amount of results of student
        public int GetResultCount(int ID, bool IsExercise)
        {
            int count;
            if (IsExercise) // if you want the count of all the exercises
                count = ApplicationDatabase.Results.Count(r => r.CourseID == 0 || r.CourseID == null);
            else // if you want the count of all the courses
                count = ApplicationDatabase.Results.Count(r => r.CourseID != 0 && r.CourseID != null);
            return count;
        }

        public List<object> CreateResultBindings(Student student)
        {
            var Bindings = new List<object>
            {
                student,
                GetAverageAccuracy(student.ID) + "%",
                GetAverageKeysPerMinute(student.ID),
                GetResultCount(student.ID, false),
                GetResultCount(student.ID, true)
            }; // make a list for all the diffetent bindings
            return Bindings;
        }
    }
}