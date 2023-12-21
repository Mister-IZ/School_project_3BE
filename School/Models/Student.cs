public class StudentModel
{
    public string firstname { get; set; }
    public string lastname { get; set; }

    // Ajoutez d'autres propriétés si nécessaire

    // Méthode Equals pour comparer deux objets StudentModel
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        StudentModel otherStudent = (StudentModel)obj;
        return firstname == otherStudent.firstname
            && lastname == otherStudent.lastname
            // Ajoutez d'autres comparaisons si nécessaire
            ;
    }

    // Méthode GetHashCode pour obtenir un code de hachage basé sur les propriétés de l'objet
    public override int GetHashCode()
    {
        unchecked // Permet à un dépassement de se produire sans provoquer d'exceptions
        {
            int hash = 17;
            hash = hash * 23 + (firstname != null ? firstname.GetHashCode() : 0);
            hash = hash * 23 + (lastname != null ? lastname.GetHashCode() : 0);
            // Ajoutez d'autres propriétés si nécessaire
            return hash;
        }
    }
}

