using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable 
{
    public string InteractionPrompt { get; }
    public bool IsPushable { get; set; }
    public bool Interact(Interactor interactor);
}
