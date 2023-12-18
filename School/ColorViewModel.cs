using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace School;

[ObservableObject]
public partial class ColorViewModel
{
    public ColorViewModel()
    {
        var defaultThemes = new List<Theme>()
        {
            new Theme("Same as system", "System"),
            new Theme("Dark", "Dark"),
            new Theme("Light", "Light"),
            new Theme("Blue","Blue"),
            new Theme("Red", "Red")
        };

        Themes = new List<Theme>(defaultThemes);

    }

    [ObservableProperty]
    private List<Theme> themes;

    [ObservableProperty]
    private Theme selectedTheme;

    partial void OnSelectedThemeChanged(Theme value)
    {
        if(value == null)
        {
            return;
        }

        Preferences.Set("theme", value.Key);

        WeakReferenceMessenger.Default.Send(new ThemeChangedMessage(value.Key));
    }

}

