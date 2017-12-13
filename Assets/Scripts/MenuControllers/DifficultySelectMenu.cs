using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultySelectMenu : MonoBehaviour {

    public List<GameObject> pointers;
    public AudioSource blipSource;
    public GameObject difficultyPrefab;
    public GameObject backMenu;
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
            GameObject go = Instantiate(difficultyPrefab);
            Difficulty diff = go.GetComponent<Difficulty>();
            switch (currentPointer)
            {                
                case 0:
                    diff.waterSpeed = 0.33f;
                    diff.waterAcceleration = 45f;
                    DontDestroyOnLoad(go);
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Endless");
                    break;
                case 1:
                
                    diff.waterSpeed = 0.25f;
                    diff.waterAcceleration = 45f;
                    DontDestroyOnLoad(go);
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Endless");
                    break;
                case 2:
                    diff.waterSpeed = 0.25f;
                    diff.waterAcceleration = 20f;
                    DontDestroyOnLoad(go);
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Endless");                    
                    break;
                case 3:
                    Destroy(go);
                    backMenu.SetActive(true);
                    this.gameObject.SetActive(false);
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
