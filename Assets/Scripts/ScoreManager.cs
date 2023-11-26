using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    //score counter
    public static int Counter;

    /// <summary>
    /// score on the left panel
    /// </summary>
    [SerializeField] private TextMeshProUGUI m_scoreText = null;

    /// <summary>
    /// reference to the time manger to update score only during the time allowed
    /// </summary>
    [SerializeField] private TimerManager m_timerManager = null;

    /// <summary>
    /// put the counter to 0 on awake 
    /// </summary>
    private void Awake()
    {
        Counter = 0;
        m_scoreText.text = Counter.ToString();
    }

    private void OnEnable()
    {
        Slicer.OnSliceUpdateScore += UpdateScore;
    }


    private void OnDisable()
    {
        Slicer.OnSliceUpdateScore -= UpdateScore;
    }


    private void UpdateScore(string tag)
    {
        // if we slice a bom - 10 points
        if (tag == "Bomb")
        {
            if (m_timerManager.IsPlaying)
                Counter -= 10;
            if (Counter < 0)
                Counter = 0;
        }
        else // + 1 point if we slice a fruit 
        {
            if(m_timerManager.IsPlaying)
                Counter++;
        }
        m_scoreText.text = Counter.ToString();
    }

    /// <summary>
    /// return the score 
    /// </summary>
    public int Score
    {
        get { return Counter; }
    }

}
