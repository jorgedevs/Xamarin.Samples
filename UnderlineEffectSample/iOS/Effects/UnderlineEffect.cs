using System;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(UnderlineEffectSample.iOS.Effects.UnderlineEffect), "UnderlineEffect")]
namespace UnderlineEffectSample.iOS.Effects
{
    public class UnderlineEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var label = (Label) Element;
            UIStringAttributes attr = new UIStringAttributes();
            attr.UnderlineStyle = NSUnderlineStyle.Single;
            ((UILabel)Control).AttributedText = new NSAttributedString(label.Text, attr);
        }

        protected override void OnDetached()
        {
            var label = (Label)Element;
            UIStringAttributes attr = new UIStringAttributes();
            attr.UnderlineStyle = NSUnderlineStyle.None;
            ((UILabel)Control).AttributedText = new NSAttributedString(label.Text, attr);
        }
    }
}
