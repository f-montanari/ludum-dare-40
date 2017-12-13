using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour {

    public List<GameObject> pointers;        
    public AudioSource blipSource;
    public GameObject difficultySelect;
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
                    Debug.Log("Tutorial");
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Tutorial");
                    break;
                case 1:
                    Debug.Log("Endless");
                    difficultySelect.SetActive(true);
                    this.gameObject.SetActive(false);
                    break;
                case 2:
                    Debug.Log("Exiting");
                    Application.Quit();
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
