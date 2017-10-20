using System;
using Foundation;
using StatusBarEffectDemo.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(MyStatusBarEffect), "StatusBarEffect")]
namespace StatusBarEffectDemo.iOS
{
    public class MyStatusBarEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            UIView statusBar = UIApplication.SharedApplication.ValueForKey(new NSString("statusBar")) as UIView;
            if (statusBar.RespondsToSelector(new ObjCRuntime.Selector("setBackgroundColor:")))
            {
                statusBar.BackgroundColor = StatusBarEffect.GetBackgroundColor().ToUIColor();
            }
        }

        protected override void OnDetached()
        {

        }
    }
}
