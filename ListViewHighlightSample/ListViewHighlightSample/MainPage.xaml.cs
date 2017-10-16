using System.Linq;
using Xamarin.Forms;

namespace ListViewHighlightSample
{
    public partial class MainPage : ContentPage
    {
        MainViewModel vm;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = vm = new MainViewModel();
        }

        void ListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            if (vm.PersonList[vm.SelectedIndex].IsSelected)
                vm.PersonList[vm.SelectedIndex].IsSelected = false;

            Person personSelected = e.Item as Person;
            vm.SelectedIndex = vm.PersonList.IndexOf(personSelected);            
            personSelected.IsSelected = true;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemTapped += ListViewItemTapped;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            listView.ItemTapped -= ListViewItemTapped;
        }
    }
}
