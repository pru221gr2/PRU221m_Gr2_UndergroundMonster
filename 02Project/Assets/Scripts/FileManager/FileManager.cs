using System;
using System.Collections.Generic;
using System.IO;
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


    public void ReadCSVFile(string path)
    {
        try
        {
            // Check if the file exists
            if (!File.Exists(path))
            {
                Debug.LogError("CSV file not found at path: " + path);
                return;
            }

            // Read the file
            using (StreamReader reader = new StreamReader(path))
            {
                List<string[]> csvData = new List<string[]>();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] rowData = line.Split(',');

                    csvData.Add(rowData);
                }

                // Do something with the data (e.g., process or display it)
                ProcessCSVData(csvData);
            }
        }
        catch (Exception e)
        {
            print(e.Message);
        }
        
    }

    void ProcessCSVData(List<string[]> data)
    {
        // Process or display the CSV data as needed
        foreach (string[] row in data)
        {
            foreach (string cell in row)
            {
                Debug.Log(cell);
            }
        }
    }
}
