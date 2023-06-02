using UnityEngine;

public class MainCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //disable option tower when start game
        GameObject.FindGameObjectWithTag("TowerOption").GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
