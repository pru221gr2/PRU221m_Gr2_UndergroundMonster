using UnityEngine;
using UnityEngine.SceneManagement;

public class Guidance : MonoBehaviour
{
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
