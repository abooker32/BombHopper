using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Canvas controlCanvas;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    public void EasyMode()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void NormalMode()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void HardMode()
    {
        SceneManager.LoadSceneAsync(3);
    }

    public void OpenControls()
    {
        controlCanvas.gameObject.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
