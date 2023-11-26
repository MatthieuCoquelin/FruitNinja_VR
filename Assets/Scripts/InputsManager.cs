using UnityEngine;
using UnityEngine.InputSystem;

public class InputsManager : MonoBehaviour
{
    /// <summary>
    /// referenjce to the panel for menu button
    /// </summary>
    [SerializeField] private GameObject m_menu;

    /// <summary>
    /// reference to input action to use the menu button 
    /// </summary>
    [SerializeField] private InputActionReference m_showButton;

    /// <summary>
    /// activate the ray interactor to interact with the panel when activated
    /// </summary>
    [SerializeField] private GameObject m_leftRayInteractor;

    /// <summary>
    /// activate the ray interactor to interact with the panel when activated
    /// </summary>
    [SerializeField] private GameObject m_rightRayInteractor;


    private void OnEnable()
    {
        m_showButton.action.performed += MenuPanel;
    }

    

    private void OnDisable()
    {
        m_showButton.action.performed -= MenuPanel;
    }

    private void MenuPanel(InputAction.CallbackContext obj)
    {
        //enable/disable the panel when pressing the button 
        m_menu.SetActive(!m_menu.activeSelf);
        if (m_menu.activeSelf)
        {
            //activate the interactors when enable 
            m_leftRayInteractor.SetActive(true);
            m_rightRayInteractor.SetActive(true);
        }
        else
        {
            //desactivate the interactor when disable 
            m_leftRayInteractor.SetActive(false);
            m_rightRayInteractor.SetActive(false);
        }
    }
}
