using System.Globalization;
using FluentValidation;
using Microsoft.Extensions.Localization;
using UI.FormEntities.Account;
using UI.Services;

namespace UI.Validators.Account
{
    public class LoginAccountFormValidation : AbstractValidatorExtension<LoginAccountForm>
    {
        private readonly LocalizationService _localizationService;
        private readonly IStringLocalizer<UI.Localizations.Localization> _localization;
        
        public LoginAccountFormValidation(LocalizationService localizationService, 
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
            
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(_localization["AuthorizationPage_LoginTab_LoginValidator_RequiredEmail"])
                .EmailAddress().WithMessage(_localization["AuthorizationPage_LoginTab_LoginValidator_InvalidEmailFormat"]);

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(_localization["AuthorizationPage_LoginTab_LoginValidator_RequiredPassword"])
                .MinimumLength(8).WithMessage(string.Format(
                    _localization["AuthorizationPage_LoginTab_LoginValidator_InvalidPasswordMinimalLength"],
                    8.ToString()))
                .MaximumLength(36).WithMessage(string.Format(
                    _localization["AuthorizationPage_LoginTab_LoginValidator_InvalidPasswordMaximalLength"],
                    36.ToString()));
        }
    }
}