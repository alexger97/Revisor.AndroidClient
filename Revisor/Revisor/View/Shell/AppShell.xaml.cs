using Revisor.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Revisor.View.Shell
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();


            Items.Add(new FlyoutItem
            {
                FlyoutIcon = ImageSource.FromFile("iconsMain.png"),
                Title = "Объекты  ",
                Items =
                {
                    new Tab
                    {
                        Items = { new ShellContent {Content = ViewService.MainPage} }
                    }
                }

            });



        }
    }
}