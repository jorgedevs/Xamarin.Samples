using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace RadioButtonSample
{
    public class MainViewModel : INotifyPropertyChanged
    {
        int option;
        public int Option
        {
            get { return option; }
            set { option = value; OnPropertyChanged("Option"); }
        }

        public ICommand OptionCommand { protected set; get;  }

        public MainViewModel()
        {
            Option = 1;

            OptionCommand = new Command<string>((opt) => OptionCommandExecute(opt));
        }

        void OptionCommandExecute(string opt)
        {
            Option = int.Parse(opt);
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
