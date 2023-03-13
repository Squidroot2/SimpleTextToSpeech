using SimpleTextToSpeech.Views;

namespace SimpleTextToSpeech;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		
		Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
	}
}
