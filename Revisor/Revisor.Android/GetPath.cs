using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Revisor.Droid;
using Revisor.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(GetPath))]
namespace Revisor.Droid
{
    public class GetPath : IPath
    {
 
        public string GetDatabasePath(string filename)
        {
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), filename);

            return path;
        }

        public string GetPathTest()
        {
            var tt = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDocuments).AbsolutePath;
            string direct = tt + "/Отчеты";
            Directory.CreateDirectory(direct);
            return direct;
        }


    }
}