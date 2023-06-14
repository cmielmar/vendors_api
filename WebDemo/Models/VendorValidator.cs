using FluentValidation;

namespace TodoApp.Models
{
    /// <summary>
    /// TodoValidator must be registered in the Program class in services
    /// </summary>
    public class VendorValidator : AbstractValidator<Vendor>
    {
        // public VendorValidator(IEnumerable<Vendor> items)
        public VendorValidator()
        {

            //RuleFor(x => x.FirstName).NotEmpty()
            //    .WithMessage("Name must not be empty.");
            //RuleFor(x => x.FirstName).Length(3, 20)
            //    .WithMessage("Name must be betweet 3 and 20 characters long.");
            //RuleFor(x => x.LastName).Length(3, 20)
            //    .WithMessage("Name must be betweet 3 and 20 characters long.");

            //RuleFor(x => x.Content).NotEmpty();
            //RuleFor(x => x.Content).NotNull();
            //RuleFor(x => x.Content).Length(3, 200)
            //    .WithMessage("Content must not exceed 200 characters.");

            //RuleFor(x => x.Id).NotNull();
            //RuleFor(x => x.Id).SetValidator(new UniqueValidator<Todo, string>(items))
            //    .WithMessage("Id already exists.");
        }
    }
}