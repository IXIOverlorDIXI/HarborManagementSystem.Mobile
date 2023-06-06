using System.Globalization;
using FluentValidation;
using Microsoft.Extensions.Localization;
using UI.FormEntities.Account;
using UI.Services;

namespace UI.Validators.Account
{
    public class ChangePasswordFormValidation : AbstractValidatorExtension<ChangePasswordForm>
    {
        private readonly LocalizationService _localizationService;
        private readonly IStringLocalizer<UI.Localizations.Localization> _localization;
        
        public ChangePasswordFormValidation(LocalizationService localizationService, 
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
            
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(_localization["ProfilePage_ChangePasswordTab_ChangePasswordValidator_RequiredPassword"])
                .MinimumLength(8).WithMessage(String.Format(
                    _localization["ProfilePage_ChangePasswordTab_ChangePasswordValidator_InvalidPasswordMinimalLength"],
                    8.ToString()))
                .MaximumLength(36).WithMessage(String.Format(
                    _localization["ProfilePage_ChangePasswordTab_ChangePasswordValidator_InvalidPasswordMaximalLength"],
                    36.ToString()));

            RuleFor(x => x.PasswordConfirm)
                .NotEmpty().WithMessage(_localization["ProfilePage_ChangePasswordTab_ChangePasswordValidator_RequiredPasswordConfirm"])
                .Equal(x => x.Password).WithMessage(_localization["ProfilePage_ChangePasswordTab_ChangePasswordValidator_EqualPasswordConfirm"]);
        }
    }
}