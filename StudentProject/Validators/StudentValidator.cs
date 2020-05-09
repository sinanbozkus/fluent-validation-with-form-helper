using FluentValidation;
using StudentProject.Models;
using System.Linq;

namespace StudentProject.Validators
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(x => x.StudentName)
            .NotEmpty()
            .Length(4, 50);

            RuleFor(x => x.Email)
            .EmailAddress();

            RuleFor(x => x.StudentNumber)
            .NotEmpty()
            .Length(6, 8)
            .Custom((studentNumber, context) =>
            {
                var arr = new[] { "A", "B", "C" };

                if (!arr.Contains(studentNumber.Substring(0, 1)))
                {
                    context.AddFailure("Öğrenci numarası 'A', 'B' veya 'C' harfi ile başlamalıdır.");
                }
            });

            RuleFor(x => x.Credit)
            .InclusiveBetween(0, 100)
            .GreaterThanOrEqualTo(70).When(x => x.Graduated == true);
        }
    }
}
