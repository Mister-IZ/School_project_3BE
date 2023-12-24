
public class TeacherRepository
{
    public void SaveTeachers(TeacherModel teacher) 
    {
        string filePath = "teachers.txt";
        string teacherLine = $"{teacher.firstName}, {teacher.lastName}, {teacher.salary}€";

        File.AppendAllText(filePath, teacherLine + Environment.NewLine);
    }
}
