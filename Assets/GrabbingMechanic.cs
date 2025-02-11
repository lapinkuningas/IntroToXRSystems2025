using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrabbingMechanic : MonoBehaviour
{
    public InputActionReference grabbingAction;
    public Transform grabbingPoint;

    private GameObject grabbedObject = null;
    private Rigidbody grabbedRigidbody = null;

    void Start()
    {
        grabbingAction.action.Enable();
        grabbingAction.action.performed += ctx => GrabOrRelease();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grabbable") && grabbedObject == null)
        {
            grabbedObject = other.gameObject;
            grabbedRigidbody = grabbedObject.GetComponent<Rigidbody>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == grabbedObject)
        {
            grabbedObject = null;
            grabbedRigidbody = null;
        }
    }

    void GrabOrRelease()
{
    if (grabbedObject == null || grabbedRigidbody == null)
    {
        Debug.Log("No object to grab!");
        return;
    }

    if (grabbedObject.transform.parent == grabbingPoint)
    {
        grabbedObject.transform.SetParent(null);
        grabbedRigidbody.isKinematic = false;
        grabbedRigidbody = null;
        grabbedObject = null;
    }
    else
    {
        grabbedObject.transform.SetParent(grabbingPoint);
        grabbedObject.transform.localPosition = Vector3.zero;
        grabbedObject.transform.localRotation = Quaternion.identity;
        grabbedRigidbody.isKinematic = true;
    }
}
}
