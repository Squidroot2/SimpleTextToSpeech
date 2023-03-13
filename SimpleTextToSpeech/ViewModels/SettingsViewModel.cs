using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SimpleTextToSpeech.Services;


namespace SimpleTextToSpeech.ViewModels
{
    public partial class SettingsViewModel : BaseViewModel
    {
        readonly SpeechService speechService;
        public readonly float minVolume;
        public readonly float maxVolume;

        public readonly float minPitch;
        public readonly float maxPitch;


        public double MinVolume { get { return (double)minVolume; } }
        public double MaxVolume { get { return (double)maxVolume; } }  
        public double MinPitch { get { return (double)minPitch; } }
        public double MaxPitch { get { return (double)maxPitch; } }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(CurrentVolumeString))]
        double currentVolume;

        public string CurrentVolumeString { get { return String.Format("{0}%", Double.Round(CurrentVolume * 100)); } }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(CurrentPitchString))]
        double currentPitch;

        public string CurrentPitchString { get { return String.Format("{0}%", Double.Round(CurrentPitch * 100)); } }

        public SettingsViewModel(SpeechService speechService)
        {
            this.speechService = speechService;
            minVolume = speechService.minVolume;
            maxVolume = speechService.maxVolume;
            minPitch = speechService.minPitch;
            maxPitch = speechService.maxPitch;
            retrieveCurrentOptions();
        }

        private void retrieveCurrentOptions()
        {
            CurrentVolume = (double)speechService.Options.Volume;
            CurrentPitch = (double)speechService.Options.Pitch;

        }

        [RelayCommand]
        public void SaveVolume()
        {
            speechService.SetVolume(CurrentVolume);
        }

        [RelayCommand]
        public void SavePitch()
        {
            speechService.SetPitch(CurrentPitch);
        }
        
    }
}
