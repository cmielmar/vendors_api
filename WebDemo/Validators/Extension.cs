using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebDemo.Validators
{
    public static class Extension
    {
        //public static IRuleBuilderOptions<TItem, TProperty> IsUnique<TItem, TProperty>(
        //    this IRuleBuilder<TItem, TProperty> ruleBuilder, IEnumerable<TItem> items)
        //    where TItem : class
        //{
        //    return ruleBuilder.SetValidator(new UniqueValidator<TItem>(items));
        //}
    }

    public static class Extensions
    {
        public static void AddToModelState(this ValidationResult result, ModelStateDictionary modelState)
        {
            foreach (var error in result.Errors)
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }
    }
}