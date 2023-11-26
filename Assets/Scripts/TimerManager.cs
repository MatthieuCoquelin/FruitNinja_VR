using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    /// <summary>
    /// reference to the timer
    /// </summary>
    [SerializeField] private TextMeshProUGUI m_timerText = null;
    
    /// <summary>
    /// minutes attribute s
    /// </summary>
    private int m_minutes;

    /// <summary>
    /// seconds attribute
    /// </summary>
    private int m_seconds;

    /// <summary>
    /// total time
    /// </summary>
    private int m_Tolalseconds;

    /// <summary>
    /// attribut here to notify the end of timer
    /// </summary>
    private bool m_Isplaying;

    private void Awake()
    {
        // launch timer on awake  
        m_Isplaying = true;
        m_Tolalseconds = 180;
        ComputeTimer();
    }

    /// <summary>
    /// launch the coroutine timer at the begining
    /// </summary>
    public void LauchTimer()
    {
        StartCoroutine(TimerCoroutine());
    }

    //timer coroutine 
    private IEnumerator TimerCoroutine()
    {
        do
        {
            yield return new WaitForSeconds(1f);
            m_Tolalseconds--;
            ComputeTimer();

        } while (m_Tolalseconds > 0);
        m_Isplaying = false;
    }

    /// <summary>
    /// cumpute timer s
    /// </summary>
    private void ComputeTimer()
    {
        m_minutes = m_Tolalseconds / 60;
        m_seconds = m_Tolalseconds % 60;

        if (m_seconds < 10)
            m_timerText.text = "0" + m_minutes.ToString() + ":0" + m_seconds;
        else if (m_seconds >= 10)
            m_timerText.text = "0" + m_minutes.ToString() + ":" + m_seconds;
    }

    /// <summary>
    /// property to update the state timer value and notify the end 
    /// </summary>
    public bool IsPlaying
    {
        get { return m_Isplaying; }
        set { m_Isplaying = value; }
    }
}
