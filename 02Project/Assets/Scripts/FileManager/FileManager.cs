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

}
