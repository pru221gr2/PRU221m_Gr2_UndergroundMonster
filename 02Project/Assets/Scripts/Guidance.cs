using UnityEngine;
using UnityEngine.SceneManagement;

public class Guidance : MonoBehaviour
{
    public void BackToMainMenu()
    {
        Collect.countCoin = 1000;
        Collect.countTrophy = 0;
        if(HealthBarBase.Instance != null)
        {
            HealthBarBase.Instance.currentHealth = HealthBarBase.Instance.maxHealth;
        }
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }

    public void Replay()
    {
        Collect.countCoin = 1000;
        Collect.countTrophy = 0;
        HealthBarBase.Instance.currentHealth = HealthBarBase.Instance.maxHealth;
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("New Map");
    }
}
