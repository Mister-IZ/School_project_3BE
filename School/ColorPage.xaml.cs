namespace School;

public partial class ColorPage : ContentPage
{
	public ColorPage()
	{
		InitializeComponent();

		BindingContext = new ColorViewModel();
	}

	
}

