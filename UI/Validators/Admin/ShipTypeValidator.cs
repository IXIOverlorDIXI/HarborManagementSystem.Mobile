using System.Globalization;
using FluentValidation;
using Microsoft.Extensions.Localization;
using UI.FormEntities.Admin;
using UI.Services;

namespace UI.Validators.Admin
{
    public class ShipTypeValidator : AbstractValidatorExtension<ShipTypeForm>
    {
        private readonly LocalizationService _localizationService;
        private readonly IStringLocalizer<UI.Localizations.Localization> _localization;
        
        public ShipTypeValidator(LocalizationService localizationService, 
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
            
            RuleFor(x => x.TypeName)
                .NotEmpty().WithMessage(_localization["ShipTypesManagePage_ShipTypeValidator_RequiredTypeName"])
                .MinimumLength(8).WithMessage(String.Format(
                    _localization["ShipTypesManagePage_ShipTypeValidator_InvalidTypeNameMinimalLength"],
                    8.ToString()))
                .MaximumLength(50).WithMessage(String.Format(
                    _localization["ShipTypesManagePage_ShipTypeValidator_InvalidTypeNameMaximalLength"],
                    50.ToString()));

            RuleFor(x => x.Description)
                .MinimumLength(0).WithMessage(String.Format(
                    _localization["ShipTypesManagePage_ShipTypeValidator_InvalidDescriptionMinimalLength"],
                    0.ToString()))
                .MaximumLength(255).WithMessage(String.Format(
                    _localization["ShipTypesManagePage_ShipTypeValidator_InvalidDescriptionMaximalLength"],
                    255.ToString()));
        }
    }
}