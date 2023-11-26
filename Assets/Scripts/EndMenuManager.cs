using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class EndMenuManager : MonoBehaviour
{
    /// <summary>
    /// Reference to the soreManager on the right pannel
    /// </summary>
    [SerializeField] private ScoreManager m_scoreManager = null;

    /// <summary>
    /// Text where to put the score
    /// </summary>
    [SerializeField] private TextMeshProUGUI m_scoreText = null;

    /// <summary>
    /// OnEnable listen for the end to get the score on the text
    /// </summary>
    private void OnEnable()
    {
        FruitsManager.OnEndGetScore += GetScore;
    }

    /// <summary>
    /// OnDisable stop listening to get the score
    /// </summary>
    private void OnDisable()
    {
        FruitsManager.OnEndGetScore -= GetScore;
    }

    /// <summary>
    /// Write the score on the text on the end panel at the en of the game 
    /// </summary>
    private void GetScore()
    {
        m_scoreText.text = m_scoreManager.Score.ToString();
    }

    /// <summary>
    /// Reload the actual scene when clicking on restart button at the end 
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// Load the main menu when clicking on main menu button at the end 
    /// </summary>
    public void MainMenu()
    {
        // put the main menu when finished 
        SceneManager.LoadScene("MenuScene");
    }
}
