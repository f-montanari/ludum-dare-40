using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour {

    public List<GameObject> mapList;
    public int maxMaps = 10;

	// Use this for initialization
	void Start () {
        DateTime today = DateTime.Today;
        // Random seed every second
        int seed = (today.Hour + today.Minute) * today.Second;
        //UnityEngine.Random.InitState(seed);
        int lastNumber = -1;
        for (int i = 0; i<maxMaps; i++)
        {
            int f = lastNumber;
            while (f == lastNumber)
            {
                f=UnityEngine.Random.Range(0, mapList.Count);
            }
            Instantiate(mapList[f], new Vector3(0, 10 * i, 0), Quaternion.identity, this.transform);
            lastNumber = f;
        }
	}
	
}
