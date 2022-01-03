using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*
Class : PauseMenu
Description : A class to control the game when paused
*/
public class PauseMenu : MonoBehaviour
{
    public static int m_DropDown_Value;
    [SerializeField] private GameObject pauseMenuUI;

    [SerializeField] private GameObject consoleUI;
    [SerializeField] public static bool isPaused = false;

    [SerializeField] private Dropdown m_Dropdown;

    [SerializeField] private Button resetButton;

    private Console console;

    
    // Start is called before the first frame update
    void Start()
    {
        m_DropDown_Value = 0;
        m_Dropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(m_Dropdown);
        });
        resetButton.onClick.AddListener (delegate { ResetScene (); });
        console = GameObject.Find("Console").GetComponent<Console>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        if(isPaused)
        {
            ActivateMenu();
        } else {
            DeactivateMenu();
        }
    }

    void ActivateMenu()
    {
        Time.timeScale = 0;
        pauseMenuUI.SetActive(true);
        consoleUI.SetActive(false);
    }

    public void DeactivateMenu()
    {
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
        consoleUI.SetActive(true);
        isPaused = false;
    }

    void DropdownValueChanged(Dropdown change)
    {
        m_DropDown_Value = change.value;
        console.ClearConsole();
    }

    void ResetScene()
    {
        SceneManager.LoadScene("StartingMenu");
    }
}
