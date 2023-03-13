using Microsoft.Extensions.Logging;
using SimpleTextToSpeech.Services;
using SimpleTextToSpeech.ViewModels;
using SimpleTextToSpeech.Views;

namespace SimpleTextToSpeech;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		
		builder.Services.AddSingleton<ITextToSpeech>(TextToSpeech.Default);

        builder.Services.AddSingleton<SpeechService>();

        builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<MainViewModel>();

		builder.Services.AddSingleton<SettingsPage>();
		builder.Services.AddSingleton<SettingsViewModel>();

		return builder.Build();
	}
}
