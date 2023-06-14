using FluentValidation;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using WebDemo.Validators;

namespace TodoApp.Models
{
    public class Todo : ITodo
    {
        public string Id { get; set; } = DateTime.UtcNow.ToString("yyyyMMdd-HHMMss");

        //[Required]
        //[StringLength(100)]
        public string Name { get; set; } = "";

        //[Required]
        //[StringLength(100)]
        public string Content { get; set; } = "";

        //[Required]
        public int Priority { get; set; } = 5;

        //[Required]
        //[StringLength(20)]
        public string Status { get; set; } = "Not Started";
        // public bool IsComplete { get; set; }
    }

    /// <summary>
    /// TodoValidator must be registered in the Program class in services
    /// </summary>
    public class TodoValidator : AbstractValidator<Todo>
    {
        public TodoValidator(IEnumerable<Todo> items)
        {
            
            RuleFor(x => x.Name).SetValidator(new UniqueValidator<Todo, string>(items))
                .WithMessage("Name already exists.");
            RuleFor(x => x.Name).NotEmpty()
                .WithMessage("Name must not be empty.");
            RuleFor(x => x.Name).Length(3, 20)
                .WithMessage("Name must not exceed 20 characters.");

            RuleFor(x => x.Content).NotEmpty();
            RuleFor(x => x.Content).NotNull();
            RuleFor(x => x.Content).Length(3, 200)
                .WithMessage("Content must not exceed 200 characters.");

            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Id).SetValidator(new UniqueValidator<Todo, string>(items))
                .WithMessage("Id already exists.");
        }
    }
}