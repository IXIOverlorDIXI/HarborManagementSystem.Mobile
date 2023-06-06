window.blazorCulture = {
    get: () => window.localStorage['LocalizationCulture'],
    set: (value) => window.localStorage['LocalizationCulture'] = value
};