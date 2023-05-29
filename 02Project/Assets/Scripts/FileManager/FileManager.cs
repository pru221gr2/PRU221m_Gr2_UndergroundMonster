using UnityEngine;
using Microsoft.Extensions.Configuration;

public class FileManager : MonoBehaviour
{
    private readonly IConfiguration builder = new ConfigurationBuilder()
            .AddJsonFile("config.json")
            .Build();
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

    public string GetValueByKey(string key)
    {
        return builder[key];
    }

}
