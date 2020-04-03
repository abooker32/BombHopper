using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public int difficulty;
    public float score;
    public bool playing;
    public Canvas gOver;
    public TMP_Text scoreText;
 
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if (sceneName == "EasyMode")
        {
            difficulty = 1;
        }
        else if (sceneName == "NormalMode")
        {
            difficulty = 2;
        }
        else if (sceneName == "HardMode")
        {
            difficulty = 3;
        }

        playing = true;
        score = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (playing)
        {
            score += Time.deltaTime;
            scoreText.text = ("Score: " + Mathf.Round((score * 1000f) * .01f));
        }      
    }

    public void EndGame()
    {
        playing = false;
        gOver.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
