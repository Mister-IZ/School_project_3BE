namespace School.Views;

public partial class EvaluationPage : ContentPage
{
	public EvaluationPage()
	{
		InitializeComponent();

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

				var courses = activityLines.Select(line =>
				{
					var activityData = line.Split(',');
					return activityData.Length >= 4
						? $"{activityData[0].Trim()} donné par {activityData[3].Trim()}"
						: null;
				}).Where(course => !string.IsNullOrEmpty(course)).ToList();

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

				var students = new List<string>(studentLines);

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
		var notes = new List<string>
		{
			"20", "19", "18", "17", "16", "15", "14", "13", "12", "11",
			"10", "9", "8", "7", "6", "5", "4", "3", "2", "1"
		};

		noteEnteredPicker.ItemsSource = notes;
	}

	private void LoadAppreciationsPicker()
	{
		var appreciations = new List<string> { "A+", "TB", "B", "C", "N" };

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

		if (!string.IsNullOrEmpty(selectedNote) && !string.IsNullOrEmpty(selectedAppreciation))
		{
			DisplayAlert("Erreur", "Vous ne pouvez pas sélectionner à la fois une note et une appréciation.", "OK");

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

		if (!string.IsNullOrEmpty(evaluationModel.Appreciation))
		{
			evaluationModel.Note = evaluationModel.ConvertToNumericGrade().ToString();
		}

		var evaluationRepository = new EvaluationRepository();
		evaluationRepository.SaveEvaluation(evaluationModel);

    	DisplayAlert("Succès", "Évaluation ajoutée avec succès.", "OK");

		ReloadPickers();
	}

    private void OnReturnToMainPageClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }
}

