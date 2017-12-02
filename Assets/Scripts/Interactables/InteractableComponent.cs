using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableComponent : MonoBehaviour
{    
    public abstract void InteractStart();
    public abstract void InteractStop();
}
