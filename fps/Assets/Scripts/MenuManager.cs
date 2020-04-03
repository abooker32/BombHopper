using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Canvas endCanvas;
    public TMP_Text scoreText;
    public LevelManager levMan;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = ("Score: " + Mathf.Round(levMan.score * 100f));
    }

    public void PlayAgain()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
