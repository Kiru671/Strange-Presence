using UnityEngine;
using Cinemachine;

public class Script_Name : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCam;

    private CinemachineOrbitalTransposer cameraLook;


    private void Start()
    {
        cameraLook = virtualCam.GetCinemachineComponent<CinemachineOrbitalTransposer>();
    }
    private void FixedUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            cameraLook.m_XAxis.m_InputAxisName = "Mouse X";
        }
        else
            cameraLook.m_XAxis.m_InputAxisName = "";
    }
}
