using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMenuManager : MonoBehaviour
{
    /// <summary>
    /// reference to the fruitmanger to launch the game 
    /// </summary>
    [SerializeField] private FruitsManager m_fruitManager = null;

    /// <summary>
    /// reference the panel to desactivate it on play 
    /// </summary>
    [SerializeField] private GameObject m_startMenuPanel = null;

    /// <summary>
    /// reference to the interactor
    /// </summary>
    [SerializeField] private GameObject m_leftInteractor = null;

    /// <summary>
    /// reference to the interactor
    /// </summary>
    [SerializeField] private GameObject m_rightInteractor = null;

    /// <summary>
    /// reference the input manger to make sure we only call the menu when button play is pressed
    /// </summary>
    [SerializeField] private InputsManager m_inputsManagager = null;

    private void Start()
    {
        //activate the interacors 
        m_leftInteractor.SetActive(true);
        m_rightInteractor.SetActive(true);
    }

    /// <summary>
    /// what for 1 second before launch fruit to the player after triggered the play button 
    /// </summary>
    /// <returns></returns>
    private IEnumerator PlayCouroutine()
    {
        //launch the game and enable / disable some properties
        m_startMenuPanel.SetActive(false);
        m_inputsManagager.enabled = true;
        yield return new WaitForSeconds(1f);
        m_fruitManager.Play();

    }

    /// <summary>
    /// lauch the game by pressing the play button 
    /// </summary>
    public void Play ()
    {
        StartCoroutine(PlayCouroutine());
    }
}
