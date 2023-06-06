using System.Globalization;
using FluentValidation;
using Microsoft.Extensions.Localization;
using UI.FormEntities.Admin;
using UI.Services;

namespace UI.Validators.Admin
{
    public class SubscriptionValidator : AbstractValidatorExtension<SubscriptionForm>
    {
        private readonly LocalizationService _localizationService;
        private readonly IStringLocalizer<UI.Localizations.Localization> _localization;
        
        public SubscriptionValidator(LocalizationService localizationService, 
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
            
            RuleFor(x => x.DisplayName)
                .NotEmpty().WithMessage(_localization["SubscriptionPage_SubscriptionValidator_RequiredDisplayName"])
                .MinimumLength(8).WithMessage(String.Format(
                    _localization["SubscriptionPage_SubscriptionValidator_InvalidDisplayNameMinimalLength"],
                    8.ToString()))
                .MaximumLength(50).WithMessage(String.Format(
                    _localization["SubscriptionPage_SubscriptionValidator_InvalidDisplayNameMaximalLength"],
                    50.ToString()));

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage(_localization["SubscriptionPage_SubscriptionValidator_RequiredDescription"])
                .MinimumLength(0).WithMessage(String.Format(
                    _localization["SubscriptionPage_SubscriptionValidator_InvalidDescriptionMinimalLength"],
                    0.ToString()))
                .MaximumLength(255).WithMessage(String.Format(
                    _localization["SubscriptionPage_SubscriptionValidator_InvalidDescriptionMaximalLength"],
                    255.ToString()));

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage(_localization["SubscriptionPage_SubscriptionValidator_RequiredPrice"])
                .GreaterThanOrEqualTo(0)
                .WithMessage(_localization["SubscriptionPage_SubscriptionValidator_InvalidMinimalPrice"]);
            
            RuleFor(x => x.TaxOnBooking)
                .NotEmpty().WithMessage(_localization["SubscriptionPage_SubscriptionValidator_RequiredTaxOnBooking"])
                .GreaterThanOrEqualTo(0).WithMessage(_localization["SubscriptionPage_SubscriptionValidator_InvalidMinimalTaxOnBooking"])
                .LessThanOrEqualTo(80).WithMessage(string.Format(
                    _localization["SubscriptionPage_SubscriptionValidator_InvalidMaximalTaxOnBooking"],
                    80.ToString()));
            
            RuleFor(x => x.TaxOnServices)
                .NotEmpty().WithMessage(_localization["SubscriptionPage_SubscriptionValidator_RequiredTaxOnServices"])
                .GreaterThanOrEqualTo(0).WithMessage(_localization["SubscriptionPage_SubscriptionValidator_InvalidMinimaTaxOnServices"])
                .LessThanOrEqualTo(80).WithMessage(string.Format(
                    _localization["SubscriptionPage_SubscriptionValidator_InvalidMaximalTaxOnServices"],
                    80.ToString()));
            
            RuleFor(x => x.MaxHarborAmount)
                .NotEmpty().WithMessage(_localization["SubscriptionPage_SubscriptionValidator_RequiredMaxHarborAmount"])
                .GreaterThanOrEqualTo(0).WithMessage(_localization["SubscriptionPage_SubscriptionValidator_InvalidMinimalMaxHarborAmount"]);
        }
    }
}