using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace SimpleTextToSpeech.Components;

public partial class OptionsSliderFrame : Frame
{
	public static readonly BindableProperty OptionNameTextProperty = BindableProperty.Create(
		nameof(OptionNameText),
		typeof(string),
		typeof(OptionsSliderFrame),
		defaultValue: "Option Name",
		defaultBindingMode: BindingMode.OneTime
        );

    public static readonly BindableProperty OptionValueTextProperty = BindableProperty.Create(
        nameof(OptionValueText),
        typeof(string),
        typeof(OptionsSliderFrame),
        defaultValue: "100%",
        defaultBindingMode: BindingMode.OneWay
        );

    public static BindableProperty OptionSliderValueProperty = BindableProperty.Create(
        nameof(OptionSliderValue),
        typeof(double),
        typeof(OptionsSliderFrame),
        defaultValue: 0.5,
        defaultBindingMode: BindingMode.TwoWay
        );

    public static readonly BindableProperty OptionSliderMinimumProperty = BindableProperty.Create(
        nameof(OptionSliderMinimum),
        typeof(double),
        typeof(OptionsSliderFrame),
        defaultValue: 0.0,
        defaultBindingMode: BindingMode.OneTime
        );

    public static readonly BindableProperty OptionSliderMaximumProperty = BindableProperty.Create(
        nameof(OptionSliderMaximum),
        typeof(double),
        typeof(OptionsSliderFrame),
        defaultValue: 1.0,
        defaultBindingMode: BindingMode.OneTime
        );

    public static readonly BindableProperty OptionSliderDragCompletedCommandProperty = BindableProperty.Create(
        nameof(OptionSliderDragCompletedCommand),
        typeof(ICommand),
        typeof(OptionsSliderFrame),
        defaultValue: null,
        defaultBindingMode: BindingMode.OneTime       
        );

    public string OptionNameText
	{
		get
		{
			return base.GetValue(OptionNameTextProperty)?.ToString();
		}
		set
		{
			base.SetValue(OptionNameTextProperty, value);
		}
	} 

    public string OptionValueText
    {
        get
        {
            return base.GetValue(OptionValueTextProperty)?.ToString();
        }
        set
        {
            base.SetValue(OptionValueTextProperty, value);
        }
    }

    public double OptionSliderValue
    {
        get
        {
            return (double)base.GetValue(OptionSliderValueProperty);
        }
        set
        {
            base.SetValue(OptionSliderValueProperty, value);
        }
    }

    public double OptionSliderMinimum
    {
        get
        {
            return (double)base.GetValue(OptionSliderMinimumProperty);
        }
        set
        {
            base.SetValue(OptionSliderMinimumProperty, value);
        }
    }

    public double OptionSliderMaximum
    {
        get
        {
            return (double)base.GetValue(OptionSliderMaximumProperty);
        }
        set
        {
            base.SetValue(OptionSliderMaximumProperty, value);
        }
    }

    public RelayCommand OptionSliderDragCompletedCommand
    {
        get { return (RelayCommand)base.GetValue(OptionSliderDragCompletedCommandProperty); }
        set { base.SetValue(OptionSliderDragCompletedCommandProperty, value); }
    }


    public OptionsSliderFrame()
	{
		InitializeComponent();

    }

    //private static void OptionSliderDragCompletedChanged(BindableObject bindable, object _oldValue, object newValue)
    //{
    //    OptionsSliderFrame frame = (OptionsSliderFrame)bindable;
    //    frame.OptionSliderDragCompletedCommand = (RelayCommand)newValue;
    //}

    //private static void OptionNameTextPropertyChanged(BindableObject bindable, object _oldValue, object newValue)
    //{
    //    OptionsSliderFrame frame = (OptionsSliderFrame)bindable;
    //    frame.OptionName.Text = newValue?.ToString();
    //}
    //private static void OptionValueTextPropertyChanged(BindableObject bindable, object _oldValue, object newValue)
    //{
    //    OptionsSliderFrame frame = (OptionsSliderFrame)bindable;
    //    frame.OptionValue.Text = newValue?.ToString();
    //}
    //private static void OptionSliderValuePropertyChanged(BindableObject bindable, object _oldValue, object newValue)
    //{
    //    OptionsSliderFrame frame = (OptionsSliderFrame)bindable;
    //    frame.OptionSlider.Value = (double)newValue;
    //}
    //private static void OptionSliderMinimumPropertyChanged(BindableObject bindable, object _oldValue, object newValue)
    //{
    //    OptionsSliderFrame frame = (OptionsSliderFrame)bindable;
    //    frame.OptionSlider.Minimum = (double)newValue;
    //}
    //private static void OptionSliderMaximumPropertyChanged(BindableObject bindable, object _oldValue, object newValue)
    //{
    //    OptionsSliderFrame frame = (OptionsSliderFrame)bindable;
    //    frame.OptionSlider.Maximum = (double)newValue;
    //}

}