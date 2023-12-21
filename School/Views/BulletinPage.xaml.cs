namespace School.Views
{
    public partial class BulletinPage : ContentPage
    {
        public BulletinPage()
        {
            InitializeComponent();

            // Appelez les méthodes de chargement ici pour remplir les Picker
            LoadStudentsPicker();
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

                    // Affectez la liste des étudiants au Picker
                    studentPicker.ItemsSource = students;
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

        private void OnViewGradesClicked(object sender, EventArgs e)
        {
            var selectedStudent = studentPicker.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedStudent))
            {
                var grades = LoadStudentGrades(selectedStudent);
                DisplayGradesInUI(grades);
                var average = CalculateAverage(grades);
                averageLabel.Text = $"La moyenne générale de {selectedStudent} est de {average:F2}";
            }
            else
            {
                DisplayAlert("Sélectionnez un étudiant", "Veuillez sélectionner un étudiant avant de voir les notes.", "OK");
            }
        }

		private void OnGradeSelected(object sender, SelectedItemChangedEventArgs e)
		{
			// e.SelectedItem contient l'objet sélectionné dans la liste
			if (e.SelectedItem is EvaluationModel selectedGrade)
			{
				// Faites quelque chose avec l'objet sélectionné, par exemple affichez-le dans une autre vue/page
				// Vous pouvez également naviguer vers une autre page pour afficher les détails de l'évaluation
				Navigation.PushAsync(new EvaluationModel(selectedGrade));
			}

			// Effacez la sélection pour permettre de sélectionner à nouveau
			gradesListView.SelectedItem = null;
		}


        private List<EvaluationModel> LoadStudentGrades(string studentName)
        {
            var evaluationRepository = new EvaluationRepository();
            return evaluationRepository.GetGradesByStudent(studentName);
        }

        private void DisplayGradesInUI(List<EvaluationModel> grades)
        {
            // Ajoutez la logique pour afficher les évaluations dans l'interface utilisateur
            // Utilisez un ListView, par exemple
			gradesListView.ItemsSource = grades;
        }

        private double CalculateAverage(List<EvaluationModel> grades)
        {
            if (grades.Any())
            {
                var totalPoints = grades.Sum(grade => grade.ConvertToNumericGrade());
                return (double)totalPoints / grades.Count;
            }
            else
            {
                return 0;
            }
        }
    }
}
