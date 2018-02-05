using Xamarin.Forms;

namespace CollapsibleContentSample
{
	public partial class SectionHeaderView : ContentView
	{
        string headerTitle;
        public string HeaderTitle
        {
            get { return headerTitle; }
            set { headerTitle = value; lblHeaderTitle.Text = headerTitle; }
        }

        ContentView contentPart;
        public ContentView ContentPart
        {
            get { return contentPart; }
            set { contentPart = value; grdContent.Children.Add(contentPart); }
        }

        public SectionHeaderView ()
		{
			InitializeComponent ();

            btnHeader.Clicked += BtnHeaderClicked;
		}

        private void BtnHeaderClicked(object sender, System.EventArgs e)
        {
            grdContent.IsVisible = !grdContent.IsVisible;
            btnHeader.Text = grdContent.IsVisible ? "Close" : "Open";
        }
    }
}