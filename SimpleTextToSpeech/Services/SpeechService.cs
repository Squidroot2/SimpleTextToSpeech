using Microsoft.Maui.Media;
using System.Runtime.CompilerServices;
#if ANDROID
using Android.Speech.Tts;
#endif

namespace SimpleTextToSpeech.Services
{
    public class SpeechService
    {
        SpeechOptions options;
        IEnumerable<Locale> locales;

        readonly ITextToSpeech textToSpeech;

        public readonly float minVolume = 0.01f;
        public readonly float maxVolume = 1.0f;
        readonly float defaultVolume = 0.8f;

        public readonly float minPitch = 0.0f;
        public readonly float maxPitch = 2.0f;
        readonly float defaultPitch = 1.0f;

        public SpeechOptions Options
        {
            get { return options; }
        }


        public SpeechService(ITextToSpeech textToSpeech)
        {
            this.textToSpeech = textToSpeech;

            options = new SpeechOptions();
            options.Volume = defaultVolume;
            options.Pitch = defaultPitch;

            SetLocaleListFromSystem();

            if (locales.Count() > 0)
            {
                options.Locale = locales.First();
            }
        }
        public async Task SpeakAsync(string textToPlay)
        {
            await textToSpeech.SpeakAsync(textToPlay, options);
        }

        private void SetLocaleListFromSystem()
        {
            TimeSpan localeRetrieveWaitTime = TimeSpan.FromSeconds(5);
            Task<IEnumerable<Locale>> localesTask = textToSpeech.GetLocalesAsync();
            localesTask.WaitAsync(localeRetrieveWaitTime);
            locales = localesTask.Result;
        }

        public void SetVolume(float newVolume)
        {
            if (options.Volume != newVolume)
            {
                options.Volume = restrictVolume(newVolume);
            }
        }
        public void SetVolume(double newVolume)
        {
            SetVolume((float)newVolume);
        }
        private float restrictVolume(float rawVolume)
        {
            if (rawVolume < minVolume)
            {
                return minVolume;
            }
            else if (rawVolume > maxVolume)
            {
                return maxVolume;
            }
            else
            {
                return rawVolume;
            }
        }

        public void SetPitch(float pitch)
        {
            if (options.Pitch != pitch)
            {
                options.Pitch = restrictPitch(pitch);
            }
        }
        public void SetPitch(double pitch)
        {
            SetPitch((float)pitch);
        }
        private float restrictPitch(float rawPitch)
        {
            if (rawPitch < minPitch) 
            { 
                return minPitch;
            }
            else if (rawPitch > maxPitch)
            {
                return maxPitch;
            }
            else
            {
                return rawPitch;
            }
        }


        
    }


}
