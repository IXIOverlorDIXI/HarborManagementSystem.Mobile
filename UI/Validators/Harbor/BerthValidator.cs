using System.Globalization;
using FluentValidation;
using Microsoft.Extensions.Localization;
using UI.FormEntities.Harbor;
using UI.Services;

namespace UI.Validators.Harbor
{
    public class BerthValidator : AbstractValidatorExtension<BerthForm>
    {
        private readonly LocalizationService _localizationService;
        private readonly IStringLocalizer<UI.Localizations.Localization> _localization;
        
        public BerthValidator(LocalizationService localizationService, 
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
                .NotEmpty().WithMessage(_localization["HarborPage_BerthValidator_RequiredDescription"])
                .MinimumLength(8).WithMessage(String.Format(
                    _localization["HarborPage_BerthValidator_InvalidMinimalDescriptionLength"],
                    8.ToString()))
                .MaximumLength(50).WithMessage(String.Format(
                    _localization["HarborPage_BerthValidator_InvalidMaximalDescriptionLength"],
                    50.ToString()));

            RuleFor(x => x.DisplayName)
                .NotEmpty().WithMessage(_localization["HarborPage_BerthValidator_RequiredDisplayName"])
                .MinimumLength(8).WithMessage(String.Format(
                    _localization["HarborPage_BerthValidator_InvalidMinimalDisplayNameLength"],
                    8.ToString()))
                .MaximumLength(50).WithMessage(String.Format(
                    _localization["HarborPage_BerthValidator_InvalidMaximalDisplayNameLength"],
                    50.ToString()));
            
            RuleFor(x => x.Price)
                .NotEmpty().WithMessage(_localization["HarborPage_BerthValidator_RequiredPrice"])
                .GreaterThanOrEqualTo(0).WithMessage(String.Format(
                    _localization["HarborPage_BerthValidator_InvalidMinimalPrice"], 0.ToString()))
                .LessThanOrEqualTo(1999999.99)
                .WithMessage(String.Format(
                    _localization["HarborPage_BerthValidator_InvalidMaximalPrice"], 1999999.99.ToString()));

            RuleFor(x => x.SuitableShipTypes)
                .Must(x => x.Any()).WithMessage(_localization["HarborPage_BerthValidator_RequiredShipTypes"]);
        }
    }
}