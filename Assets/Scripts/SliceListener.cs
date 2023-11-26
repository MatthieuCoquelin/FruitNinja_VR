using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SliceListener : MonoBehaviour
{
    // delegete to call slice methods
    public static event Action OnSlicerEnter;
    public static event Action OnSlicerExit;

    // at the begining we do not slice 
    public static bool IsSlicing = false;

    /// <summary>
    /// Call slice methods on triger enter 
    /// set the slicing attribute to true to notifie slice 
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (!IsSlicing)
        {
            IsSlicing = true;
            OnSlicerEnter?.Invoke();

        }
    }

    /// <summary>
    /// on try ger exit notify the en of slice 
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        OnSlicerExit?.Invoke();
    }





}