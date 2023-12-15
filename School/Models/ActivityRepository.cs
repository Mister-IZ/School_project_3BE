
public class ActivityRepository : ContentPage
{
	public void SaveActivitys(ActivityModel activity) 
    {
        string filePath = "activitys.txt";
        string activityLine = $"{activity.course}";

        File.AppendAllText(filePath, activityLine + Environment.NewLine);
    }
}