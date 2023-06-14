using FluentValidation;
using FluentValidation.Validators;
using System.Reflection;

namespace WebDemo.Validators
{

        /// <summary>
        /// These are just helpers so that we can create TodoValidator - no need to register
        /// </summary>
        /// <typeparam name="T"></typeparam>
    public class UniqueValidator<T, TProp> : PropertyValidator<T, TProp>
    {
        private readonly IEnumerable<T> _items;

        public UniqueValidator(IEnumerable<T> items)
          : base()
        {
            _items = items;
        }

        public override string Name => "UniqueValidator";

        public override bool IsValid(ValidationContext<T> context, TProp prop)
        {

            var editedItem = context.InstanceToValidate;
            var newValue = prop as string;
            var property = typeof(T).GetTypeInfo().GetDeclaredProperty(context.PropertyName);
            return _items.All(item => item.Equals(editedItem) || property.GetValue(item).ToString() != newValue);
        }
    }
}
