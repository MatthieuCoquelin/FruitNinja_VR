using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class FruitsManager : MonoBehaviour
{
    /// <summary>
    /// left transform where fruits are instantiated
    /// </summary>
    [SerializeField] private Transform m_leftInstancePoint = null;

    /// <summary>
    /// left transform where fruits are instantiated
    /// </summary>
    [SerializeField] private Transform m_rightInstancePoint = null;

    /// <summary>
    /// list of fruit 
    /// </summary>
    [SerializeField] private List<GameObject> m_fruitsList = null;

    /// <summary>
    /// force applyes to the fuit instantiateds
    /// </summary>
    [SerializeField] private Vector3 m_leftArcForce;

    /// <summary>
    /// force applyes to the fuit instantiateds
    /// </summary>
    [SerializeField] private Vector3 m_rightArcForce;

    /// <summary>
    /// Timer reference to get the end of the game 
    /// </summary>
    [SerializeField] private TimerManager m_timerManager = null;

    /// <summary>
    /// lock down the button menu at the end with the reference
    /// </summary>
    [SerializeField] private InputsManager m_inputsManager = null;

    /// <summary>
    /// reference to the end panel
    /// </summary>
    [SerializeField] private GameObject m_endMenuPanel = null;

    /// <summary>
    /// activate the ray interactor to interact with the panel at the end
    /// </summary>
    [SerializeField] private GameObject m_leftInteractor = null;

    /// <summary>
    /// activate the ray interactor to interact with the panel at the end
    /// </summary>
    [SerializeField] private GameObject m_rightInteractor = null;

    /// <summary>
    /// call the methode to get the score on the end panel by delegate 
    /// </summary>
    public static event Action OnEndGetScore;

    /// <summary>
    /// call to launch the game 
    /// </summary>
    public void Play()
    {
        StartCoroutine(InstantiateFruit(m_leftInstancePoint, m_leftArcForce));
        StartCoroutine(InstantiateFruit(m_rightInstancePoint, m_rightArcForce));
        // Launch the timer at the same time 
        m_timerManager.LauchTimer();
    }

    /// <summary>
    /// thre are coroutine each of them instantiate fruits to a location
    /// the coroutines are here to put time between fruits
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="force"></param>
    /// <returns></returns>
    private IEnumerator InstantiateFruit(Transform origin, Vector3 force)
    {
        do
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(0.5f, 2.0f));
            GameObject fruitInstance = Instantiate(m_fruitsList[UnityEngine.Random.Range(0, m_fruitsList.Count)], origin);
            Vector3 velocity = force * Time.fixedDeltaTime;
            fruitInstance.GetComponent<Rigidbody>().velocity = velocity;
            if (force.z > 0)
                force.z = UnityEngine.Random.Range(75f, 125f);
            else if (force.z < 0)
                force.z = UnityEngine.Random.Range(-75f, -125f);
            Destroy(fruitInstance, 3f);
        } while (m_timerManager.IsPlaying);
        //end of the game 
        m_inputsManager.enabled = false;
        m_endMenuPanel.SetActive(true);
        m_leftInteractor.SetActive(true);
        m_rightInteractor.SetActive(true);
        OnEndGetScore?.Invoke();
    }
}
