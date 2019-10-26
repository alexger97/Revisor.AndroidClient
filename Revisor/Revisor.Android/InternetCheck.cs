using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Revisor.Interfaces;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(Revisor.Droid.InternerCheck))]
namespace Revisor.Droid
{
    class InternerCheck : ICheckConnection
    {
        NetworkAccess Current = Connectivity.NetworkAccess;

        private bool isUse;
        public bool IsUse
        {
            get
            {
                if (Current == NetworkAccess.Internet)
                {
                    IsUse = true;
                    return isUse;
                }
                else
                {
                    IsUse = false;
                    return isUse;
                }
            }
            set { isUse = value; }
        }
    }
}