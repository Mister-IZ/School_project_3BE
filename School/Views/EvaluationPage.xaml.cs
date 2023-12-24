namespace School.Views;

public partial class EvaluationPage : ContentPage
{
	public EvaluationPage()
	{
		InitializeComponent();

		// Appelez les méthodes de chargement ici pour remplir les Picker
        LoadCoursesPicker();
        LoadStudentsPicker();
        LoadNotesPicker();
        LoadAppreciationsPicker();
	}
	private void LoadCoursesPicker()
	{
		try
		{
			string filePath = "activitys.txt";

			if (File.Exists(filePath))
			{
				var activityLines = File.ReadAllLines(filePath);

				// Supposons que chaque ligne du fichier d'activités représente un cours
				var courses = activityLines.Select(line =>
				{
					var activityData = line.Split(',');
					return activityData.Length >= 4
						? $"{activityData[0].Trim()} donné par {activityData[3].Trim()}"
						: null;
				}).Where(course => !string.IsNullOrEmpty(course)).ToList();

				// Affectez la liste des cours à la source de données du Picker
				courseNamePicker.ItemsSource = courses;
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Erreur lors de la lecture du fichier d'activités : {ex.Message}");
		}
	}


	private void LoadStudentsPicker()
	{
		try
		{
			string filePath = "students.txt";

			if (File.Exists(filePath))
			{
				var studentLines = File.ReadAllLines(filePath);

				// Supposons que chaque ligne du fichier d'étudiants représente un étudiant
				var students = new List<string>(studentLines);

				// Affectez la liste des étudiants à la source de données du Picker
				studentNamePicker.ItemsSource = students;
			}
			else
			{
				Console.WriteLine("Le fichier d'étudiants n'existe pas.");
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Erreur lors de la lecture du fichier d'étudiants : {ex.Message}");
		}
	}

	private void LoadNotesPicker()
	{
		// Utilisez votre liste préfaite pour les notes
		var notes = new List<string>
		{
			"20", "19", "18", "17", "16", "15", "14", "13", "12", "11",
			"10", "9", "8", "7", "6", "5", "4", "3", "2", "1"
		};

		// Affectez la liste des notes à la source de données du Picker
		noteEnteredPicker.ItemsSource = notes;
	}

	private void LoadAppreciationsPicker()
	{
		// Utilisez votre liste préfaite pour les appréciations
		var appreciations = new List<string> { "A+", "TB", "B", "C", "N" };

		// Affectez la liste des appréciations à la source de données du Picker
		appreciationEnteredPicker.ItemsSource = appreciations;
	}

	private void ReloadPickers()
	{
		LoadCoursesPicker();
		LoadStudentsPicker();
		LoadNotesPicker();
		LoadAppreciationsPicker();
	}

	private void OnCreateEvaluationClicked(object sender, EventArgs e)
	{
		var selectedNote = noteEnteredPicker.SelectedItem?.ToString();
		var selectedAppreciation = appreciationEnteredPicker.SelectedItem?.ToString();

		// Vérifiez si à la fois une note et une appréciation sont sélectionnées
		if (!string.IsNullOrEmpty(selectedNote) && !string.IsNullOrEmpty(selectedAppreciation))
		{
			// Affichez un message d'erreur et quittez la méthode
			DisplayAlert("Erreur", "Vous ne pouvez pas sélectionner à la fois une note et une appréciation.", "OK");

			// Rechargez la page pour vider les champs
			ReloadPickers();
			return;
		}

		var evaluationModel = new EvaluationModel
		{
			Student = studentNamePicker.SelectedItem?.ToString() ?? string.Empty,
			Course = courseNamePicker.SelectedItem?.ToString() ?? string.Empty,
		};

		if (!string.IsNullOrEmpty(selectedNote))
		{
			evaluationModel.Note = selectedNote;
		}
		else if (!string.IsNullOrEmpty(selectedAppreciation))
		{
			evaluationModel.Appreciation = selectedAppreciation;
		}

		// Convertissez l'appréciation en note numérique si nécessaire
		if (!string.IsNullOrEmpty(evaluationModel.Appreciation))
		{
			evaluationModel.Note = evaluationModel.ConvertToNumericGrade().ToString();
		}

		var evaluationRepository = new EvaluationRepository();
		evaluationRepository.SaveEvaluation(evaluationModel);

		// Ajoutez la logique pour afficher un message de succès ou naviguer vers une autre page si nécessaire
    	DisplayAlert("Succès", "Évaluation ajoutée avec succès.", "OK");

		// Rechargez les pickers pour vider les champs
		ReloadPickers();
	}

    private void OnReturnToMainPageClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }
}

