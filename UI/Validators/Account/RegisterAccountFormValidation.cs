using System.Globalization;
using FluentValidation;
using Microsoft.Extensions.Localization;
using UI.FormEntities.Account;
using UI.Services;

namespace UI.Validators.Account
{
    public class RegisterAccountFormValidation : AbstractValidatorExtension<RegisterAccountForm>
    {
        private readonly LocalizationService _localizationService;
        private readonly IStringLocalizer<UI.Localizations.Localization> _localization;
        
        public RegisterAccountFormValidation(LocalizationService localizationService, 
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
            
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage(_localization["AuthorizationPage_RegisterTab_RegisterValidator_RequiredUsername"])
                .MinimumLength(8).WithMessage(String.Format(
                    _localization["AuthorizationPage_RegisterTab_RegisterValidator_InvalidUsernameMinimalLength"],
                    8.ToString()))
                .MaximumLength(36).WithMessage(String.Format(
                    _localization["AuthorizationPage_RegisterTab_RegisterValidator_InvalidUsernameMaximalLength"],
                    36.ToString()));

            RuleFor(x => x.DisplayName)
                .NotEmpty().WithMessage(_localization["AuthorizationPage_RegisterTab_RegisterValidator_RequiredDisplayName"])
                .MinimumLength(8).WithMessage(String.Format(
                    _localization["AuthorizationPage_RegisterTab_RegisterValidator_InvalidDisplayNameMinimalLength"],
                    8.ToString()))
                .MaximumLength(36).WithMessage(String.Format(
                    _localization["AuthorizationPage_RegisterTab_RegisterValidator_InvalidDisplayNameMaximalLength"],
                    36.ToString()));

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(_localization["AuthorizationPage_RegisterTab_RegisterValidator_RequiredEmail"])
                .EmailAddress().WithMessage(_localization["AuthorizationPage_RegisterTab_RegisterValidator_InvalidEmailFormat"]);

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(_localization["AuthorizationPage_RegisterTab_RegisterValidator_RequiredPassword"])
                .MinimumLength(8).WithMessage(String.Format(
                    _localization["AuthorizationPage_RegisterTab_RegisterValidator_InvalidPasswordMinimalLength"],
                    8.ToString()))
                .MaximumLength(36).WithMessage(String.Format(
                    _localization["AuthorizationPage_RegisterTab_RegisterValidator_InvalidPasswordMaximalLength"],
                    36.ToString()));

            RuleFor(x => x.PasswordConfirm)
                .NotEmpty().WithMessage(_localization["AuthorizationPage_RegisterTab_RegisterValidator_RequiredPasswordConfirm"])
                .Equal(x => x.Password).WithMessage(_localization["AuthorizationPage_RegisterTab_RegisterValidator_EqualPasswordConfirm"]);
        }
    }
}