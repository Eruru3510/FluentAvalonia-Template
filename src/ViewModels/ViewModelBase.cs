using ReactiveUI;

namespace AvaloniaNav.ViewModels;
public class ViewModelBase : ReactiveObject
{
}

public class MainPageViewModelBase : ViewModelBase
{
    public string NavHeader { get; set; }

    public string IconKey { get; set; }

    public bool ShowsInFooter { get; set; }
}
