using Android.Views;

namespace StatusBarEffectDemo.Droid
{
    public class Globals
    {
        private static Window window;
        public static Window Window
        {
            get
            {
                return window;
            }
            set
            {
                window = value;
            }
        }
    }
}