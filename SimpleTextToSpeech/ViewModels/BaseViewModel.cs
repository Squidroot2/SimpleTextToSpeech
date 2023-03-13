using CommunityToolkit.Mvvm.ComponentModel;


namespace SimpleTextToSpeech.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy = false;

        public bool IsNotBusy => !IsBusy;



        

    }
}
