using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutterPlay : MonoBehaviour
{
    /// <summary>
    /// reference to the pear's parent gameObject in the menu
    /// </summary>
    [SerializeField] GameObject m_pear = null;

    /// <summary>
    /// reference to the bomb's parent gameObject in the menu
    /// </summary>
    [SerializeField] GameObject m_bomb = null;

    private void Update()
    {
        // The apple is destroyed the transform parent has no children
        if (transform.childCount == 0)
        {
            // disable the object slicable of the menu to make sure we do the correct action 
            m_pear.GetComponent<CutterCredits>().enabled = false;
            m_bomb.GetComponent<CutterQuit>().enabled = false;

            // We lunch the main scene in couroutine to see the cut occure
            StartCoroutine(SceneLuncherCoroutine());
        }
    }

    /// <summary>
    /// Load main scene after 1s.
    /// </summary>
    /// <returns></returns>
    private IEnumerator SceneLuncherCoroutine()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("MainScene");
    }
}
