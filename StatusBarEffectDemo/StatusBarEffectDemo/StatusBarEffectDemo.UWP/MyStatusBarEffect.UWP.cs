using System;
using StatusBarEffectDemo.UWP;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using Windows.UI.ViewManagement;
using Windows.Foundation.Metadata;

[assembly: ResolutionGroupName ("Xamarin")]
[assembly: ExportEffect (typeof (MyStatusBarEffect), "StatusBarEffect")]
namespace StatusBarEffectDemo.UWP
{
    internal class MyStatusBarEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var backgroundColor = StatusBarEffect.GetBackgroundColor();

            var alpha = backgroundColor.A * 255;
            var red   = backgroundColor.R * 255;
            var green = backgroundColor.G * 255;
            var blue  = backgroundColor.B * 255;
            var statusBackgroundColor = Windows.UI.Color.FromArgb((byte)alpha, (byte)red, (byte)green, (byte)blue);

            //if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.ApplicationView"))
            //{
            //    var titleBar = ApplicationView.GetForCurrentView().TitleBar;
            //    if (titleBar != null)
            //    {
            //        titleBar.ButtonBackgroundColor = Colors.DarkBlue;
            //        titleBar.ButtonForegroundColor = Colors.White;
            //        titleBar.BackgroundColor = Colors.Blue;
            //        titleBar.ForegroundColor = Colors.White;
            //    }
            //}

            if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar"))
            {
                var statusBar = StatusBar.GetForCurrentView();
                if (statusBar != null)
                {
                    statusBar.BackgroundOpacity = 1;
                    statusBar.BackgroundColor = statusBackgroundColor;
                }
            }
        }

        protected override void OnDetached()
        {
            
        }
    }
}
