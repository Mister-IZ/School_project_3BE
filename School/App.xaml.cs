namespace School;
using System.Text.Json;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
		
        WeakReferenceMessenger.Default.Register<ThemeChangedMessage>(this, (r, m) =>
        {
            LoadTheme(m.Value);
        });

        var theme = Preferences.Get("theme", "System");

        LoadTheme(theme);
    }

    private void LoadTheme(string theme)
    {
        if (!MainThread.IsMainThread)
        {
            MainThread.BeginInvokeOnMainThread(() => LoadTheme(theme));
            return;
        }

        if (theme == "System")
        {
            theme = Current.PlatformAppTheme.ToString();
        }

        ResourceDictionary dictionary = theme switch
        {
            "Dark" => new Resources.Styles.Dark(),
            "Light" => new Resources.Styles.Light(),
            "Red" => new Resources.Styles.Red(),
            "Blue" => new Resources.Styles.Blue(),
            _ => null
        };

        if (dictionary != null)
        {
            Resources.MergedDictionaries.Clear();

            Resources.MergedDictionaries.Add(dictionary);
        }
    }
}