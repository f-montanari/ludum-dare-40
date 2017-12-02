using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValveBehaviour : InteractableComponent
{
    public List<InteractableComponent> interactions;
    public float rotationVelocity = 2f;
    public float interactionTime;

    private float timeElapsed = 0;
    private bool interacting;
    private bool interacted = false;

    public override void InteractStart()
    {
        if (interacted)
        {
            return;
        }        
        interacting = true;
        foreach (InteractableComponent interaction in interactions)
        {
            interaction.InteractStart();
        }
    }
    public override void InteractStop()
    {
        if (interacted)
        {
            return;
        }
        interacting = false;
        foreach (InteractableComponent interaction in interactions)
        {
            interaction.InteractStop();
        }
    }


    // Use this for initialization
    void Start () {
	    if( interactions == null )
        {
            Debug.LogError("Forgot to add interaction!");
        }
        foreach (InteractableComponent interaction in interactions)
        {
            interaction.GetComponent<SpriteRenderer>().color = gameObject.GetComponent<SpriteRenderer>().color;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if( interacted )
        {
            return;
        }
		if(interacting)
        {
            this.transform.Rotate(new Vector3(0, 0, rotationVelocity));
            timeElapsed += Time.deltaTime;
        }
        if(timeElapsed >= interactionTime)
        {
            InteractStop();
            interacted = true;
        }
	}
}
