﻿using System.ComponentModel;

namespace GameBook.Views.ViewModels.Impl
{
    public abstract class ObservableViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertiesChanged(params string[] properties)
        {
            foreach (var p in properties) RaisePropertyChanged(p);
        }

        protected void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
