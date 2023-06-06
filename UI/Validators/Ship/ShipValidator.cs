using System.Globalization;
using FluentValidation;
using Microsoft.Extensions.Localization;
using UI.FormEntities.Ship;
using UI.Services;

namespace UI.Validators.Ship
{
    public class ShipValidator : AbstractValidatorExtension<ShipForm>
    {
        private readonly LocalizationService _localizationService;
        private readonly IStringLocalizer<UI.Localizations.Localization> _localization;
        
        public ShipValidator(LocalizationService localizationService, 
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
                .NotEmpty().WithMessage(_localization["ShipFormPage_ShipTypeValidator_RequiredDisplayName"])
                .MinimumLength(4).WithMessage(String.Format(
                    _localization["ShipFormPage_ShipTypeValidator_InvalidDisplayNameMinimalLength"],
                    4.ToString()))
                .MaximumLength(50).WithMessage(String.Format(
                    _localization["ShipFormPage_ShipTypeValidator_InvalidDisplayNameMaximalLength"],
                    50.ToString()));

            RuleFor(x => x.ShipTypeId)
                .Must(id => id != Guid.Empty).WithMessage(_localization["ShipFormPage_ShipTypeValidator_RequiredShipType"]);
        }
    }
}