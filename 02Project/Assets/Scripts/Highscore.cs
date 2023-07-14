using TMPro;
using UnityEngine;

public class Highscore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var dictionary = FileManager.Instance.ReadPlayerScore();
        int count = 1;
        foreach (var item in dictionary)
        {
            GameObject.Find("Player" + count).GetComponent<TextMeshProUGUI>().text = item.Key;
            GameObject.Find("Score" + count).GetComponent<TextMeshProUGUI>().text = item.Value;
            count++;
        }
    }
}
