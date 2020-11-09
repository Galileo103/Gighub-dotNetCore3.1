using FluentValidation;
using Gighub.Models.ViewModels;
using System;

namespace Gighub.Validators
{
    public class GigFormViewModelValidator : AbstractValidator<GigFormViewModel>
    {
        public GigFormViewModelValidator()
        {
            RuleFor(c => c.Venue).NotEmpty().MinimumLength(5);
            RuleFor(c => c.Genre).NotEmpty();
            RuleFor(p => p.Date)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Must(BeAValidDate).WithMessage("Invalid date")
                .Must(BeInFuture).WithMessage("Must be in Future");

            RuleFor(p => p.Time)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Must(BeAValidDate).WithMessage("Invalid date");
        }

        private bool BeAValidDate(string value)
        {
            DateTime date;
            return DateTime.TryParse(value, out date);
        }
        private bool BeInFuture(string value)
        {
            DateTime date;
            DateTime.TryParse(value, out date);
            return date > DateTime.Now;
        }
    }
}
