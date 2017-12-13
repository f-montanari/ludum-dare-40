using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessMenuController : MonoBehaviour {

    public List<GameObject> pointers;
    public AudioSource blipSource;
    
    private int currentPointer = 0;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Up"))
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
        if (Input.GetButtonDown("Submit"))
        {
            switch (currentPointer)
            {
                case 0:
                    Debug.Log("Retrying");
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Endless");
                    break;
                case 1:
                    Debug.Log("Quitting");
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
                    break;
            }
        }
    }    

    void ClearPointers()
    {
        foreach (GameObject pointer in pointers)
        {
            pointer.SetActive(false);
        }
    }
}
