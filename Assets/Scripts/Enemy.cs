using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
     public Entity targetEnt;
     public float timer = -1.0f;
     public float relativeSpeed;
     public float distance;
     public float timeToHit;

     public Vector3 predictedPos;
     Vector3 eulerAngles;
     

     private void Start()
     {
          rb = GetComponent<Rigidbody>();
          rb.AddForce(Vector3.forward);
          position = rb.position;
     }

     private void FixedUpdate()
     {
          if (timer <= 0)
          {
               FindTarget();
               timer = 5.0f;
               rb.velocity = Vector3.zero;
          }


          rb.AddForce(rb.transform.forward * thrust);
          

          //calculate time to hit
          relativeSpeed = (targetEnt.rb.velocity - rb.velocity).magnitude;
          distance = (targetEnt.rb.position - rb.position).magnitude;
          timeToHit = distance / relativeSpeed;
          
          predictedPos = targetEnt.rb.position + (targetEnt.rb.velocity * timeToHit);

          //direction = predictedPos - rb.position;
          direction = predictedPos - rb.position;

          rb.transform.forward = direction;


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
