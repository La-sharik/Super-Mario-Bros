using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int world { get; private set; }
    public int stage { get; private set; }
    public int lives { get; private set; }
    public int coins { get; private set; }
    public int stars { get; private set; }
    public int goomba { get; private set; }
    public int koopa { get; private set; }
    public int mushrooms { get; private set; }

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
        Application.targetFrameRate = 60;
        
        NewGame();
    }

    public void NewGame()
    {
        lives = 3;
        coins = 0;
        stars = 0;
        mushrooms = 0;
        goomba = 0;
        koopa = 0;
        SetScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void loadLevel(int world, int stage)
    {
        this.world = world;
        this.stage = stage;

        SceneManager.LoadScene($"{world}-{stage}");
    }
    
    public void Restart() {
        NewGame();
        loadLevel(this.world,this.stage);
    }

    public void NextLevel() {
        this.world = world;
        this.stage = stage;
        if (stage + 1 == 4) {
            SceneManager.LoadScene("Game Passed");
            Invoke(nameof(GamePassed), 3f);
        } else 
        {
            loadLevel(world, stage + 1);
        }
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
        lives = 3;
        SceneManager.LoadScene("Game Over");
        Invoke(nameof(GamePassed), 3f);
    }

    private void GamePassed()
    {
        lives = 3;
        SceneManager.LoadScene("Menu");
    }

    public void AddCoin()
    {
        coins++;
        if (coins == 100) {
            AddLives();
            coins = 0;
        }
    } 

    public void AddLives()
    {
        lives++;
    }
        
    public void AddMushroom()
    {
        mushrooms++;
    }

    public void AddStar()
    {
        stars++;
    }

    public void AddGoomba()
    {
        goomba++;
    }

    public void AddKoopa()
    {
        koopa++;
    }

    public void SetScene(int scene) {
         if (scene % 3 == 0) {
            this.world =scene / 3;
            this.stage = 3;
        } else {
            this.world = scene / 3 + 1;
            this.stage = scene % 3;
        }
    }
}