using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VibrationsManager : MonoBehaviour
{
    /// <summary>
    /// Reference to the left controller 
    /// </summary>
    [SerializeField] private ActionBasedController m_leftController = null;

    /// <summary>
    /// Reference to the right controller
    /// </summary>
    [SerializeField] private ActionBasedController m_rightController = null;

    private void OnEnable()
    {
        // Enable listener
        Slicer.OnSliceVibrate += Vibrate;
    }


    private void OnDisable()
    {
        // Disable listener 
        Slicer.OnSliceVibrate -= Vibrate;
    }

    /// <summary>
    /// Vibrate controller depend on sword tag 
    /// </summary>
    /// <param name="tag"></param>
    /// <param name="amplitude"></param>
    /// <param name="duration"></param>
    private void Vibrate(string tag, float amplitude, float duration)
    {
        if (tag == "LeftCut")
            m_leftController.SendHapticImpulse(amplitude, duration);
        else if (tag == "RightCut")
            m_rightController.SendHapticImpulse(amplitude, duration);
    }
}
