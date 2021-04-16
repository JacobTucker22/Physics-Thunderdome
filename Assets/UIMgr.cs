using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMgr : MonoBehaviour
{
    public static UIMgr inst;
    // Start is called before the first frame update
    void Start()
    {
        inst = this;
    }

    // Update is called once per frame
    void Update()
    {
        //healthText.text = Player.currentHealth
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
