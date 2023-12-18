namespace School;

public partial class ColorPage : ContentPage
{
	public ColorPage()
	{
		InitializeComponent();

		BindingContext = new ColorViewModel();
	}

    private void OnReturnToMainPageClicked(object sender, EventArgs e)
    {

        Navigation.PushAsync(new MainPage());
    }

	
}

