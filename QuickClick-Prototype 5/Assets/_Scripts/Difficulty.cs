using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Difficulty : MonoBehaviour
{
    
    private Button _button;
    private GameManager gameManager;

    public int difficulty;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SetDifficulty);
    }

    void SetDifficulty()
    {
        //Debug.Log(gameObject.name);
        gameManager.StartGame(difficulty);
        
    }

}
