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
                spawnTimer.Duration = Random.Range(8, 10);
                spawnTimer.Run();
            }
        }
        else
        {
            //if this wave is finished, check if all monsters are dead. If yes then forward to the next
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                //stop and start timer
                SpawnEnemy(RandomEnemy());
                spawnTimer.Stop();
                spawnTimer.Duration = Random.Range(1, 5);
                spawnTimer.Run();

                //moi wave hien tai chi tang mau cua quai
                wave++;
                DisplayWaveText();
                IncreaseEnemyHealth();
                waveTimer.Run();
            }
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
                SetInstantiatedEnemy(enemy1, enemy);
                var move1 = enemy1.GetComponent<EnemyMovement>();
                move1.Waypoints = GameObject.Find("Waypoints").GetComponent<Waypoints>().Waypoints1;
                break;
            case 1:
                var enemy2 = Instantiate(enemy, spawnPoint2.position, Quaternion.identity);
                SetInstantiatedEnemy(enemy2, enemy);
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
            if (enemy.name.Contains("Bot1")) enemy.GetComponent<EnemyBot1>().Health *= 1.5f;
            if (enemy.name.Contains("Bot2")) enemy.GetComponent<EnemyBot2>().Health *= 1.5f;
            if (enemy.name.Contains("Bot3")) enemy.GetComponent<EnemyBot3>().Health *= 1.5f;
            if (enemy.name.Contains("Bot4")) enemy.GetComponent<EnemyBot4>().Health *= 1.5f;
            if (enemy.name.Contains("Bot5")) enemy.GetComponent<EnemyBot5>().Health *= 1.5f;
            if (enemy.name.Contains("Bot6")) enemy.GetComponent<EnemyBot6>().Health *= 1.5f;
        }
    }

    void InitListEnemy()
    {
        foreach (var enemy in Enemies)
        {
            if (enemy.name.Contains("Bot1")) enemy.GetComponent<EnemyBot1>().Init(null);
            if (enemy.name.Contains("Bot2")) enemy.GetComponent<EnemyBot2>().Init(null);
            if (enemy.name.Contains("Bot3")) enemy.GetComponent<EnemyBot3>().Init(null);
            if (enemy.name.Contains("Bot4")) enemy.GetComponent<EnemyBot4>().Init(null);
            if (enemy.name.Contains("Bot5")) enemy.GetComponent<EnemyBot5>().Init(null);
            if (enemy.name.Contains("Bot6")) enemy.GetComponent<EnemyBot6>().Init(null);
        }
    }

    void SetInstantiatedEnemy(GameObject instantiateEnemy, GameObject prefab)
    {
        if (instantiateEnemy.name.Contains("Bot1")) instantiateEnemy.GetComponent<EnemyBot1>().Init(prefab);
        if (instantiateEnemy.name.Contains("Bot2")) instantiateEnemy.GetComponent<EnemyBot2>().Init(prefab);
        if (instantiateEnemy.name.Contains("Bot3")) instantiateEnemy.GetComponent<EnemyBot3>().Init(prefab);
        if (instantiateEnemy.name.Contains("Bot4")) instantiateEnemy.GetComponent<EnemyBot4>().Init(prefab);
        if (instantiateEnemy.name.Contains("Bot5")) instantiateEnemy.GetComponent<EnemyBot5>().Init(prefab);
        if (instantiateEnemy.name.Contains("Bot6")) instantiateEnemy.GetComponent<EnemyBot6>().Init(prefab);
    }
}
