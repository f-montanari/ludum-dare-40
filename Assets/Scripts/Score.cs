using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public Text scoreText;
    private float startY;
    private Transform player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        startY = player.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Score=" + (Mathf.Abs(player.position.y)).ToString();
	}
}
