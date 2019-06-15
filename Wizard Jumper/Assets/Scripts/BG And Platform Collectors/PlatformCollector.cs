using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollector : MonoBehaviour {
    [SerializeField]
    private GameObject panel;

    [SerializeField]
    private GameObject pauseButton;

    private void Awake()
    {
        //panel = GameObject.Find("Pause Panel");
        panel.SetActive(false);
        pauseButton.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Platform")
        {
            target.gameObject.SetActive(false);
            Destroy(target.gameObject);
        }
        if (target.tag == "Player")
        {
            Time.timeScale = 0f;
            panel.SetActive(true);
            pauseButton.SetActive(false);
        }
    }


}//class


