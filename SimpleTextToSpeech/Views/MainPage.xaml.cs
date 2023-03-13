using SimpleTextToSpeech.ViewModels;

namespace SimpleTextToSpeech.Views;

public partial class MainPage : ContentPage
{
	public MainPage(MainViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;

	}
}

