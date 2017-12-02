using UnityEngine;

public class InteractingPlatformBehaviour : InteractableComponent {

    public Vector3 direction;

    private bool interacting = false;

    public override void InteractStart()
    {
        interacting = true;
    }

    public override void InteractStop()
    {
        interacting = false;
    }

    private void Update()
    {
        if(interacting)
        {
            this.transform.position += direction * Time.deltaTime;
        }
    }
}
