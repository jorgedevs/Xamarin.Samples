using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CollapsibleContentSample
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region General Information
        bool showGeneralInfo;
        public bool ShowGeneralInfo
        {
            get { return showGeneralInfo; }
            set { showGeneralInfo = value; OnPropertyChanged("ShowGeneralInfo"); }
        }

        string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; OnPropertyChanged("FirstName"); }
        }

        string lastName;
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; OnPropertyChanged("LastName"); }
        }

        int age;
        public int Age
        {
            get { return age; }
            set { age = value; OnPropertyChanged("Age"); }
        }
        #endregion

        #region General Information
        bool showContactInfo;
        public bool ShowContactInfo
        {
            get { return showContactInfo; }
            set { showContactInfo = value; OnPropertyChanged("ShowContactInfo"); }
        }

        string email;
        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged("Email"); }
        }

        string phone;
        public string Phone
        {
            get { return phone; }
            set { phone = value; OnPropertyChanged("Phone"); }
        }

        string address;
        public string Address
        {
            get { return address; }
            set { address = value; OnPropertyChanged("Address"); }
        }
        #endregion

        #region General Information
        bool showAdditionalInformation;
        public bool ShowAdditionalInformation
        {
            get { return showAdditionalInformation; }
            set { showAdditionalInformation = value; OnPropertyChanged("ShowAdditionalInformation"); }
        }

        string additionalInfo;
        public string AdditionalInfo
        {
            get { return additionalInfo; }
            set { additionalInfo = value; OnPropertyChanged("AdditionalInfo"); }
        }
        #endregion

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
