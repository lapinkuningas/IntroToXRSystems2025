
using UnityEngine;
using UnityEngine.InputSystem;

public class LightController : MonoBehaviour
{
    public Light pointlight;
    public Color originalColor;
    public InputActionReference action;
    public Color differentColor = Color.green;
    private bool isDifferentColor = false;
    
    void Start()
    {
        pointlight = GetComponent<Light>();
        if (pointlight != null)
        {
            originalColor = pointlight.color;
        }
        action.action.Enable();
    }

    void Update()
    {
        if (action.action.WasPerformedThisFrame())
        {
            ChangeLightColor();
        }
    }
    private void ChangeLightColor()
    {
        if (pointlight != null)
        {
            isDifferentColor = !isDifferentColor;
            pointlight.color = isDifferentColor ? differentColor : originalColor;
        }
        }
    }