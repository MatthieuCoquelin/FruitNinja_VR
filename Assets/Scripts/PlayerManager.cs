using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Vector3 m_playerPosition = Vector3.zero;
    private Quaternion m_playerRotation = Quaternion.identity;

    private void Awake()
    {
        ///make sur the player is at ggo position/rotation to sclice fruit 
        m_playerPosition = new Vector3(403.23f, 3.9269f, 450.64f);
        m_playerRotation = new Quaternion(0f, -90f, 0f, transform.rotation.w);
    }

    private void Start()
    {
        //initialise player position / rotation on start 
        transform.position = m_playerPosition;
        transform.rotation = m_playerRotation;
        transform.Rotate(Vector3.up, 90);
    }
}
