namespace FluentValidationSample.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string Email { get; set; }
        public string StudentNumber { get; set; }
        public int Credit { get; set; }
        public bool Graduated { get; set; }

        public bool IsNew => Id == default;
    }
}
