using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeLookCamera : MonoBehaviour
{
    CinemachineFreeLook freeLook;
    void Awake()
    {
        CinemachineCore.GetInputAxis = clickControl;
    }

    void Start()
    {
        // Target ����
        freeLook = this.GetComponent<CinemachineFreeLook>();
        freeLook.Follow = GameObject.Find("Player").transform;
        freeLook.LookAt = GameObject.Find("CameraFocus").transform;

        // Lens ����
        freeLook.m_Lens.FieldOfView = 50;
        freeLook.m_Lens.NearClipPlane = 0.2f;
        freeLook.m_Lens.FarClipPlane = 4000;
        freeLook.m_Lens.Dutch = 0;
        freeLook.m_Lens.ModeOverride = LensSettings.OverrideModes.None;

        // Axis Control ����
        freeLook.m_XAxis.Value = 0;
        freeLook.m_XAxis.m_MaxSpeed = 300;
        freeLook.m_XAxis.m_AccelTime = 0.1f;

        // Rig ����
        CinemachineComposer composer
            = freeLook.GetRig(1).GetCinemachineComponent<CinemachineComposer>();
        composer.m_DeadZoneHeight = 0.3f;
        composer.m_DeadZoneWidth = 0.5f;
    }

    public float clickControl(string axis)
    {
        if (Input.GetMouseButton(0))
            return UnityEngine.Input.GetAxis(axis);

        return 0;
    }
}
