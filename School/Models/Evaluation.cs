public class EvaluationModel
{
    public string Course { get; set; } 
    public string Student { get; set; } 
    public string Note { get; set; } 
    public string Appreciation { get; set; } 

    

    public int ConvertToNumericGrade()
    {
        if (!string.IsNullOrEmpty(Note))
        {
            switch (Note)
            {
                case "20":
                    return 20;
                case "19":
                    return 19;
                case "18":
                    return 18;
                case "17":
                    return 17;
                case "16":
                    return 16;
                case "15":
                    return 15;
                case "14":
                    return 14;
                case "13":
                    return 13;
                case "12":
                    return 12;
                case "11":
                    return 11;
                case "10":
                    return 10;
                case "9":
                    return 9;
                case "8":
                    return 8;
                case "7":
                    return 7;
                case "6":
                    return 6;
                case "5":
                    return 5;
                case "4":
                    return 4;
                case "3":
                    return 3;
                case "2":
                    return 2;
                case "1":
                    return 1;
                case "0":
                    return 0;
                default:
                    return 0;
            }
        }
        else if (!string.IsNullOrEmpty(Appreciation))
        {
            switch (Appreciation)
            {
                case "A+":
                    return 20;
                case "TB":
                    return 18;
                case "B":
                    return 12;
                case "C":
                    return 8;
                case "N":
                    return 4;
                default:
                    return 0;
            }
        }
        else
        {
            return 0;
        }
    }
}
