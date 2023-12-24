namespace School.Views;

public partial class TeacherPage : ContentPage
{
    public TeacherPage()
    {
        InitializeComponent();

        LoadTeachersList();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        LoadTeachersList();
    }
    private void LoadTeachersList()
    {
        try
        {
            string filePath = "teachers.txt";

            if (File.Exists(filePath))
            {
                var teacherLines = File.ReadAllLines(filePath);

                var teachers = new List<TeacherModel>();

                foreach (var teacherLine in teacherLines)
                {
                    var teacherData = teacherLine.Split(',');

                    if (teacherData.Length == 3)
                    {
                        var existingTeacher = teachers.FirstOrDefault(t =>
                            t.firstName == teacherData[0].Trim() &&
                            t.lastName == teacherData[1].Trim() &&
                            t.salary == teacherData[2].Trim());

                        if (existingTeacher == null)
                        {
                            var teacher = new TeacherModel
                            {
                                firstName = teacherData[0].Trim(),
                                lastName = teacherData[1].Trim(),
                                salary = teacherData[2].Trim()
                            };

                            teachers.Add(teacher);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"La ligne '{teacherLine}' ne contient pas le nombre d'éléments attendu.");
                    }
                }

                TeachersListView.ItemsSource = teachers;
            }
            else
            {
                // Rien
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors de la lecture du fichier teachers.txt : {ex.Message}");
        }
    }


    private void OnDeleteClicked(object sender, EventArgs e)
    {
        // Récupérez l'activité associée au bouton de suppression
        var teacher = (TeacherModel)((Button)sender).CommandParameter;

        // Appelez la méthode pour supprimer l'activité du fichier
        DeleteTeacher(teacher);

        // Mettez à jour la liste après la suppression
        LoadTeachersList();
    }
    private void DeleteTeacher(TeacherModel teacher)
{
    try
    {
        string filePath = "teachers.txt";

        // Lisez toutes les lignes du fichier
        var teacherLines = File.ReadAllLines(filePath);

        // Vérifiez si l'enseignant existe déjà dans le fichier
        var teacherExists = teacherLines.Any(line =>
        {
            var data = line.Split(',');
            if (data.Length == 3)
            {
                var existingTeacher = new TeacherModel
                {
                    firstName = data[0].Trim(),
                    lastName = data[1].Trim(),
                    salary = data[2].Trim()
                };

                return existingTeacher.Equals(teacher);
            }
            return false;
        });

        if (teacherExists)
        {
            // Filtrez les lignes pour exclure celle correspondant à l'enseignant à supprimer
            var updatedLines = teacherLines.Where(line =>
            {
                var data = line.Split(',');
                if (data.Length == 3)
                {
                    var existingTeacher = new TeacherModel
                    {
                        firstName = data[0].Trim(),
                        lastName = data[1].Trim(),
                        salary = data[2].Trim()
                    };

                    // Retournez true pour conserver la ligne si elle ne correspond pas à l'enseignant à supprimer
                    return !existingTeacher.Equals(teacher);
                }
                return false;
            });

            // Écrivez les lignes mises à jour dans le fichier
            File.WriteAllLines(filePath, updatedLines);
        }
        else
        {
            Console.WriteLine($"L'enseignant {teacher.firstName} {teacher.lastName} n'existe pas dans le fichier.");
        }
    }
    catch (Exception ex)
    {
        // Gérez les erreurs lors de la suppression de l'enseignant ici
        Console.WriteLine($"Erreur lors de la suppression de l'enseignant : {ex.Message}");
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
