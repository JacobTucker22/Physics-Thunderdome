using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Singleton just holds list of all entities
//Used in enemy AI
public class EntityMgr : MonoBehaviour
{
     public static EntityMgr inst;

     public List<Entity> entities;

     private void Awake()
     {
          inst = this;
          for (int i = 0; i < entities.Count - 1; i++)
          {
               entities[i + 1].transform.gameObject.SetActive(false);
          }
     }

     // Start is called before the first frame update
     void Start()
     {
          for(int i = 0; i < mainMenu.inst.numOfEnemies; i++)
          {
               entities[i + 1].transform.gameObject.SetActive(true);
          }
     }

     // Update is called once per frame
     void Update()
     {

     }
}
