using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targetPrefabs;
    private float spawnTime = 1.0f; 
    private int objectsOnScreen = 2;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;

    private int _score;
    private int Score {
        
        get
        {
            return _score;
        }
        
        //Define el valor del value pero siempre que este se menor que el mínimo, iguala a 0 el score
        set
        {
            //value: Es lo que hace con cualquier valor que entre es un keyword 
            //0 es el min
            //99999 es el max 
            _score = Mathf.Clamp(value, 0, 99999);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
        Score = 0;
        UpdateScore(0);

    }


    
    IEnumerator SpawnTarget()
    {

        while(true)
        {
            yield return new WaitForSeconds(spawnTime);
            objectsOnScreen = Random.Range(1, 4);
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
    }
}
