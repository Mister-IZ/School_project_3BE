namespace School.Views
{
    public partial class BulletinPage : ContentPage
    {
        private BulletinViewModel viewModel;

        public BulletinPage()
        {
            InitializeComponent();
            viewModel = new BulletinViewModel();
            BindingContext = viewModel;

            LoadStudentsPicker();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            LoadStudentsPicker();
        }

        private void LoadStudentsPicker()
        {
            try
            {
                string filePath = "evaluations.txt";

                if (File.Exists(filePath))
                {
                    var studentLines = File.ReadAllLines(filePath);
                    var studentNames = new List<string>();

                    foreach (var line in studentLines)
                    {
                        var studentInfo = line.Split(',');

                        if (studentInfo.Length >= 3) 
                        {
                            var studentFullName = $"{studentInfo[1].Trim()}, {studentInfo[2].Trim()}";
                            
                            if (!studentNames.Contains(studentFullName))
                            {
                                studentNames.Add(studentFullName);
                            }
                        }
                    }

                    studentPicker.ItemsSource = studentNames;
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



        private void OnViewBulletinClicked(object sender, EventArgs e)
        {
            var selectedStudent = studentPicker.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedStudent))
            {
                viewModel.ClearGrades(); 

                try
                {
                    string filePath = "evaluations.txt";

                    if (File.Exists(filePath))
                    {
                        var studentLines = File.ReadAllLines(filePath);

                        foreach (var line in studentLines)
                        {
                            var studentInfo = line.Split(',');

                            if (studentInfo.Length >= 3) 
                            {
                                var studentFullName = $"{studentInfo[1].Trim()}, {studentInfo[2].Trim()}";

                                if (selectedStudent.Equals(studentFullName))
                                {
                                    var grade = new EvaluationModel
                                    {
                                        Course = studentInfo[0].Trim(),
                                        Student = studentFullName,
                                        Note = studentInfo[3].Trim(),
                                        Appreciation = studentInfo.Length > 4 ? studentInfo[4].Trim() : string.Empty
                                    };

                                    viewModel.AddGrade(grade);
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Le fichier d'évaluations n'existe pas.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur lors de la lecture du fichier d'évaluations : {ex.Message}");
                }
            }
            else
            {
                DisplayAlert("Erreur", "Veuillez sélectionner un étudiant.", "OK");
            }
        }
    }
}
