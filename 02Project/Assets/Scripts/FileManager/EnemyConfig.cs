using UnityEngine;

public class EnemyConfig : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var data = FileManager.Instance.ReadEnemyConfig();
        print(data["Lv1"].Health);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
