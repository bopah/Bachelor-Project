using System.IO;
using UnityEngine;

public class CSVWriter : MonoBehaviour
{
    private string resultsFilePath;

    // Start is called before the first frame update
    void Start()
    {
        // Set the path for the results file
        resultsFilePath = Application.persistentDataPath + "/experiment_results.csv";

        // Write the header row to the CSV file
        if (!File.Exists(resultsFilePath))
        {
            File.WriteAllText(resultsFilePath, "Target,ScaleFactor,Response\n");
        }
    }

    // This function can be called from other scripts to record the response
    public void WriteToCSV(string target, float scale, bool response)
    {
        string responseText = response ? "Yes" : "No";
        string lineToWrite = $"{target},{scale:F3},{responseText}\n";
        File.AppendAllText(resultsFilePath, lineToWrite);
    }
}
