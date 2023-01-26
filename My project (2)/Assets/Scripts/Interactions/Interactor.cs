using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;

    [SerializeField] private InteractionPromptUI _interactionPromptUI;

    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _numFound;

    private IInteractable _interactable;

    private void Update()
    {
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionRadius, _colliders, _interactableMask);

        if (_numFound > 0)
        {
            _interactable = _colliders[0].GetComponent<IInteractable>();

            if (_interactable != null)
            {
                

                if (!_interactionPromptUI.IsDisplayed) _interactionPromptUI.SetUp(_interactable.InteractionPrompt);

                if (Keyboard.current.eKey.IsPressed())
                {
                    this.GetComponent<BasicRigidBodyPush>().canPush = _interactable.IsPushable;
                    PushingObjectMovement(_colliders[0].GetComponent<Rigidbody>());
                }
                else if(!Keyboard.current.eKey.IsPressed())
                {
                    this.GetComponent <BasicRigidBodyPush>().canPush = false;
                }


            }
           
        }
        else
        {
            /*this.GetComponent<BasicRigidBodyPush>().canPush = false;
            if (_interactable != null) _interactable = null;
            _interactionPromptUI.Close();*/
        }

    }

    public void PushingObjectMovement(Rigidbody rb)
    {
   
        GetComponent<ThirdPersonController>()._input.move.x = 0f;

        /*if (rb.constraints.)
        {
            // constraints has at least FreezePositionY, don't care about others 
        }*/
    }

    

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionRadius);
    }
}
