using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{

     public string chosenScene = null;

     public int numOfEnemies;
     public Text numOfEnemiesText;
     public Slider numEnemiesSlider;

     public Text selectedLevelText;
     public Button tunnelButton, domeButton, startButton;

     public void updateNumberOfEnemies()
     {
          numOfEnemiesText.text = numEnemiesSlider.value.ToString();
          numOfEnemies = (int)numEnemiesSlider.value;
     }

     public void selectTunnel()
     {
          chosenScene = tunnelButton.GetComponentInParent<Text>().text;
          selectedLevelText.text = chosenScene;
     }

     public void selectDome()
     {
          chosenScene = domeButton.GetComponentInParent<Text>().text;
          selectedLevelText.text = chosenScene;
     }

     public void StartGame()
     {
          if(chosenScene == null)
          {
               Debug.Log("No Level Selected");
          }
          else
          {
               SceneManager.LoadScene(chosenScene);
          }

     }
}
