using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceSoundManger : MonoBehaviour
{
    /// <summary>
    /// reference the audio source of the left sword
    /// </summary>
    [SerializeField] private AudioSource m_leftSliceAudioSource = null;

    /// <summary>
    /// reference the audio source of the left sword
    /// </summary>
    [SerializeField] private AudioSource m_rightSliceAudioSource = null;
    
    /// <summary>
    /// pinch variation for change the slice sound
    /// </summary>
    private float m_minPitch;
    private float m_maxPitch;

    private void Awake()
    {
        //initialize values 
        m_minPitch = 0.8f;
        m_maxPitch = 1.2f;
    }


    private void OnEnable()
    {
        Slicer.OnSliceMakeSound += MakeSound;
    }



    private void OnDisable()
    {
        Slicer.OnSliceMakeSound -= MakeSound;
    }

    /// <summary>
    /// call the right audio source depend on tag
    /// </summary>
    /// <param name="cuttedLayer"></param>
    /// <param name="tag"></param>
    private void MakeSound(int cuttedLayer, string tag)
    {
        //the gameobject must me slacable
        if (cuttedLayer != LayerMask.NameToLayer("SlicableOutlined"))
            return;

        //if we cut with the left sword
        if (tag == "LeftCut")
        {
            //we change the pich and we play te audio 
            m_leftSliceAudioSource.pitch = UnityEngine.Random.Range(m_minPitch, m_maxPitch);
            m_leftSliceAudioSource.Play();
        }

        //if we cut with the right sword
        else if (tag == "RightCut")
        {
            //we change the pich and we play te audio 
            m_rightSliceAudioSource.pitch = UnityEngine.Random.Range(m_minPitch, m_maxPitch);
            m_rightSliceAudioSource.Play();
        }
    }

}
