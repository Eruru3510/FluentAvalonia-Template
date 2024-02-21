
using Avalonia;
using Avalonia.Controls;

using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Threading;

using AvaloniaNav.Services.UnitViewModels;
using AvaloniaNav.ViewModels;

using FluentAvalonia.UI.Controls;
using FluentAvalonia.UI.Navigation;
using FluentAvalonia.UI.Windowing;

using System;
using System.Collections.Generic;
using System.Linq;

namespace AvaloniaNav;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }

    private void OnFrameViewNavigated(object sender,NavigationEventArgs e)
    {
        var page = e.Content as Control;
        var dataContext = page?.DataContext;


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

    protected override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);

        if (VisualRoot is AppWindow aw)
        {
            TitleBarHost.Height = 50;
            TitleBarHost.ColumnDefinitions[3].Width = new GridLength(aw.TitleBar.RightInset,GridUnitType.Pixel);
        }
    }

    protected override void OnPointerReleased(PointerReleasedEventArgs e)
    {
        base.OnPointerReleased(e);
    }

    public IEnumerable<MainPageViewModelBase> InitializeFrameViewModel()
    {
        return new[]
        {
            new HomeControlViewModel { NavHeader = "Home", IconKey = "HomeIcon" },
        };
    }

    public void InitializeNavigationPages()
    {

        try
        {
            var mainPages = new[]
            {
                new HomeControlViewModel
                {
                    NavHeader = "Home",
                    IconKey = "HomeIcon",
                }
            };

            Dispatcher.UIThread.Post(() =>
            {
                var menuItems = mainPages.Select(pg => new NavigationViewItem
                {
                    Content = pg.NavHeader,
                    Tag = pg,
                    IconSource = this.FindResource(pg.IconKey) as IconSource

                }).ToList();

                NavView.MenuItemsSource = menuItems;

                if (menuItems.FirstOrDefault() is Control firstMenuItem)
                {
                    FrameView.NavigateFromObject(firstMenuItem.Tag);
                }
            });
        }
        catch (Exception ex)
        {
            var warningDialog = new WarningDialogProduct("Warning","Warning!",$"Exception: {ex.Message}");

            warningDialog.ShowDialog();
        }
    }
}
