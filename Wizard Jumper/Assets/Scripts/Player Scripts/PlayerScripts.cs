using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScripts : MonoBehaviour {

    public float jumpHigh = 13f;
    private Rigidbody2D myBody;

    private Button jumpBtn;

    private bool hasJump,platformBound;

    public delegate void MoveCamera();
    public static event MoveCamera move;

    private GameObject parent;

    private Text scoreText;
    private int score = 0;
    private Text scoreIsLoseGame;

    private void Awake()
    {
        jumpBtn = GameObject.Find("JumpButton").GetComponent<Button>();
        jumpBtn.onClick.AddListener(() => jump());
        myBody = GetComponent<Rigidbody2D>();

        scoreText = GameObject.Find("Score Text").GetComponent<Text>();
        scoreText.text = score.ToString();
        scoreIsLoseGame = GameObject.Find("scoreIsLoseGame").GetComponent<Text>();
        scoreIsLoseGame.text = score.ToString();


    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(hasJump&& myBody.velocity.y == 0)
        {
            if (!platformBound)
            {
                hasJump = false;
                transform.SetParent(parent.transform);

                score++;
                scoreText.text = score.ToString();
                scoreIsLoseGame.text = score.ToString();
                GameController.instance.createPlatform();
                if (move != null)
                {
                    move();
                }

            }
            else if (parent != null)
            {
                transform.SetParent(parent.transform);
            }
        }
       

	}
    public void jump()
    {
        if (myBody.velocity.y == 0)
        {
            myBody.velocity = new Vector2(0,jumpHigh);
            transform.SetParent(null);
            hasJump = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Platform")
        {
            parent = target.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D target)
    {
        if (target.gameObject.tag == "Platform")
        {
            parent = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "MainCamera")
        {
            platformBound = true;
        }

    }

    private void OnTriggerExit2D(Collider2D target)
    {
        if (target.tag == "MainCamera")
        {
            platformBound = false;
        }
    }



}
