namespace School.Views;

public partial class ActivityPage : ContentPage
{
    public ActivityPage()
    {
        InitializeComponent();

        // Chargez et affichez la liste des activités lors de la création de la page
        LoadActivityList();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Mettez à jour la liste des activités chaque fois que la page devient visible
        LoadActivityList();
    }

    // Méthode pour charger et afficher la liste des activités
    private void LoadActivityList()
    {
        try
        {
            string filePath = "activitys.txt";

            // Vérifiez si le fichier existe avant de tenter de le lire
            if (File.Exists(filePath))
            {
                // Lisez toutes les lignes du fichier
                var activityLines = File.ReadAllLines(filePath);

                // Créez une liste d'activités à partir des lignes du fichier
                var activities = new List<ActivityModel>();

                foreach (var activityLine in activityLines)
                {
                    // Divisez chaque ligne pour obtenir les données individuelles (cours, code, ECTS, etc.)
                    var activityData = activityLine.Split(',');

                    // Assurez-vous que la ligne contient le nombre d'éléments attendu
                    if (activityData.Length == 4) // Vous avez 4 éléments dans votre modèle ActivityModel
                    {
                        // Créez une nouvelle activité à partir des données
                        var activity = new ActivityModel
                        {
                            course = activityData[0].Trim(),
                            code = activityData[1].Trim(),
                            ECTS = activityData[2].Trim(),
                            Teacher = activityData[3].Trim()
                        };

                        // Ajoutez l'activité à la liste
                        activities.Add(activity);
                    }
                    else
                    {
                        Console.WriteLine($"La ligne '{activityLine}' ne contient pas le nombre d'éléments attendu.");
                    }
                }

                // Liez la liste des activités au ListView
                ActivityListView.ItemsSource = activities;
            }
            else
            {
                // Gérez le cas où le fichier n'existe pas
            }
        }
        catch (Exception ex)
        {
            // Gérez les erreurs lors de la lecture du fichier ici
            Console.WriteLine($"Erreur lors de la lecture du fichier activitys.txt : {ex.Message}");
        }
    }

	private void OnDeleteClicked(object sender, EventArgs e)
	{
		// Récupérez l'activité associée au bouton de suppression
		var activity = (ActivityModel)((Button)sender).CommandParameter;

		// Appelez la méthode pour supprimer l'activité du fichier
		DeleteActivity(activity);

		// Mettez à jour la liste après la suppression
		LoadActivityList();
	}

	private void DeleteActivity(ActivityModel activity)
	{
		try
		{
			string filePath = "activitys.txt";

			// Lisez toutes les lignes du fichier
			var activityLines = File.ReadAllLines(filePath);

			// Filtrez les lignes pour exclure celle correspondant à l'activité à supprimer
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

					// Retournez true pour conserver la ligne si elle ne correspond pas à l'activité à supprimer
					return !existingActivity.Equals(activity);
				}
				return false;
			});

			// Écrivez les lignes mises à jour dans le fichier
			File.WriteAllLines(filePath, updatedLines);
		}
		catch (Exception ex)
		{
			// Gérez les erreurs lors de la suppression de l'activité ici
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
