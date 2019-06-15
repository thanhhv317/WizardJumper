using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    private float boundLeft = -3.2f;
    private float boundRight = 3.2f;

    private float speed = 2f;
    private bool left;

	// Use this for initialization
	void Awake () {
        RandomizeMovement();
	}
	
	// Update is called once per frame
	void Update () {
        move();
	}

    private void RandomizeMovement()
    {
        if (Random.Range(0, 2) == 0)
        {
            left = true;
        }
        else
        {
            left = false;
        }
    }
    private void move()
    {
        if (left)
        {
            Vector3 tmp = transform.position;
            tmp.x -= speed * Time.deltaTime;
            transform.position = tmp;
            if (transform.position.x < boundLeft)
            {
                left = false;
            }
        }
        else
        {
            Vector3 tmp = transform.position;
            tmp.x += speed * Time.deltaTime;
            transform.position = tmp;
            if (transform.position.x > boundRight)
            {
                left = true;
            }
        }
    }

   
}















