namespace School.Views;

public partial class TeacherPage : ContentPage
{
    public TeacherPage()
    {
        InitializeComponent();

        // Ligne pour charger et afficher la liste des enseignants lors de la création de la page
        LoadTeachersList();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Mettez à jour la liste des enseignants chaque fois que la page devient visible
        LoadTeachersList();
    }
    // Méthode pour charger et afficher la liste des enseignants
    private void LoadTeachersList()
    {
        try
        {
            string filePath = "teachers.txt";

            // Vérifiez si le fichier existe avant de tenter de le lire
            if (File.Exists(filePath))
            {
                // Lisez toutes les lignes du fichier
                var teacherLines = File.ReadAllLines(filePath);

                // Créez une liste d'enseignants à partir des lignes du fichier
                var teachers = new List<TeacherModel>();

                foreach (var teacherLine in teacherLines)
                {
                    // Divisez chaque ligne pour obtenir les données individuelles (nom, prénom, salaire, etc.)
                    var teacherData = teacherLine.Split(',');

                    // Assurez-vous que la ligne contient le nombre d'éléments attendu
                    if (teacherData.Length == 3)
                    {
                        // Créez un nouvel enseignant à partir des données
                        var teacher = new TeacherModel
                        {
                            firstName = teacherData[0].Trim(),
                            lastName = teacherData[1].Trim(),
                            salary = teacherData[2].Trim()
                        };

                        // Ajoutez l'enseignant à la liste
                        teachers.Add(teacher);
                    }
                    else
                    {
                        Console.WriteLine($"La ligne '{teacherLine}' ne contient pas le nombre d'éléments attendu.");
                    }
                }

                // Liez la liste des enseignants au ListView
                TeachersListView.ItemsSource = teachers;
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


    private void OnReturnToMainPageClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }

    private void OnTeacherPageButtonClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new TeacherPage2());

    }
}
