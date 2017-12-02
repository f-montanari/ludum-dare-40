using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : InteractableComponent {

    public bool isToggle = false;
    public float interactionTime = 3f;
    public List<InteractableComponent> interactions;
    public Transform redButton;
    public bool oneTimeOnly = false;

    private bool toggle = false;
    private float timer = 0f;
    private bool interacting = false;
    private bool interacted = false;

    public override void InteractStart()
    {
        if( oneTimeOnly && interacted )
        {
            return;
        }
        if (!interacting)
        {
            interacted = false;
            timer = 0f;
            if (isToggle)
            {
                toggle = !toggle;
            }
            foreach (InteractableComponent interaction in interactions)
            {
                interaction.InteractStart();
            }
            interacting = true;
            redButton.localPosition += new Vector3(0, 0.09f, 0);
        }
    }

    public override void InteractStop()
    {
        // Gets called when I stop pressing the button.
    }

    void Start()
    {
        Color c = redButton.gameObject.GetComponent<SpriteRenderer>().color;
        foreach (InteractableComponent interaction in interactions)
        {
            interaction.GetComponent<SpriteRenderer>().color = c;
        }
    }

    void Update()
    {
        if(interacting)
        {
            timer += Time.deltaTime;
            if (timer >= interactionTime)
            {
                interacting = false;

                foreach (InteractableComponent interaction in interactions)
                {
                    interaction.InteractStop();
                }
                redButton.localPosition -= new Vector3(0, 0.09f, 0);
                interacted = true;
            }
        }
    }
}
