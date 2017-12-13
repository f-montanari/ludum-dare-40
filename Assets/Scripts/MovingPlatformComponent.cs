using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformComponent : MonoBehaviour {

    public List<Vector3> positions;
    public float timeToReach = 1f;
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
        
        if(this.transform.localPosition != positions[currentPos + 1])
        {
            this.transform.localPosition = Vector3.Lerp(this.transform.localPosition,Vector3.MoveTowards(this.transform.localPosition, positions[currentPos + 1], 0.1f),timeToReach);
        }
        else
        {
            currentPos += 1;
        }

	}
}
