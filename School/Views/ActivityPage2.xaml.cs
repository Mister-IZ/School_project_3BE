namespace School.Views;

public partial class ActivityPage2 : ContentPage
{

    public ActivityPage2()
    {
        InitializeComponent();

        LoadTeachersPicker();
    }

    private void LoadTeachersPicker()
    {
        try
        {
            string filePath = "teachers.txt";

            if (File.Exists(filePath))
            {
                var teacherLines = File.ReadAllLines(filePath);

                var uniqueTeachers = new HashSet<string>();

                foreach (var teacherLine in teacherLines)
                {
                    var teacherData = teacherLine.Split(',');

                    if (teacherData.Length == 3)
                    {
                        var fullName = $"{teacherData[0].Trim()} {teacherData[1].Trim()}";
                        uniqueTeachers.Add(fullName);
                    }
                    else
                    {
                        Console.WriteLine($"La ligne '{teacherLine}' ne contient pas le nombre d'éléments attendu.");
                    }
                }

                courseTeacherPicker.ItemsSource = uniqueTeachers.ToList();
            }
            else
            {
                //Rien
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors de la lecture du fichier teachers.txt : {ex.Message}");
        }
    }


    private void OnCreateActivityClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(courseTeacherPicker.SelectedItem?.ToString()))
        {
            DisplayAlert("Erreur", "Vous devez sélectionner un professeur pour créer une matière.", "OK");
            return; 
        }

        var activityModel = new ActivityModel
        {
            course = courseEntered.Text,
            code = courseCode.Text,
            ECTS = courseCredits.Text,
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
