using System.Reactive;
using System.Reactive.Disposables;

using Avalonia.Controls;
using Avalonia.ReactiveUI;

using AvaloniaNav.ViewModels;

using ReactiveUI;

namespace AvaloniaNav;

public partial class HomeControl : ReactiveUserControl<HomeControlViewModel>
{
    public HomeControl()
    {
        InitializeComponent();
        this.WhenActivated(disposables =>
        {
            ViewModel?.SelectAllTextInteraction.RegisterHandler(async interaction =>
            {
                LogViewer.SelectAll();
                interaction.SetOutput(Unit.Default);
            }).DisposeWith(disposables);
        });

    }

    private void Control_OnSizeChanged(object sender,SizeChangedEventArgs e)
    {
        if (e.HeightChanged)
        {
            ScrollOutputViewer.Height = e.NewSize.Height;
        }
    }
}