using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ListViewHighlightSample
{
    public class Person : INotifyPropertyChanged
    {
        public string Name { get; set; }

        bool isSelected;
        public bool IsSelected 
        {
            get { return isSelected; }
            set { isSelected = value; OnPropertyChanged("IsSelected"); }
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
