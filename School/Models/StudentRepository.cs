
public class StudentRepository : ContentPage
{
	public void SaveStudents(StudentModel student) 
    {
        string filePath = "students.txt";
        string studentLine = $"{student.name}";

        File.AppendAllText(filePath, studentLine + Environment.NewLine);
    }
}