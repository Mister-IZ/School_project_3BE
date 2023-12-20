namespace School.Views;

public partial class ActivityPage2 : ContentPage
{
    // Ajoutez un champ pour stocker la liste des enseignants
    private List<string> teacherList;

    public ActivityPage2()
    {
        InitializeComponent();

        // Appelez la méthode pour charger les enseignants dans le Picker
        LoadTeachersPicker();
    }

    // Méthode pour charger les enseignants dans le Picker
    private void LoadTeachersPicker()
    {
        try
        {
            string filePath = "teachers.txt";

            // Vérifiez si le fichier existe avant de tenter de le lire
            if (File.Exists(filePath))
            {
                // Lisez toutes les lignes du fichier
                var teacherLines = File.ReadAllLines(filePath);

                // Initialisez la liste des enseignants
                teacherList = new List<string>();

                foreach (var teacherLine in teacherLines)
                {
                    // Divisez chaque ligne pour obtenir les données individuelles (nom, prénom, salaire, etc.)
                    var teacherData = teacherLine.Split(',');

                    // Assurez-vous que la ligne contient le nombre d'éléments attendu
                    if (teacherData.Length == 3)
                    {
                        // Ajoutez le nom complet de l'enseignant à la liste
                        var fullName = $"{teacherData[0].Trim()} {teacherData[1].Trim()}";
                        teacherList.Add(fullName);
                    }
                    else
                    {
                        Console.WriteLine($"La ligne '{teacherLine}' ne contient pas le nombre d'éléments attendu.");
                    }
                }

                // Liez la liste des enseignants au Picker
                courseTeacherPicker.ItemsSource = teacherList;
            }
            else
            {
                // Gérez le cas où le fichier n'existe pas
            }
        }
        catch (Exception ex)
        {
            // Gérez les erreurs lors de la lecture du fichier ici
            Console.WriteLine($"Erreur lors de la lecture du fichier teachers.txt : {ex.Message}");
        }
    }

    private void OnCreateActivityClicked(object sender, EventArgs e)
    {
        var activityModel = new ActivityModel
        {
            course = courseEntered.Text,
            code = courseCode.Text,
            ECTS = courseCredits.Text,
            // Utilisez la sélection du Picker pour le nom de l'enseignant
            Teacher = courseTeacherPicker.SelectedItem?.ToString() ?? string.Empty,
        };

        var activityRepository = new ActivityRepository();
        activityRepository.SaveActivitys(activityModel);

        Navigation.PushAsync(new ActivityPage());
    }

    private void OnReturnToMainPageClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }
}
