using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TableSortSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
    }
}
