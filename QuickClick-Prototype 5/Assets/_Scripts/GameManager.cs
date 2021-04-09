using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Game States
    public enum GameState
    {
        loading,
        inGame,
        gameOver
    }

    public GameState gameState;

    //Buttons
    public Button btnRestart;


    public List<GameObject> targetPrefabs;
    private float spawnTime = 1.0f; 
    private int objectsOnScreen;
    private int maxObjectsOnScreen = 1;

    //Text
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;

    //Panel
    public GameObject panelMenu;

    //Score
    private int scoreDifficulty;
    private int _score;
    public int Score {
        
        get
        {
            return _score;
        }
        
        //Define el valor del value pero siempre que este se menor que el mínimo, iguala a 0 el score
        set
        {
            //value: Es lo que hace con cualquier valor que entre, es un keyword 
            //0 es el min
            //99999 es el max 
            _score = Mathf.Clamp(value, 0, 99999);
        }

    }
    // Start is called before the first frame update
    public void StartGame(int difficulty)
    {
        gameState = GameState.inGame;

        //SetActive
        panelMenu.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);

        StartCoroutine(SpawnTarget());
        Score = 0;
        UpdateScore(0);
        scoreDifficulty = 70;
        maxObjectsOnScreen *= difficulty;

    }


    
    IEnumerator SpawnTarget()
    {

        while(gameState == GameState.inGame)
        {
            yield return new WaitForSeconds(spawnTime);

            //Increment difficulty in relation to the score 
            if (Score >= scoreDifficulty)
            {
                if (maxObjectsOnScreen <= 5)
                {
                    maxObjectsOnScreen++;
                    scoreDifficulty += 70;
                }
            }
            objectsOnScreen = Random.Range(1, maxObjectsOnScreen);
            int index;
            for (int i = 0; i < objectsOnScreen; i++)
            {
                index = Random.Range(0, targetPrefabs.Count);
                Instantiate(targetPrefabs[index]);
            }

        }

    }

    

    /// <summary>
    /// Update score and feature on the screen
    /// <summary/>
    /// <param> Score to add to the global score   <param/>
    public void UpdateScore(int scoreToAdd)
    {
        Score += scoreToAdd;
        scoreText.text = "Score: " + Score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        gameState = GameState.gameOver;
        btnRestart.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
