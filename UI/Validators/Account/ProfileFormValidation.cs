using System.Globalization;
using FluentValidation;
using Microsoft.Extensions.Localization;
using UI.FormEntities.Account;
using UI.Services;

namespace UI.Validators.Account
{
    public class ProfileFormValidation : AbstractValidatorExtension<ProfileForm>
    {
        private readonly LocalizationService _localizationService;
        private readonly IStringLocalizer<UI.Localizations.Localization> _localization;
        
        public ProfileFormValidation(LocalizationService localizationService, 
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
            
            // RuleFor(x => x.Username)
            //     .NotEmpty().WithMessage(_localization["ProfilePage_ProfileTab_ProfileValidator_RequiredUsername"])
            //     .MinimumLength(8).WithMessage(String.Format(
            //         _localization["ProfilePage_ProfileTab_ProfileValidator_InvalidUsernameMinimalLength"],
            //         8.ToString()))
            //     .MaximumLength(36).WithMessage(String.Format(
            //         _localization["ProfilePage_ProfileTab_ProfileValidator_InvalidUsernameMaximalLength"],
            //         36.ToString()));

            RuleFor(x => x.DisplayName)
                .NotEmpty().WithMessage(_localization["ProfilePage_ProfileTab_ProfileValidator_RequiredDisplayName"])
                .MinimumLength(8).WithMessage(String.Format(
                    _localization["ProfilePage_ProfileTab_ProfileValidator_InvalidDisplayNameMinimalLength"],
                    8.ToString()))
                .MaximumLength(36).WithMessage(String.Format(
                    _localization["ProfilePage_ProfileTab_ProfileValidator_InvalidDisplayNameMaximalLength"],
                    36.ToString()));

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(_localization["ProfilePage_ProfileTab_ProfileValidator_RequiredEmail"])
                .EmailAddress().WithMessage(_localization["ProfilePage_ProfileTab_ProfileValidator_InvalidEmailFormat"]);
            
            RuleFor(x => x.PhoneNumber)
                //.NotEmpty().WithMessage(_localization["ProfilePage_ProfileTab_ProfileValidator_RequiredPhoneNumber"])
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage(_localization["ProfilePage_ProfileTab_ProfileValidator_InvalidPhoneNumberFormat"]);
        }
    }
}