using System.Globalization;
using FluentValidation;
using Microsoft.Extensions.Localization;
using UI.FormEntities;
using UI.Services;

namespace UI.Validators.Review
{
    public class ReviewValidator : AbstractValidatorExtension<ReviewForm>
    {
        private readonly LocalizationService _localizationService;
        private readonly IStringLocalizer<UI.Localizations.Localization> _localization;
        
        public ReviewValidator(LocalizationService localizationService, 
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
            
            RuleFor(x => x.ReviewMinuses)
                .NotEmpty().WithMessage(_localization["HarborPage_ReviewValidator_RequiredReviewMinuses"])
                .MinimumLength(4).WithMessage(String.Format(
                    _localization["HarborPage_ReviewValidator_InvalidMinimalReviewMinusesLength"],
                    4.ToString()))
                .MaximumLength(255).WithMessage(String.Format(
                    _localization["HarborPage_ReviewValidator_InvalidMaximalReviewMinusesLength"],
                    255.ToString()));

            RuleFor(x => x.ReviewPluses)
                .NotEmpty().WithMessage(_localization["HarborPage_ReviewValidator_RequiredReviewPluses"])
                .MinimumLength(4).WithMessage(String.Format(
                    _localization["HarborPage_ReviewValidator_InvalidMinimalReviewPlusesLength"],
                    4.ToString()))
                .MaximumLength(255).WithMessage(String.Format(
                    _localization["HarborPage_ReviewValidator_InvalidMaximalReviewPlusesLength"],
                    255.ToString()));
            
            RuleFor(x => x.ReviewBody)
                .NotEmpty().WithMessage(_localization["HarborPage_ReviewValidator_RequiredReviewBody"])
                .MinimumLength(4).WithMessage(String.Format(
                    _localization["HarborPage_ReviewValidator_InvalidMinimalReviewBodyLength"],
                    4.ToString()))
                .MaximumLength(255).WithMessage(String.Format(
                    _localization["HarborPage_ReviewValidator_InvalidMaximalReviewBodyLength"],
                    255.ToString()));
            
            RuleFor(x => x.ReviewMark)
                .NotEmpty().WithMessage(_localization["HarborPage_ReviewValidator_RequiredReviewMark"])
                .GreaterThanOrEqualTo(1).WithMessage(String.Format(
                    _localization["HarborPage_ReviewValidator_InvalidMinimalReviewMark"], 1.ToString()))
                .LessThanOrEqualTo(5)
                .WithMessage(String.Format(
                    _localization["HarborPage_ReviewValidator_InvalidMaximalReviewMark"], 5.ToString()));

            RuleFor(x => x.BerthId)
                .Must(x => !x.Equals(Guid.Empty)).WithMessage(_localization["HarborPage_ReviewValidator_RequiredBerth"]);
        }
    }
}