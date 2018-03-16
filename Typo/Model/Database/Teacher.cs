using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Typo.Model.Database
{
    public class Teacher
    {
        [ForeignKey("User")]
        public int ID { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }


        public virtual User User { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}