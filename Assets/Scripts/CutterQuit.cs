using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutterQuit : MonoBehaviour
{
    /// <summary>
    /// reference to the pear's parent gameObject in the menu
    /// </summary>
    [SerializeField] GameObject m_pear = null;

    /// <summary>
    /// reference to the apple's parent gameObject in the menu
    /// </summary>
    [SerializeField] GameObject m_apple = null;

    private void Update()
    {
        // The bomb is destroyed the transform parent has no children
        if (transform.childCount == 0)
        {
            // disable the object slicable of the menu to make sure we do the correct action 
            m_pear.GetComponent<CutterCredits>().enabled = false;
            m_apple.GetComponent<CutterPlay>().enabled = false;

            // We quit the app in couroutine to see the explosion occure
            StartCoroutine(SceneLuncherCoroutine());
        }
    }

    /// <summary>
    /// Quit the game after 1s.
    /// </summary>
    /// <returns></returns>
    private IEnumerator SceneLuncherCoroutine()
    {
        yield return new WaitForSeconds(1f);
        Application.Quit();
    }
}
