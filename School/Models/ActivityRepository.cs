
public class ActivityRepository : ContentPage
{
	public void SaveActivitys(ActivityModel activity) 
    {
        string filePath = "activitys.txt";
        string activityLine = $"{activity.course}, Code: {activity.code}, ECTS: {activity.ECTS}, Teacher: {activity.Teacher}";

        File.AppendAllText(filePath, activityLine + Environment.NewLine);
    }
}