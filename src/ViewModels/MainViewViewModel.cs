using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AvaloniaNav.Factory;

using FluentAvalonia.UI.Controls;

namespace AvaloniaNav.ViewModels;
public class MainViewViewModel : ViewModelBase
{
    public NavigationPageFactory NavigationPageFactory { get; }
    public MainViewViewModel()
    {
        NavigationPageFactory = new NavigationPageFactory(this);
    }


}
