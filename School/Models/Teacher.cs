public class TeacherModel
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string salary { get; set; }

    // Méthode Equals pour comparer deux objets TeacherModel
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        TeacherModel otherTeacher = (TeacherModel)obj;
        return firstName == otherTeacher.firstName
            && lastName == otherTeacher.lastName
            && salary == otherTeacher.salary;
    }

    // Méthode GetHashCode pour obtenir un code de hachage basé sur les propriétés de l'objet
    public override int GetHashCode()
    {
        unchecked // Permet à un dépassement de se produire sans provoquer d'exceptions
        {
            int hash = 17;
            hash = hash * 23 + (firstName != null ? firstName.GetHashCode() : 0);
            hash = hash * 23 + (lastName != null ? lastName.GetHashCode() : 0);
            hash = hash * 23 + (salary != null ? salary.GetHashCode() : 0);
            return hash;
        }
    }
}
