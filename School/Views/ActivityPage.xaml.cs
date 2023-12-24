namespace School.Views;

public partial class ActivityPage : ContentPage
{
    public ActivityPage()
    {
        InitializeComponent();

        LoadActivityList();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        LoadActivityList();
    }

    private void LoadActivityList()
    {
        try
        {
            string filePath = "activitys.txt";

            if (File.Exists(filePath))
            {
                var activityLines = File.ReadAllLines(filePath);

                var activities = new List<ActivityModel>();

                foreach (var activityLine in activityLines)
                {
                    var activityData = activityLine.Split(',');

                    if (activityData.Length == 4) 
                    {
                        var activity = new ActivityModel
                        {
                            course = activityData[0].Trim(),
                            code = activityData[1].Trim(),
                            ECTS = activityData[2].Trim(),
                            Teacher = activityData[3].Trim()
                        };

                        activities.Add(activity);
                    }
                    else
                    {
                        Console.WriteLine($"La ligne '{activityLine}' ne contient pas le nombre d'éléments attendu.");
                    }
                }

                ActivityListView.ItemsSource = activities;
            }
            else
            {
                // Rien
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors de la lecture du fichier activitys.txt : {ex.Message}");
        }
    }

	private void OnDeleteClicked(object sender, EventArgs e)
	{
		var activity = (ActivityModel)((Button)sender).CommandParameter;

		DeleteActivity(activity);

		LoadActivityList();
	}

	private void DeleteActivity(ActivityModel activity)
	{
		try
		{
			string filePath = "activitys.txt";

			var activityLines = File.ReadAllLines(filePath);

			var updatedLines = activityLines.Where(line =>
			{
				var data = line.Split(',');
				if (data.Length == 4)
				{
					var existingActivity = new ActivityModel
					{
						course = data[0].Trim(),
						code = data[1].Trim(),
						ECTS = data[2].Trim(),
						Teacher = data[3].Trim()
					};

					return !existingActivity.Equals(activity);
				}
				return false;
			});

			File.WriteAllLines(filePath, updatedLines);
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Erreur lors de la suppression de l'activité : {ex.Message}");
		}
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
