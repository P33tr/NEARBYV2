using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace NearXShared.Models
{
    public class ReviewModelFluentValidator : AbstractValidator<Review>
    {
        public ReviewModelFluentValidator()
        {
            RuleFor(x => x.Note)
                .NotEmpty();
            RuleFor(x => x.ElementId)
                .NotNull();
            RuleFor(x => x.UserId)
                .NotNull();
        }
        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<Review>.CreateWithOptions((Review)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
