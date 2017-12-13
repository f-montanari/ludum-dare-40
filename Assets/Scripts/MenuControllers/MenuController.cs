using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

    public List<GameObject> pointers;
    [HideInInspector]
    public Transform lastCheckpoint;
    public AudioSource blipSource;
    public GameObject playerPrefab;

    private GameObject player;
    private int currentPointer = 0;	
	
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Up"))
        {
            currentPointer = currentPointer > 0 ? currentPointer -= 1 : pointers.Count - 1;
            ClearPointers();
            pointers[currentPointer].SetActive(true);
            blipSource.Play();
        }
        if (Input.GetButtonDown("Down"))
        {
            currentPointer = currentPointer < pointers.Count - 1 ? currentPointer += 1 : 0;
            ClearPointers();
            pointers[currentPointer].SetActive(true);
            blipSource.Play();
        }
        if(Input.GetButtonDown("Submit"))
        {
            switch(currentPointer)
            {
                case 0:
                    Debug.Log("Retrying");
                    Retry();
                    break;
                case 1:
                    Debug.Log("Quitting");
                    if (GameObject.FindObjectOfType<Difficulty>() != null)
                    {
                        Destroy(GameObject.FindObjectOfType<Difficulty>().gameObject);
                    }
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
                    break;
            }
        }
    }

    void Retry()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Tutorial");
    }

    void ClearPointers()
    {
        foreach (GameObject pointer in pointers)
        {
            pointer.SetActive(false);
        }
    }
}
