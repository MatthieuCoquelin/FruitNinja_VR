using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutterCredits : MonoBehaviour
{
    /// <summary>
    /// reference to the apple's parent gameObject in the menu
    /// </summary>
    [SerializeField] GameObject m_apple = null;

    /// <summary>
    /// reference to the bomb's parent gameObject in the menu
    /// </summary>
    [SerializeField] GameObject m_bomb = null;

    private void Update()
    {
        // The pear is destroyed the transform parent has no children
        if(gameObject.transform.childCount == 0)
        {
            // disable the object slicable of the menu to make sure we do the correct action 
            m_apple.GetComponent<CutterPlay>().enabled = false;
            m_bomb.GetComponent<CutterQuit>().enabled = false;
            
            // We lunch the credit scene in couroutine to see the cut occure
            StartCoroutine(SceneLuncherCoroutine());
        }

    }

    /// <summary>
    /// Load credit scene after 1s.
    /// </summary>
    /// <returns></returns>
    private IEnumerator SceneLuncherCoroutine()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("CreditsScene");
    }
}
