using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Controler controler;
    public Character character;
    public TextMeshProUGUI scoreDisplay;
    public int points = 0;

    void Awake()
    {
        if(instance != null)
            Debug.LogWarning("Multiple Game Manager");
        instance = this;
    }

    public void Lose(){
        SceneManager.LoadScene(0);
    }

    void Update(){
        scoreDisplay.text = "Score : " + points;
    }
}
