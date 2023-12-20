public class ActivityModel
{
    public string course { get; set; }
    public string code { get; set; }
    public string ECTS { get; set; }
    public string Teacher { get; set; }

    public override bool Equals(object obj)
    {
        if (obj is ActivityModel other)
        {
            // Comparez les propriétés individuelles au lieu des références d'objets
            return course == other.course
                && code == other.code
                && ECTS == other.ECTS
                && Teacher == other.Teacher;
        }

        return false;
    }

    public override int GetHashCode()
    {
        // Implémentez GetHashCode pour éviter les avertissements du compilateur
        return HashCode.Combine(course, code, ECTS, Teacher);
    }
}
