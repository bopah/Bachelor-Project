using System.IO;
using UnityEngine;

public class CSVWriter : MonoBehaviour
{
    private string resultsFilePath;

    void Start()
    {
        resultsFilePath = Application.persistentDataPath + "/experiment_results.csv";

        // Increment filename if it already exists
        int fileCounter = 1;
        while (File.Exists(resultsFilePath))
        {
            resultsFilePath = Application.persistentDataPath + "/experiment_results" + fileCounter + ".csv";
            fileCounter++;
        }

        // Write the header row to the CSV file
        File.WriteAllText(resultsFilePath, "Target,ScaleFactor,Response\n");
    }

    public void WriteToCSV(string target, float scale, bool response)
    {
        string responseText = response ? "Faster" : "Slower";
        string lineToWrite = $"{target},{scale:F2},{responseText}\n";
        File.AppendAllText(resultsFilePath, lineToWrite);
    }
}
