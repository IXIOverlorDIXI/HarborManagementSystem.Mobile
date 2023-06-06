using System.Globalization;
using FluentValidation;
using Microsoft.Extensions.Localization;
using UI.FormEntities.Harbor;
using UI.Services;

namespace UI.Validators.Harbor
{
    public class HarborValidator : AbstractValidatorExtension<HarborForm>
    {
        private readonly LocalizationService _localizationService;
        private readonly IStringLocalizer<UI.Localizations.Localization> _localization;
        
        public HarborValidator(LocalizationService localizationService, 
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
            
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage(_localization["HarborPage_HarborValidator_RequiredDescription"])
                .MinimumLength(8).WithMessage(String.Format(
                    _localization["HarborPage_HarborValidator_InvalidMinimalDescriptionLength"],
                    8.ToString()))
                .MaximumLength(50).WithMessage(String.Format(
                    _localization["HarborPage_HarborValidator_InvalidMaximalDescriptionLength"],
                    50.ToString()));

            RuleFor(x => x.DisplayName)
                .NotEmpty().WithMessage(_localization["HarborPage_HarborValidator_RequiredDisplayName"])
                .MinimumLength(8).WithMessage(String.Format(
                    _localization["HarborPage_HarborValidator_InvalidMinimalDisplayNameLength"],
                    8.ToString()))
                .MaximumLength(50).WithMessage(String.Format(
                    _localization["HarborPage_HarborValidator_InvalidMaximalDisplayNameLength"],
                    50.ToString()));
            
            RuleFor(x => x.GeolocationLatitude)
                .NotEmpty().WithMessage(_localization["HarborPage_HarborValidator_RequiredGeolocationLatitude"])
                .GreaterThanOrEqualTo(-90).WithMessage(String.Format(
                    _localization["HarborPage_HarborValidator_InvalidMinimalGeolocationLatitude"], (-90).ToString()))
                .LessThanOrEqualTo(90)
                .WithMessage(String.Format(
                    _localization["HarborPage_HarborValidator_InvalidMaximalGeolocationLatitude"], 90.ToString()));
            
            RuleFor(x => x.GeolocationLongitude)
                .NotEmpty().WithMessage(_localization["HarborPage_HarborValidator_RequiredGeolocationLongitude"])
                .GreaterThanOrEqualTo(-180).WithMessage(String.Format(
                    _localization["HarborPage_HarborValidator_InvalidMinimalGeolocationLongitude"], (-180).ToString()))
                .LessThanOrEqualTo(180)
                .WithMessage(String.Format(
                    _localization["HarborPage_HarborValidator_InvalidMaximalGeolocationLongitude"], 180.ToString()));

            RuleFor(x => x.SupportEmail)
                .NotEmpty().WithMessage(_localization["HarborPage_HarborValidator_RequiredSupportEmail"])
                .EmailAddress().WithMessage(_localization["HarborPage_HarborValidator_InvalidFormatSupportEmail"]);
            
            RuleFor(x => x.SupportPhoneNumber)
                .NotEmpty().WithMessage(_localization["HarborPage_HarborValidator_RequiredSupportPhoneNumber"])
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage(
                    _localization["HarborPage_HarborValidator_InvalidFormatSupportPhoneNumber"]);
            
            RuleFor(x => x.BIC)
                .NotEmpty().WithMessage(_localization["HarborPage_HarborValidator_RequiredBIC"])
                .Matches(@"[A-Z]{6,6}[A-Z2-9][A-NP-Z0-9]([A-Z0-9]{3,3}){0,1}").WithMessage(
                    _localization["HarborPage_HarborValidator_InvalidFormatBIC"]);
            
            RuleFor(x => x.IBAN)
                .NotEmpty().WithMessage(_localization["HarborPage_HarborValidator_RequiredIBAN"])
                .Matches(@"^([A-Z]{2}[ \-]?[0-9]{2})(?=(?:[ \-]?[A-Z0-9]){9,30}$)((?:[ \-]?[A-Z0-9]{3,5}){2,7})([ \-]?[A-Z0-9]{1,3})?$")
                .WithMessage(_localization["HarborPage_HarborValidator_InvalidFormatIBAN"]);
        }
    }
}