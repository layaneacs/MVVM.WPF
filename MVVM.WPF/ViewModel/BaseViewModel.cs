using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MVVM.WPF.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyProperty(string property)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
            }

        }
    }
}
