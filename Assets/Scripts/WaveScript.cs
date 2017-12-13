using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveScript : MonoBehaviour {

    public float speed = 1;
    public float t;
    private float initialY;
	// Use this for initialization
	void Start () {
        initialY = this.transform.localPosition.y;

    }
	
	// Update is called once per frame
	void Update () {
        t += Time.deltaTime;
        Vector3 position = new Vector3(
            this.transform.localPosition.x + speed * Time.deltaTime,
             initialY + 0.25f * Mathf.Sin((speed * t)),
            0);
        this.transform.localPosition = position;
	}
}
