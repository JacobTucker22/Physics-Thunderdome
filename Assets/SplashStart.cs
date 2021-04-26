using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashStart : MonoBehaviour
{
     public Button startButton;

    // Start is called before the first frame update
    void Start()
    {
          startButton.onClick.AddListener(LoadMain);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void LoadMain()
     {
          SceneManager.LoadScene("Main Menu");
     }
}
