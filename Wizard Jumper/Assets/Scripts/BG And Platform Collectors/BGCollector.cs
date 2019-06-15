using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGCollector : MonoBehaviour {

    private GameObject[] bgs;

    private float firstY;


    private void Awake()
    {
        bgs = GameObject.FindGameObjectsWithTag("Background");

        firstY = bgs[0].transform.position.y;
        for(int i = 1; i < bgs.Length; i++)
        {
            if (firstY < bgs[i].transform.position.y)
            {
                firstY = bgs[i].transform.position.y;
            }
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Background")
        {
            Vector3 tmp = transform.position;
            float height = ((BoxCollider2D)target).size.y;
            tmp.y = firstY + height;
            target.transform.position = tmp;
            firstY = tmp.y;
        }
    }



}
