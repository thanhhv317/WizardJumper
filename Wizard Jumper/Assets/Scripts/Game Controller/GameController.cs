using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static GameController instance;

    [SerializeField]
    private GameObject platform;

    private float DISTANCE_BETWEEN_PLATFORM = 7f;
    private int countPlatform;
    private float lastPlatformPosisionY;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        createPlatform();
    }

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDisable()
    {
        instance = null;
    }
    
    public void createPlatform()
    {
        lastPlatformPosisionY += DISTANCE_BETWEEN_PLATFORM;

        GameObject newPlatform = Instantiate(platform);
        newPlatform.transform.position = new Vector3(0, lastPlatformPosisionY, 0);
        newPlatform.name = "Platform " + countPlatform;

        countPlatform++;
    }

    public void _restartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void _exitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    } 


}//class
















