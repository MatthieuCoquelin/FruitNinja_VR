using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    /// <summary>
    /// rotation speed 
    /// </summary>
    private float m_speed;
    // Start is called before the first frame update
    private void Awake()
    {
        //initialise speed on start
        m_speed = 20f;
    }

    void FixedUpdate()
    {
        //rotate the apple, pear and bomb of the menu
        transform.Rotate(Vector3.up, m_speed * Time.deltaTime);
    }
}
