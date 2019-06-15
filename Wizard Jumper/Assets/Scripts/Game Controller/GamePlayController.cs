using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : MonoBehaviour {


    [SerializeField]
    private GameObject pauseButton, pause;


    // Use this for initialization
    void Start () {
        pause.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void _pauseGame()
    {
        Time.timeScale = 0f;
        pause.SetActive(true);
        pauseButton.SetActive(false);
    }
    public void _resumeGame()
    {
        Time.timeScale = 1f;
        pause.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void _restartGame()
    {
        Application.LoadLevel("GamePlay");
        Time.timeScale = 1f;
        pause.SetActive(false);
        pauseButton.SetActive(true);
    }
    public void _quitGame()
    {
        Application.LoadLevel("MainMenu");
        Time.timeScale = 1f;
        pause.SetActive(false);
        pauseButton.SetActive(true);
    }
}
