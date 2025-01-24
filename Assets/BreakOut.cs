using UnityEngine;
using UnityEngine.InputSystem;

public class BreakOut : MonoBehaviour
{
    public InputActionReference action;
    private Vector3 InitPos = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 OuterPos = new Vector3(0.0f, 0.0f, -25.0f);
    private bool isAtInitPos = true;
    
    void Start()
    {
        action.action.Enable();
        transform.position = InitPos;
    }
    void Update()
    {
        if (action.action.WasPerformedThisFrame())
        {
            SwitchPlaces();
        }
    }

    private void SwitchPlaces()
    {
        isAtInitPos = !isAtInitPos;
        if (isAtInitPos)
        {
            transform.position = InitPos;
        }
        else
        {
            transform.position = OuterPos;
        }

    }
}
