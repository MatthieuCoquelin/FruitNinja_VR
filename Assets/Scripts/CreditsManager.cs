using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{
    /// <summary>
    /// Go to the main menu from the credit scene by clicking on the "X" button
    /// </summary>
    public void GameMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
