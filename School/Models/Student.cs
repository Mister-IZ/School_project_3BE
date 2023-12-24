public class StudentModel
{
    public string firstname { get; set; }
    public string lastname { get; set; }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        StudentModel otherStudent = (StudentModel)obj;
        return firstname == otherStudent.firstname
            && lastname == otherStudent.lastname
            ;
    }

    public override int GetHashCode()
    {
        unchecked 
        {
            int hash = 17;
            hash = hash * 23 + (firstname != null ? firstname.GetHashCode() : 0);
            hash = hash * 23 + (lastname != null ? lastname.GetHashCode() : 0);
            return hash;
        }
    }
}

