using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMgr : MonoBehaviour
{
     public Text remainingText, ramReadyText;

    public static UIMgr inst;
    // Start is called before the first frame update
    void Start()
    {
        inst = this;
    }

    // Update is called once per frame
    void Update()
    {
          ramReadyText.text = (Player.inst.waitTime > 0) ? "WAIT" : "READY";
          ramReadyText.color = (Player.inst.waitTime > 0) ? Color.red : Color.green;

          remainingText.text = mainMenu.inst.numOfEnemies.ToString(); 
     }
    Text healthText;
    public Slider slider;
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth (int health)
    {
        slider.value = health;
    }


}
