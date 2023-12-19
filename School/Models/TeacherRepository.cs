
public class TeacherRepository
{
    public void SaveTeachers(TeacherModel teacher) ///méthode dispo partt qui renvoie rien. Prend en param un prof de type TeacherModel appelé teacher
    {
        string filePath = "teachers.txt";
        string teacherLine = $"{teacher.firstName}, {teacher.lastName}, {teacher.salary}€";

        File.AppendAllText(filePath, teacherLine + Environment.NewLine);
    }
}
