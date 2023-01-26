using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ronaldo : MonoBehaviour, IInteractable
{

    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;

    public bool IsPushable { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public bool Interact(Interactor interactor)
    {
        var inventory = interactor.GetComponent<Inventory>();

        if (inventory == null) return false;

        if (inventory.HasKey)
        {
            Debug.Log("é o Sorrizo Ronaldo que chegou!");
            return true;
        }

        Debug.Log("não tem chave menó...");
        return false;

       
    }
    
}
