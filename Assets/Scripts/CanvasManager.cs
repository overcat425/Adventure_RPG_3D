using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;
    public CinemachineInputProvider cinemachineInputProvider;
    public Joystick joystick;
    public Canvas canvas;
    private void Awake()
    {
        instance = this;
    }
}
