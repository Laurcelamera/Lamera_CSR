namespace Lamera_CSR.Data;
public class CSR
{
    public string EmployeeName { get; }
    public string Company { get; }
    public int Age { get; }
    private double[] callTimes = new double[4];

    // Constructor
    public CSR(string employeeName, string company, int age, double[] callMinutes)
    {
        EmployeeName = employeeName;
        Company = company;
        Age = age;
        Array.Copy(callMinutes, callTimes, Math.Min(callMinutes.Length, 4));
    }

    public double GetAverageCallTime()
    {
        double sum = 0;
        int count = 0;
        foreach (var time in callTimes)
        {
            sum += time;
            count++;
        }
        return count > 0 ? sum / count : 0;
    }

    public string GetMostEfficient()
    {
        double minTime = double.MaxValue;
        string efficientEmployee = "";
        for (int i = 0; i < callTimes.Length; i++)
        {
            if (callTimes[i] < minTime)
            {
                minTime = callTimes[i];
                efficientEmployee = EmployeeName;
            }
        }
        return efficientEmployee;
    }

    public string GetLeastEfficient()
    {
        double maxTime = 0;
        string inefficientEmployee = "";
        for (int i = 0; i < callTimes.Length; i++)
        {
            if (callTimes[i] > maxTime)
            {
                maxTime = callTimes[i];
                inefficientEmployee = EmployeeName;
            }
        }
        return inefficientEmployee;
    }
}