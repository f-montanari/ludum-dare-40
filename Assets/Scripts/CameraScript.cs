using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    public float minY = -3.78f;
    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        try
        {
            if (player.transform.position.y >= minY)
            {
                transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, minY, transform.position.z);
            }
        }
        catch (MissingReferenceException e)
        {
            int counter = 0;
            while (player == null)
            {
                player = GameObject.FindGameObjectWithTag("Player");
                counter++;
                if(counter >= 30)
                {
                    continue;
                }
            }
            if (player == null)
            {
                Debug.LogError("No player found");
                throw e;
            }
        }        
	}
}
