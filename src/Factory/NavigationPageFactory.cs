using System;

using Avalonia.Controls;

using AvaloniaNav.ViewModels;

using FluentAvalonia.UI.Controls;

namespace AvaloniaNav.Factory;
public class NavigationPageFactory : INavigationPageFactory
{
    public NavigationPageFactory(MainViewViewModel mainViewViewModel)
    {
        MainViewViewModel = mainViewViewModel;
    }

    public MainViewViewModel MainViewViewModel { get; }
    public Control GetPage(Type srcType)
    {
        return null;
    }

    public Control GetPageFromObject(object target)
    {
       if (target is HomeControlViewModel)
        {
            return new HomeControl
            {
                DataContext = target
            };
        }

        return null;
    }
}
