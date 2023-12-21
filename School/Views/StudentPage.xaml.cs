namespace School.Views;

public partial class StudentPage : ContentPage
{
    public StudentPage()
    {
        InitializeComponent();

        // Load and display the list of students when the page is created
        LoadStudentList();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Update the list of students every time the page becomes visible
        LoadStudentList();
    }

    // Method to load and display the list of students
    private void LoadStudentList()
    {
        try
        {
            string filePath = "students.txt";

            // Check if the file exists before attempting to read it
            if (File.Exists(filePath))
            {
                // Read all lines from the file
                var studentLines = File.ReadAllLines(filePath);

                // Create a list of students from the lines in the file
                var students = new List<StudentModel>();

                foreach (var studentLine in studentLines)
                {
                    // Split each line to get individual data (firstname, lastname, activities)
                    var studentData = studentLine.Split(',');

                    // Make sure the line contains the expected number of elements
                    if (studentData.Length >= 2)
                    {
                        // Create a new student from the data
						var student = new StudentModel
						{
							firstname = studentData[0].Trim(),
							lastname = studentData[1].Trim(),
						};


                        // Add the student to the list
                        students.Add(student);
                    }
                    else
                    {
                        Console.WriteLine($"The line '{studentLine}' does not contain the expected number of elements.");
                    }
                }

                // Bind the list of students to the ListView
                StudentListView.ItemsSource = students;
            }
            else
            {
                // Handle the case where the file does not exist
            }
        }
        catch (Exception ex)
        {
            // Handle errors when reading the students file here
            Console.WriteLine($"Error reading students file: {ex.Message}");
        }
    }
    private void OnDeleteStudentClicked(object sender, EventArgs e)
    {
        // Récupérez l'étudiant associé au bouton de suppression
        var student = (StudentModel)((Button)sender).CommandParameter;

        // Appelez la méthode pour supprimer l'étudiant du fichier
        DeleteStudent(student);

        // Mettez à jour la liste après la suppression
        LoadStudentList();
    }

    private void DeleteStudent(StudentModel student)
    {
        try
        {
            string filePath = "students.txt";

            // Lisez toutes les lignes du fichier
            var studentLines = File.ReadAllLines(filePath);

            // Vérifiez si l'étudiant existe déjà dans le fichier
            var studentExists = studentLines.Any(line =>
            {
                var data = line.Split(',');
                if (data.Length >= 2) // Assurez-vous que la ligne contient au moins les champs 'firstname' et 'lastname'
                {
                    var existingStudent = new StudentModel
                    {
                        firstname = data[0].Trim(),
                        lastname = data[1].Trim(),
                        // Ajoutez d'autres champs ici si nécessaire
                    };

                    return existingStudent.Equals(student);
                }
                return false;
            });

            if (studentExists)
            {
                // Filtrez les lignes pour exclure celle correspondant à l'étudiant à supprimer
                var updatedLines = studentLines.Where(line =>
                {
                    var data = line.Split(',');
                    if (data.Length >= 2) // Assurez-vous que la ligne contient au moins les champs 'firstname' et 'lastname'
                    {
                        var existingStudent = new StudentModel
                        {
                            firstname = data[0].Trim(),
                            lastname = data[1].Trim(),
                            // Ajoutez d'autres champs ici si nécessaire
                        };

                        // Retournez true pour conserver la ligne si elle ne correspond pas à l'étudiant à supprimer
                        return !existingStudent.Equals(student);
                    }
                    return false;
                });

                // Écrivez les lignes mises à jour dans le fichier
                File.WriteAllLines(filePath, updatedLines);
            }
            else
            {
                Console.WriteLine($"L'étudiant {student.firstname} {student.lastname} n'existe pas dans le fichier.");
            }
        }
        catch (Exception ex)
        {
            // Gérez les erreurs lors de la suppression de l'étudiant ici
            Console.WriteLine($"Erreur lors de la suppression de l'étudiant : {ex.Message}");
        }
    }

    private void OnStudentPageButtonClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new StudentPage2());
    }

    private void OnReturnToMainPageClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }
}
