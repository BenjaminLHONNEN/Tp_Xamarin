using System.ComponentModel;
using System.Runtime.CompilerServices;
using TPXamarin.Annotations;

namespace TPXamarin.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private bool _isBusy;

        public bool IsBusy
        {
            get { return _isBusy; }
            set { _isBusy = value; }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
