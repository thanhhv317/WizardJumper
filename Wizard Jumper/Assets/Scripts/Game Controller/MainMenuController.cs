using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	public void _playGame()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void _quitGame()
    {
        Application.Quit();
    }
}
