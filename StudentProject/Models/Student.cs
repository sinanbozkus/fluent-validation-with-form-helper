using System.ComponentModel.DataAnnotations;

namespace StudentProject.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Display(Name = "Student Name")]
        public string StudentName { get; set; }
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Display(Name = "Student Number")]
        public string StudentNumber { get; set; }
        [Display(Name = "Credit")]
        public int Credit { get; set; }
        [Display(Name = "Graduation Status")]
        public bool Graduated { get; set; }

        public bool IsNew => Id == default;
    }
}
