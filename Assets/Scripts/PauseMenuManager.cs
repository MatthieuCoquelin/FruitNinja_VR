using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    /// <summary>
    /// regerence to the pause menu 
    /// </summary>
    [SerializeField] private GameObject m_pauseMenu = null;

    /// <summary>
    /// reference to the interactor
    /// </summary>
    [SerializeField] private GameObject m_leftInteractor = null;
    
    /// <summary>
    /// reference to the interactor
    /// </summary>
    [SerializeField] private GameObject m_rightInteractor = null;

    /// <summary>
    /// Desactivate the interacors and the menu when pressing the resume button 
    /// </summary>
    public void Resume()
    {
        m_leftInteractor.SetActive(false);
        m_rightInteractor.SetActive(false);
        m_pauseMenu.SetActive(false);
    }

    /// <summary>
    /// reload the active scene when pressing the restart button
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// load the main scene when pressing the main menu button
    /// </summary>
    public void MainMenu()
    {
        // put the main menu when finished 
        SceneManager.LoadScene("MenuScene");
    }
}
