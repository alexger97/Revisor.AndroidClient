using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Revisor.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OneMaterial : ContentPage
    {
        public OneMaterial()
        {
            InitializeComponent();
            c1.IsChecked = true;
        }

        private void C2_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value) { c1.IsChecked = false; }
            else { c1.IsChecked = true; }

        }

        private void C1_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value) { c2.IsChecked = false; }
            else { c2.IsChecked = true; }
        }
    }
}