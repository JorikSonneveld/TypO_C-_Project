using System.ComponentModel.DataAnnotations.Schema;

namespace Typo.Model.Database
{
    public class Student
    {
        [ForeignKey("User")]
        public int ID { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }


        public int TeacherID { get; set; }

        public virtual User User { get; set; }

        [ForeignKey("TeacherID")]
        public virtual Teacher Teacher { get; set; }
    }
}