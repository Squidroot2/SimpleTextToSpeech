using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SimpleTextToSpeech.Services;
using SimpleTextToSpeech.Views;

namespace SimpleTextToSpeech.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        readonly SpeechService speechService;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(TextNotEmpty))]
        string text;

        public bool TextNotEmpty
        {
            get { return !String.IsNullOrEmpty(Text); }
        }

        public MainViewModel(SpeechService speechService)
        {
            this.speechService = speechService;
        }


        [RelayCommand]
        public async Task PlayTextAsync()
        {
            IsBusy = true;
            try
            {
                await speechService.SpeakAsync(Text);
            }
            catch (Exception exception)
            {
                //TODO Actually do something when exception encountered
                Console.WriteLine(exception.ToString());
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        public async Task GoToSettingsAsync()
        {
            await Shell.Current.GoToAsync(nameof(SettingsPage));
        }


    }



}
