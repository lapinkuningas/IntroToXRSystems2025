using UnityEngine;

public class MagnifyingGlass : MonoBehaviour
{
    public Transform lens;
    public Transform MainCamera;
    public Transform magnifyingCam;

    private void Update()
    {
        if (!lens || !MainCamera || !magnifyingCam) return;

        Vector3 viewDirection = (lens.position - MainCamera.position).normalized;
        magnifyingCam.position = lens.position;
        magnifyingCam.rotation = Quaternion.LookRotation(viewDirection, lens.up);
    }
}
