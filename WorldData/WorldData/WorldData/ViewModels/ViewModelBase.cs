using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WorldData.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; RaisePropertyChanged(); }
        }

        private string icon;

        public string Icon
        {
            get { return icon; }
            set { icon = value; RaisePropertyChanged(); }
        }


        private bool isbusy;

        public bool IsBusy
        {
            get { return isbusy; }
            set { isbusy = value; RaisePropertyChanged(); }
        }
        

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged([CallerMemberName]string propertyName = null)
        {
            if (PropertyChanged == null)
                return;
            
            PropertyChanged(this,new PropertyChangedEventArgs(propertyName));
            
        }
    }
}
