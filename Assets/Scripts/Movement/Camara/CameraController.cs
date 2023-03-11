using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public float rotationPower = 1f;

    private CinemachineVirtualCamera virtualCamera;
    private CinemachineOrbitalTransposer cameraTransposer;

    private void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        cameraTransposer = virtualCamera.GetCinemachineComponent<CinemachineOrbitalTransposer>();
    }

    private void Update()
    {
        var _look = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        cameraTransposer.m_XAxis.Value += _look.x * rotationPower;
        cameraTransposer.m_YAxis.Value -= _look.y * rotationPower;

        var angles = cameraTransposer.m_Heading.m_XAxis.m_InputAxisValue;

        if (angles > 180 && angles < 340)
        {
            angles = 340;
        }
        else if (angles < 180 && angles > 40)
        {
            angles = 40;
        }

        cameraTransposer.m_Heading.m_XAxis.m_InputAxisValue = angles;
    }
}
