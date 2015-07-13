namespace WorldData.ViewModels
{
    public class ViewModelBase : ObservableObject
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
        

    }
}
