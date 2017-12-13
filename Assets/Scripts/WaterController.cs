using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour {

    public float waterSpeed = 0.25f;
    public float waterAcceleration = 0.05f;

	// Use this for initialization
	void Start () {
        Difficulty diff = FindObjectOfType<Difficulty>();
        if(diff == null)
        {
            Debug.LogError("No difficulty found");
        }
        else
        {
            waterSpeed = diff.waterSpeed;
            waterAcceleration = diff.waterAcceleration;
        }

	}
	
	// Update is called once per frame
	void Update () {
        this.transform.localScale += new Vector3(0, waterSpeed * Time.deltaTime + 0.5f * waterAcceleration * Time.deltaTime * Time.deltaTime, 0);
	}
}
