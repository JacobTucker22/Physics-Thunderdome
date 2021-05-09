using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
     public static mainMenu inst;
     //name of scene to be loaded
     public string chosenScene = null;

     //var will be used to set the number of enemy AI in loaded level
     public int numOfEnemies;
     //text displaying how many enemies and slider
     public Text numOfEnemiesText;
     public Slider numEnemiesSlider;

     //text showing which level is currently selected
     public Text selectedLevelText;
     //buttons
     public Button tunnelButton, domeButton, startButton;

     private void Awake()
     {
          inst = this;
          DontDestroyOnLoad(transform.gameObject);
     }

     private void Start()
     {
          Cursor.lockState = CursorLockMode.None;
     }

     //slider function updates number of enemies and text when slider moves
     public void updateNumberOfEnemies()
     {
          numOfEnemiesText.text = numEnemiesSlider.value.ToString();
          numOfEnemies = (int)numEnemiesSlider.value;
     }

     //tunnel and dome button functions
     public void selectTunnel()
     {
          chosenScene = tunnelButton.GetComponentInChildren<Text>().text;
          selectedLevelText.text = chosenScene;
     }

     public void selectDome()
     {
          chosenScene = domeButton.GetComponentInChildren<Text>().text;
          selectedLevelText.text = chosenScene;
     }

     //start game loads currently selected level
     //FIXME add function to load desired number of entites
     public void StartGame()
     {
          if (chosenScene == "")
          {
               Debug.Log("No Level Selected");
          }
          else
          {
               Cursor.lockState = CursorLockMode.Locked;
               SceneManager.LoadScene(chosenScene);
          }

     }
}
