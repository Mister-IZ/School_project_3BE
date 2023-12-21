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
							SelectedActivities = studentData.Skip(2).Select(a => a.Trim()).ToList()
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

    private void OnStudentPageButtonClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new StudentPage2());
    }

    private void OnReturnToMainPageClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }
}
