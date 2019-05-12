using FluentValidation;
using FluentValidationSample.Models;
using System.Linq;

namespace FluentValidationSample.Validators
{
    public class StudentViewModelValidator : AbstractValidator<StudentViewModel>
    {
        public StudentViewModelValidator()
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
                        context.AddFailure("Student number must start with 'A', 'B' or 'C'.");
                    }
                });

            RuleFor(x => x.Credit)
                .InclusiveBetween(0, 100)
                .GreaterThanOrEqualTo(70).When(x => x.Graduated == true);
        }
    }
}
