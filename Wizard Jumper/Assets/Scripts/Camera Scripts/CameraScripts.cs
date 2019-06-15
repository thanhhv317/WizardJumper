using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScripts : MonoBehaviour {

    private bool canMove;

    private float distance = 7f;
    private float newDestination;

    private void OnEnable()
    {
        PlayerScripts.move += move;
    }

    private void OnDisable()
    {
        PlayerScripts.move -= move;// move is function
    }


    // Update is called once per frame
    void Update () {
        MoveCamera();
	}

    private void MoveCamera()
    {
        if (canMove)
        {
            Vector3 tmp = transform.position;
            tmp.y += 3f * Time.deltaTime;
            transform.position = tmp;
            if (transform.position.y >= newDestination)
            {
                canMove = false;
            }
        }
    }

    void move()
    {
        newDestination = transform.position.y+distance;
        canMove = true;
    }
}
