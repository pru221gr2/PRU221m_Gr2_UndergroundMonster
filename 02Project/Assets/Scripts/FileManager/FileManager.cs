using Assets.Scripts.FileManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class FileManager : MonoBehaviour
{
    private static FileManager instance;
    public static FileManager Instance
    {
        get
        {
            if (instance)
            {
                return instance;
            }

            instance = FindObjectOfType<FileManager>();

            if (instance)
            {
                return instance;
            }

            return instance = new GameObject(nameof(FileManager), typeof(FileManager))
                .AddComponent<FileManager>();
        }
    }

    private void Awake()
    {
        if (instance && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    private IList<string[]> ReadCSVFile(string path)
    {
        try
        {
            // Check if the file exists
            if (!File.Exists(path))
            {
                Debug.LogError("CSV file not found at path: " + path);
                return null;
            }

            // Read the file
            using (StreamReader reader = new StreamReader(path))
            {
                IList<string[]> csvData = new List<string[]>();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] rowData = line.Split(',');

                    csvData.Add(rowData);
                }

                return csvData;
            }
        }
        catch (Exception e)
        {
            print(e.Message);
        }
        return null;
    }

    public IDictionary<string, EnemyData> ReadEnemyConfig()
    {
        var data = ReadCSVFile(Path.Combine(UnityEngine.Windows.Directory.localFolder, "enemy.csv"));

        if (data is null || !data.Any())
        {
            return null;
        }
        try
        {
            // Process or display the CSV data as needed
            IDictionary<string, EnemyData> keyValuePairs = new Dictionary<string, EnemyData>();

            foreach (string[] row in data)
            {

                keyValuePairs.Add(row[0].ToString(),
                    new EnemyData(
                        float.Parse(row[1].ToString()),
                        float.Parse(row[2].ToString()),
                        float.Parse(row[3].ToString()),
                        float.Parse(row[4].ToString())));

            }
            return keyValuePairs;
        }
        catch (Exception e)
        {
            print(e.Message);
        }
        return null;
    }

    public IDictionary<string, string> ReadPlayerScore()
    {
        var data = ReadCSVFile(Path.Combine(UnityEngine.Windows.Directory.localFolder, "score.csv"));

        if (data is null || !data.Any())
        {
            return null;
        }
        try
        {
            // Process or display the CSV data as needed
            IDictionary<string, string> keyValuePairs = new Dictionary<string, string>();

            foreach (string[] row in data)
            {
                keyValuePairs.Add(row[0].ToString(),
                   row[1].ToString());
            }
            return keyValuePairs;
        }
        catch (Exception e)
        {
            print(e.Message);
        }
        return null;
    }

    public void WriteDictionaryToCsv(Dictionary<string, string> dictionary, string filePath)
    {
        using (var writer = new StreamWriter(filePath))
        {
            foreach (var item in dictionary)
            {
                writer.WriteLine($"{EscapeCsvField(item.Key)},{EscapeCsvField(item.Value.ToString())}");
            }
        }
    }

    private string EscapeCsvField(string field)
    {
        if (string.IsNullOrEmpty(field))
        {
            return string.Empty;
        }

        if (field.Contains(",") || field.Contains("\"") || field.Contains("\n"))
        {
            field = field.Replace("\"", "\"\"");
            field = $"\"{field}\"";
        }

        return field;
    }

    public void WritePlayerScore(string playerName, string playerScore)
    {
        try
        {
            string filePath = Path.Combine(UnityEngine.Windows.Directory.localFolder, "score.csv");
            var playerScores = ReadPlayerScore();

            if (string.IsNullOrWhiteSpace(playerName))
            {
                playerName = "Unknown";
            }

            if (string.IsNullOrWhiteSpace(playerScore))
            {
                playerScore = "0";
            }

            if (playerScores.Count >= 5)
            {
                for (int i = 5; i < playerScores.Count; i++)
                {
                    var key = playerScores.ElementAt(i).Key;
                    if (!string.IsNullOrWhiteSpace(key))
                    {
                        playerScores.Remove(key);
                    }
                }
            }

            playerScores.Add(playerName, playerScore);

            var playerScoreSort = from score in playerScores
                                  orderby Convert.ToInt32(score.Value) ascending
                                  select score;

            WriteDictionaryToCsv(playerScoreSort.ToDictionary(pair => pair.Key, pair => pair.Value), filePath);
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);    
        }
        
    }
}
