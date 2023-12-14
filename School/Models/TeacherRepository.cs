using System;
using System.IO;
using School.Views;

public class TeacherRepository
{
    public void SaveTeachers(TeacherModel teacher) ///méthode dispo partt qui renvoie rien. Prend en param un prof de type TeacherModel appelé teacher
    {
        string filePath = "teachers.txt";
        string enseignantLine = $"{teacher.name},{teacher.course}";

        File.AppendAllText(filePath, enseignantLine + Environment.NewLine);
    }
}
