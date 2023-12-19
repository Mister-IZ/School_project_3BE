namespace School.Views;

public partial class StudentPage : ContentPage
{
	public StudentPage()
	{
		
		InitializeComponent();
	}

	    private void OnReturnToMainPageClicked(object sender, EventArgs e)
    {

        Navigation.PushAsync(new MainPage());
    }
		private void OnStudentPageButtonClicked(object sender, EventArgs e)
	{

		Navigation.PushAsync(new StudentPage2());
	}
}