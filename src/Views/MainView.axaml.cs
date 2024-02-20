using System;
using System.Collections.Generic;

using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Threading;

using AvaloniaNav.ViewModels;

using FluentAvalonia.Core;
using FluentAvalonia.UI.Controls;
using FluentAvalonia.UI.Navigation;
using FluentAvalonia.UI.Windowing;

namespace AvaloniaNav;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }

    protected override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);

        if (VisualRoot is AppWindow aw)
        {
            TitleBarHost.ColumnDefinitions[3].Width = new GridLength(aw.TitleBar.RightInset,GridUnitType.Pixel);
        }
    }

    protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnAttachedToVisualTree(e);

        var vm = new MainViewViewModel();
        DataContext = vm;
        FrameView.NavigationPageFactory = vm.NavigationPageFactory;

        if (e.Root is AppWindow window)
        {
            InitializeNavigationPages();
        }
        else
        {
            InitializeNavigationPages();
        }

        FrameView.Navigated += OnFrameViewNavigated;
    }

    public void InitializeNavigationPages()
    {

        try
        {
            var mainPages = new MainPageViewModelBase[]
            {
                new HomeControlViewModel
                {
                    NavHeader = "Home",
                    IconKey = "HomeIcon",
                }
            };

            var menuItems = new List<NavigationViewItemBase>(1);

            Dispatcher.UIThread.Post(() =>
            {
                for (int i = 0; i < mainPages.Length; i++)
                {
                    var pg = mainPages[i];
                    var nvi = new NavigationViewItem
                    {
                        Content = pg.NavHeader,
                        Tag = pg,
                        IconSource = this.FindResource(pg.IconKey) as IconSource
                    };

                    menuItems.Add(nvi);

                }
                NavView.MenuItemsSource = menuItems;
                FrameView.NavigateFromObject((NavView.MenuItemsSource.ElementAt(0) as Control).Tag);

            });


        }
        catch (Exception ex)
        {
            DialogHostAvalonia.DialogHost.Show(ex.Message);
        }
    }

    protected override void OnPointerReleased(PointerReleasedEventArgs e)
    {
        base.OnPointerReleased(e);
    }

    private void OnFrameViewNavigated(object sender,NavigationEventArgs e)
    {
        var page = e.Content as Control;
        var dataContext = page?.DataContext;


    }
}
