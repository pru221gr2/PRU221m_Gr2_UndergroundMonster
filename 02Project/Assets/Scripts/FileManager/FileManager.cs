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
                        float.Parse(row[2].ToString())));

            }
            return keyValuePairs;
        }
        catch (Exception e)
        {
            print(e.Message);
        }
        return null;
    }
}
