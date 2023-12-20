
public class ActivityRepository : ContentPage
{
	public void SaveActivitys(ActivityModel activity) 
    {
        string filePath = "activitys.txt";
        string activityLine = $"{activity.course}, {activity.code}, {activity.ECTS}, {activity.Teacher}";

        File.AppendAllText(filePath, activityLine + Environment.NewLine);
    }
}