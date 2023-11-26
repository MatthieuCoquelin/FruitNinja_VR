using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Instance : MonoBehaviour
{
    /// <summary>
    /// rotation of the fuits 
    /// </summary>
    [SerializeField] private Vector3 m_rotationSpeed;


    // Update is called once per frame
    void Update()
    {
        // rotate fruit instanciated over time 
        transform.Rotate(m_rotationSpeed * Time.fixedDeltaTime);
    }

}
