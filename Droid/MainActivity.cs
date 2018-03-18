using System;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xam.Plugins.OnDeviceCustomVision;

namespace CoinorNot.Droid
{
    [Activity(Label = "CoinorNot.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            // The tensorflow model downloaded from Custom Vision. It contains 2 files
            // The files are placed into the Assets folder

            CrossImageClassifier.Current.Init("model.pb", ModelType.General);

            LoadApplication(new App());
        }

      
    }
}
