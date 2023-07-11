using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
    [SerializeField]
    TMP_InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        GameObject.Find("CanvasEnterName").GetComponent<Canvas>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdatePlayerName()
    {
        GameObject.Find("PlayerNameText").GetComponent<TextMeshProUGUI>().text = inputField.text;
        Time.timeScale = 30;
        GameObject.Find("CanvasEnterName").GetComponent<Canvas>().enabled = false;
    }
}
