using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{

     
public void QuitGame()
    {
        // save any game data here
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

    private void Update()
    {
        HandleInput();
    }
    public void HandleInput()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
        if(Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene("Main Menu");
    }
}
