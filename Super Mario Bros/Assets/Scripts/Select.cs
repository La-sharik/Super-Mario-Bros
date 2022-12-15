using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Select : MonoBehaviour
{
    public void Scenes(int numberScenes)
    {
        SceneManager.LoadScene(numberScenes);
        if (GameManager.Instance != null) {
            GameManager.Instance.SetScene(numberScenes);
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
