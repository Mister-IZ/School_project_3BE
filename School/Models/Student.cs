public class StudentModel
{
    public string firstname { get; set; }
    public string lastname { get; set; }

    // Change the property type to List<string> to store selected activities
    public List<string> SelectedActivities { get; set; } = new List<string>();
}
