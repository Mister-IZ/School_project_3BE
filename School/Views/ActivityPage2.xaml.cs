namespace School.Views;

public partial class ActivityPage2 : ContentPage
{
	public ActivityPage2()
	{
		InitializeComponent();
	}


	private void OnCreateActivityClicked(object sender, EventArgs e)
    {
        var activityModel = new ActivityModel
		{
            
                course = courseEntered.Text
        };

            var activityRepository = new ActivityRepository();
            activityRepository.SaveActivitys(activityModel);

		Navigation.PushAsync(new MainPage());
    }

        private void OnReturnToMainPageClicked(object sender, EventArgs e)
    {

        Navigation.PushAsync(new MainPage());
    }
}
	
