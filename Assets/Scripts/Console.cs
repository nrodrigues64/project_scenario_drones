using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
Class : Console
Description : A class to control the in-game console
*/
public class Console : MonoBehaviour
{

    [Header("UI Components")]
    private Text consoleText;

    [SerializeField] private GameObject consoleUI;

    void Awake()
    {
        consoleText = GameObject.Find("Text_console").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClearConsole()
    {
        consoleText.text = "";
    }

    public void AddMessageToConsole(string mess)
    {
        consoleText.text += mess + "\n";
    }

}
