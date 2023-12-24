namespace School.Views;

public partial class StudentPage : ContentPage
{
    public StudentPage()
    {
        InitializeComponent();

        LoadStudentList();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        LoadStudentList();
    }

    private void LoadStudentList()
    {
        try
        {
            string filePath = "students.txt";

            if (File.Exists(filePath))
            {
                var studentLines = File.ReadAllLines(filePath);

                var students = new List<StudentModel>();

                foreach (var studentLine in studentLines)
                {
                    var studentData = studentLine.Split(',');

                    if (studentData.Length >= 2)
                    {
						var student = new StudentModel
						{
							firstname = studentData[0].Trim(),
							lastname = studentData[1].Trim(),
						};


                        students.Add(student);
                    }
                    else
                    {
                        Console.WriteLine($"The line '{studentLine}' does not contain the expected number of elements.");
                    }
                }

                StudentListView.ItemsSource = students;
            }
            else
            {
                // Rien
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading students file: {ex.Message}");
        }
    }
    private void OnDeleteStudentClicked(object sender, EventArgs e)
    {
        var student = (StudentModel)((Button)sender).CommandParameter;

        DeleteStudent(student);

        LoadStudentList();
    }

    private void DeleteStudent(StudentModel student)
    {
        try
        {
            string filePath = "students.txt";

            var studentLines = File.ReadAllLines(filePath);

            var studentExists = studentLines.Any(line =>
            {
                var data = line.Split(',');
                if (data.Length >= 2) 
                {
                    var existingStudent = new StudentModel
                    {
                        firstname = data[0].Trim(),
                        lastname = data[1].Trim(),
                    };

                    return existingStudent.Equals(student);
                }
                return false;
            });

            if (studentExists)
            {
                var updatedLines = studentLines.Where(line =>
                {
                    var data = line.Split(',');
                    if (data.Length >= 2) 
                    {
                        var existingStudent = new StudentModel
                        {
                            firstname = data[0].Trim(),
                            lastname = data[1].Trim(),
                        };

                        return !existingStudent.Equals(student);
                    }
                    return false;
                });

                File.WriteAllLines(filePath, updatedLines);
            }
            else
            {
                Console.WriteLine($"L'étudiant {student.firstname} {student.lastname} n'existe pas dans le fichier.");
            }
        }
        catch (Exception ex)
        {
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
