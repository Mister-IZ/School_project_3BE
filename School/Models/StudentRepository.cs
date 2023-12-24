public class StudentRepository : ContentPage
{
	public void SaveStudents(StudentModel student) 
    {
        string filePath = "students.txt";
        string studentLine = $"{student.firstname}, {student.lastname}";

        File.AppendAllText(filePath, studentLine + Environment.NewLine);
    }
}