using System;
using System.Collections.ObjectModel;

namespace ListViewHighlightSample
{
    public class MainViewModel
    {
        public int SelectedIndex { get; set; }
        public ObservableCollection<Person> PersonList { get; set; }

        public MainViewModel()
        {
            PersonList = new ObservableCollection<Person>();
            PersonList.Add(new Person() { Name = "John Dacus" }); 
            PersonList.Add(new Person() { Name = "Peter Brugman" }); 
            PersonList.Add(new Person() { Name = "Carla Bosco" }); 
            PersonList.Add(new Person() { Name = "Matt Mayer" }); 
            PersonList.Add(new Person() { Name = "Lindsay Andujar" }); 
            PersonList.Add(new Person() { Name = "Michael Graden" }); 
            PersonList.Add(new Person() { Name = "Holly Porto" }); 
            PersonList.Add(new Person() { Name = "Jessica Banes" }); 
            PersonList.Add(new Person() { Name = "George Dusek" }); 
            PersonList.Add(new Person() { Name = "Marie  Welker" }); 
        }
    }
}
