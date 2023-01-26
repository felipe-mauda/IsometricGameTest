using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sorrizo : MonoBehaviour, IInteractable
{

    [SerializeField] private string _prompt;
    [SerializeField] private Transform _transform;
    [SerializeField] private GameObject _player;
    [SerializeField] private BasicRigidBodyPush _rb;
    
    //public bool isPushable;

    private void Start()
    {
      
        //_rb = _player.GetComponent<BasicRigidBodyPush>();
    }

    public bool Interact(Interactor interactor)
    {
        throw new System.NotImplementedException();
    }

    public string InteractionPrompt => _prompt;

    public bool pushable;
    public bool IsPushable { get => pushable ; set => pushable = value; }


    /*public bool Interact(Interactor interactor)
    {
        _rb.canPush = IsPushable;
        return true;
    }*/
}
