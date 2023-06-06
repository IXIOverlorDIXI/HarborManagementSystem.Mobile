using System.Globalization;
using FluentValidation;
using Microsoft.Extensions.Localization;
using UI.FormEntities.Booking;
using UI.Services;

namespace UI.Validators.Booking
{
    public class BookingValidator : AbstractValidatorExtension<BookingForm>
    {
        private readonly LocalizationService _localizationService;
        private readonly IStringLocalizer<UI.Localizations.Localization> _localization;
        
        public BookingValidator(LocalizationService localizationService, 
            IStringLocalizer<UI.Localizations.Localization> localization)
        {
            _localizationService = localizationService;
            _localization = localization;

            var culture = _localizationService.GetCulture();
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            
            _localizationService.CultureChanged += UpdateRules;
            UpdateRules();
        }

        private void UpdateRules()
        {
            var culture = _localizationService.GetCulture();
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            
            RuleFor(x => x.BerthId)
                .Must(x => !x.Equals(Guid.Empty))
                .WithMessage(_localization["BookingFormPage_BookingValidator_RequiredBerth"]);
            
            RuleFor(x => x.HarborId)
                .Must(x => !x.Equals(Guid.Empty))
                .WithMessage(_localization["BookingFormPage_BookingValidator_RequiredHarbor"]);

            RuleFor(x => x.ShipId)
                .Must(x => !x.Equals(Guid.Empty))
                .WithMessage(_localization["BookingFormPage_BookingValidator_RequiredShip"]);

            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage(_localization["BookingFormPage_BookingValidator_RequiredEndDate"])
                .Must(x => x > DateTime.Now)
                .WithMessage(_localization["BookingFormPage_BookingValidator_InvalidEndDateByDateNow"])
                .Must((model, x) => !model.StartDate.HasValue || model.StartDate == DateTime.MinValue || x > model.StartDate)
                .WithMessage(_localization["BookingFormPage_BookingValidator_InvalidEndDateByStartDate"]);

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage(_localization["BookingFormPage_BookingValidator_RequiredStartDate"])
                .Must(x => x > DateTime.Now)
                .WithMessage(_localization["BookingFormPage_BookingValidator_InvalidStartDateByDateNow"])
                .Must((model, x) => !model.EndDate.HasValue || model.EndDate == DateTime.MinValue || x < model.EndDate)
                .WithMessage(_localization["BookingFormPage_BookingValidator_InvalidStartDateByEndDate"]);
        }
    }
}