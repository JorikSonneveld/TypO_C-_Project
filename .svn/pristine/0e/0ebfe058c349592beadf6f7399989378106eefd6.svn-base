using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Typo.Model.Database
{
    public class Result
    {
        [Key]
        public int ResultId { get; set; }

        public int StudentID { get; set; }
        public int? CourseID { get; set; }
        public int KeyScore { get; set; }
        public int AccScore { get; set; }

        [ForeignKey("CourseID")]
        public virtual Course Course { get; set; }

        [ForeignKey("StudentID")]
        public virtual Student Student { get; set; }
    }
}