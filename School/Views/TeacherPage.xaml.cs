namespace School.Views;

public partial class TeacherPage : ContentPage
{
	public TeacherPage()
	{
		InitializeComponent();
	}

	    private void OnReturnToMainPageClicked(object sender, EventArgs e)
    {

        Navigation.PushAsync(new MainPage());
    }
}

