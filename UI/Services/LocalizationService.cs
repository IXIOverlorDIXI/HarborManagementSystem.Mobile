using System.Globalization;

namespace UI.Services;

public class LocalizationService
{
    private CultureInfo _currentCulture = CultureInfo.DefaultThreadCurrentUICulture 
                                         ?? new CultureInfo("uk");
    public CultureInfo CurrentCulture
    {
        get => _currentCulture;
        set
        {
            if (!_currentCulture.Name.Equals(value.Name))
            {
                _currentCulture = value;
                NotifyCultureChanged();
            }
        }
    }

    public event Action CultureChanged;

    private void NotifyCultureChanged()
    {
        CultureChanged?.Invoke();
    }
    
    public void SetCulture(CultureInfo culture)
    {
        CurrentCulture = culture;
    }

    public CultureInfo GetCulture()
    {
        return CurrentCulture;
    }
}