using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditScript : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space)|| Input.GetKey(KeyCode.Escape)) {
            BackToMain();
        }
    }
    public void BackToMain()
    {
        SceneManager.LoadScene(0);
    }
}
