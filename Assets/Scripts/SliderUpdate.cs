using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderUpdate : MonoBehaviour
{
     public Text numOfEnemies;
     public Slider numEnemiesSlider;

     public void updateNumberOfEnemies()
     {
          numOfEnemies.text = numEnemiesSlider.value.ToString();
     }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
