using StatusBarEffectDemo.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Views;

[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect (typeof(MyStatusBarEffect), "StatusBarEffect")]
namespace StatusBarEffectDemo.Droid
{
	public class MyStatusBarEffect : PlatformEffect
	{
		protected override void OnAttached() 
		{
            var backgroundColor = StatusBarEffect.GetBackgroundColor().ToAndroid();
            Window window = Globals.Window;
            window.SetStatusBarColor(backgroundColor);
        }

		protected override void OnDetached()
		{
			
		}
	}
}

