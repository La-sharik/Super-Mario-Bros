using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int world { get; private set; }
    public int stage { get; private set; }
    public int lives { get; private set; }

    private void Awake()
    {
        if (Instance != null) {
            DestroyImmediate(gameObject);
        } else  {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnDetroy()
    {
        if (Instance == this) {
            Instance = null;
        }
    }

    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        lives = 3;

        loadLevel(1, 1);
    }

    private void loadLevel(int world, int stage)
    {
        this.world = world;
        this.stage = stage;

        SceneManager.LoadScene($"{world}-{stage}");
    }

    public void NextLevel()
    {
        loadLevel(world, stage + 1);
    }

    public void ResetLevel(float delay)
    {
        Invoke(nameof(ResetLevel), delay);
    }

    public void ResetLevel()
    {
        lives--;

        if (lives > 0) {
            loadLevel(world, stage);
        } else {
            GameOver();
        }
    }

    private void GameOver()
    {
        //SceneManager.LoadScene("GameOver");
        Invoke(nameof(NewGame), 10f);
    }

}