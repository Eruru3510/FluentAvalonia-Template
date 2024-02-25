using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Threading.Tasks;

using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.ReactiveUI;
using Avalonia.VisualTree;

using AvaloniaNav.Services.Units;
using AvaloniaNav.Services.UnitViewModels;
using AvaloniaNav.ViewModels;

using FluentAvalonia.UI.Windowing;

using ReactiveUI;

namespace AvaloniaNav;

public partial class HomeControl : ReactiveUserControl<HomeControlViewModel>
{
    public HomeControl()
    {
        InitializeComponent();

    }
    
}