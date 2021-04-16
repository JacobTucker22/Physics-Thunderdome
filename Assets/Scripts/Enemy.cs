using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
     public Entity targetEnt;
     public float timer = 5.0f;

     private void Start()
     {
          rb = GetComponent<Rigidbody>();
     }

     private void FixedUpdate()
     {
          if (timer < 0)
          {
               FindTarget();
               timer = 5.0f;
          }

          direction = (targetEnt.rb.position - rb.position);

          rb.AddForce(direction * thrust);

          timer -= Time.deltaTime;
     }

     public void FindTarget()
     {
          float min = Mathf.Infinity;
          float diff;
          
          foreach(Entity ent in EntityMgr.inst.entities)
          {
               if (ent != this)
               {
                    diff = (rb.position - ent.rb.position).magnitude;
                    if(min > diff)
                    {
                         min = diff;
                         targetEnt = ent;
                    }
               }
          }
     }
     
}
