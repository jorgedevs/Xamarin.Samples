using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace TableSortSample
{
    public class MainViewModel : INotifyPropertyChanged
    {
        const int NOT_ORDERED = -1;
        const int ORDER_ASCENDING = 1;
        const int ORDER_DESCENDING = 2;

        public ObservableCollection<Person> PersonList { get; set; }

        int firstNameHeader;
        public int FirstNameHeader
        {
            get { return firstNameHeader; }
            set { firstNameHeader = value; OnPropertyChanged("FirstNameHeader"); }
        }

        int lastNameHeader;
        public int LastNameHeader
        {
            get { return lastNameHeader; }
            set { lastNameHeader = value; OnPropertyChanged("LastNameHeader"); }
        }

        int ageHeader;
        public int AgeHeader
        {
            get { return ageHeader; }
            set { ageHeader = value; OnPropertyChanged("AgeHeader"); }
        }

        public ICommand SortCommand { protected set; get; }

        public MainViewModel()
        {
            PersonList = new ObservableCollection<Person>();

            PersonList.Add(new Person() { FirstName = "John",    LastName = "Dacus",   Age = 23 });
            PersonList.Add(new Person() { FirstName = "Peter",   LastName = "Brugman", Age = 53 });
            PersonList.Add(new Person() { FirstName = "Carla",   LastName = "Bosco",   Age = 23 });
            PersonList.Add(new Person() { FirstName = "Matt",    LastName = "Mayer",   Age = 45 });
            PersonList.Add(new Person() { FirstName = "Lindsay", LastName = "Andujar", Age = 21 });
            PersonList.Add(new Person() { FirstName = "Michael", LastName = "Graden",  Age = 18 });
            PersonList.Add(new Person() { FirstName = "Holly",   LastName = "Porto",   Age = 55 });
            PersonList.Add(new Person() { FirstName = "Jessica", LastName = "Banes",   Age = 45 });
            PersonList.Add(new Person() { FirstName = "George",  LastName = "Dusek",   Age = 34 });
            PersonList.Add(new Person() { FirstName = "Marie",   LastName = "Welker",  Age = 25 });

            SortCommand = new Command<string>((opt) => SortCommandExecute(opt));
            SortCommandExecute("firstName");
        }

        void SortCommandExecute(string sortOpt)
        {
            ObservableCollection<Person> orderedList = null;

            switch(sortOpt)
            {
                case "firstName":
                    LastNameHeader = NOT_ORDERED;
                    AgeHeader = NOT_ORDERED;

                    if (FirstNameHeader == NOT_ORDERED || FirstNameHeader == ORDER_DESCENDING)
                    {
                        FirstNameHeader = ORDER_ASCENDING;
                        orderedList = new ObservableCollection<Person>(PersonList.OrderBy(i => i.FirstName));
                    }                        
                    else
                    {                        
                        FirstNameHeader = ORDER_DESCENDING;
                        orderedList = new ObservableCollection<Person>(PersonList.OrderByDescending(i => i.FirstName));
                    }
                    break;

                case "lastName":
                    FirstNameHeader = NOT_ORDERED;
                    AgeHeader = NOT_ORDERED;

                    if (LastNameHeader == NOT_ORDERED || LastNameHeader == ORDER_DESCENDING)
                    {
                        LastNameHeader = ORDER_ASCENDING;
                        orderedList = new ObservableCollection<Person>(PersonList.OrderBy(i => i.LastName));
                    }
                    else
                    {
                        LastNameHeader = ORDER_DESCENDING;
                        orderedList = new ObservableCollection<Person>(PersonList.OrderByDescending(i => i.LastName));                        
                    }
                    break;

                case "age":
                    FirstNameHeader = NOT_ORDERED;
                    LastNameHeader = NOT_ORDERED;

                    if (AgeHeader == NOT_ORDERED || AgeHeader == ORDER_DESCENDING)
                    {
                        AgeHeader = ORDER_ASCENDING;
                        orderedList = new ObservableCollection<Person>(PersonList.OrderBy(i => i.Age));
                    }
                    else
                    {
                        AgeHeader = ORDER_DESCENDING;
                        orderedList = new ObservableCollection<Person>(PersonList.OrderByDescending(i => i.Age));
                    }
                    break;
            }

            PersonList.Clear();
            foreach (var person in orderedList)
                PersonList.Add(person);
        }

        #region INotifyPropertyChanges Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;
            changed.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}
