using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformComponent : MonoBehaviour {

    public List<Vector3> positions;    

    private int currentPos = 0;
	// Use this for initialization
	void Start () {
		if(positions.Count == 0)
        {
            Debug.LogError("No destinations for this platform!");
        }
	}
	
	// Update is called once per frame
	void Update () {
	    if((currentPos + 1) >= positions.Count)
        {
            currentPos = -1;
        }
        
        if(this.transform.position != positions[currentPos + 1])
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, positions[currentPos + 1], 0.1f);
        }
        else
        {
            currentPos += 1;
        }

	}
}
