namespace School.Views;

public partial class ActivityPage : ContentPage
{
	public ActivityPage()
	{
		InitializeComponent();
	}

	    private void OnReturnToMainPageClicked(object sender, EventArgs e)
    {

        Navigation.PushAsync(new MainPage());
    }
		private void OnActivityPageButtonClicked(object sender, EventArgs e)
	{

		Navigation.PushAsync(new ActivityPage2());
	}
}