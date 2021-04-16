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
