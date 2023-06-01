using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> Enemies = new List<GameObject>();
    Timer spawnTimer;
    Timer waveTimer;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    int wave = 1;
    int waveDuration = 30;
    int spawnDuration = 3;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = spawnDuration;
        spawnTimer.Run();

        waveTimer = gameObject.AddComponent<Timer>();
        waveTimer.Duration = waveDuration;
        waveTimer.Run();

        DisplayWaveText();
        InitListEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        //if still in this wave
        if (!waveTimer.Finished)
        {
            //neu can co the check dieu kien va spawn boss o wave nao do
            //hien tai chi spawn quai bthg
            if (spawnTimer.Finished)
            {
                SpawnEnemy(RandomEnemy());
                spawnTimer.Duration = Random.Range(1, 6);
                spawnTimer.Run();
            }
        }
        else
        {
            //stop and start timer
            spawnTimer.Stop();
            spawnTimer.Duration = Random.Range(1, 6);
            spawnTimer.Run();

            wave++;
            DisplayWaveText();
            IncreaseEnemyHealth();
            waveTimer.Run();
        }
    }

    GameObject RandomEnemy()
    {
        int randomBot = Random.Range(0, 6);
        return Enemies[randomBot];
    }

    void SpawnEnemy(GameObject enemy)
    {
        int randomSpawnPoint = Random.Range(0, 2);
        switch (randomSpawnPoint)
        {
            case 0:
                var enemy1 = Instantiate(enemy, spawnPoint1.position, Quaternion.identity);
                var move1 = enemy1.GetComponent<EnemyMovement>();
                move1.Waypoints = GameObject.Find("Waypoints").GetComponent<Waypoints>().Waypoints1;
                break;
            case 1:
                var enemy2 = Instantiate(enemy, spawnPoint2.position, Quaternion.identity);
                var move2 = enemy2.GetComponent<EnemyMovement>();
                move2.Waypoints = GameObject.Find("Waypoints").GetComponent<Waypoints>().Waypoints2;
                break;
        }
    }

    void DisplayWaveText()
    {
        EnableCanvasWave(wave);
        Invoke("DisableCanvasWave", 3);
    }
    void EnableCanvasWave(int wave)
    {
        var canvas = GameObject.Find("CanvasWave").GetComponent<Canvas>();
        GameObject.Find("WaveText").GetComponent<TextMeshProUGUI>().text = $"Wave {wave}";
        canvas.GetComponent<Canvas>().enabled = true;
    }
    void DisableCanvasWave()
    {
        var canvas = GameObject.Find("CanvasWave").GetComponent<Canvas>();
        canvas.GetComponent<Canvas>().enabled = false;
    }

    void IncreaseEnemyHealth()
    {
        foreach (var enemy in Enemies)
        {
            if (enemy.name.Contains("Bot1")) enemy.GetComponent<EnemyBot1>().Health *= 0.5f;
            if (enemy.name.Contains("Bot2")) enemy.GetComponent<EnemyBot2>().Health *= 0.5f;
            if (enemy.name.Contains("Bot3")) enemy.GetComponent<EnemyBot3>().Health *= 0.5f;
            if (enemy.name.Contains("Bot4")) enemy.GetComponent<EnemyBot4>().Health *= 0.5f;
            if (enemy.name.Contains("Bot5")) enemy.GetComponent<EnemyBot5>().Health *= 0.5f;
            if (enemy.name.Contains("Bot6")) enemy.GetComponent<EnemyBot6>().Health *= 0.5f;
        }
    }

    void InitListEnemy()
    {
        foreach (var enemy in Enemies)
        {
            if (enemy.name.Contains("Bot1")) enemy.GetComponent<EnemyBot1>().Init();
            if (enemy.name.Contains("Bot2")) enemy.GetComponent<EnemyBot2>().Init();
            if (enemy.name.Contains("Bot3")) enemy.GetComponent<EnemyBot3>().Init();
            if (enemy.name.Contains("Bot4")) enemy.GetComponent<EnemyBot4>().Init();
            if (enemy.name.Contains("Bot5")) enemy.GetComponent<EnemyBot5>().Init();
            if (enemy.name.Contains("Bot6")) enemy.GetComponent<EnemyBot6>().Init();
        }
    }
}
