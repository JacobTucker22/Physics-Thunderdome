using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//AI is embedded in enemy class
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
          //initial add force avoids divide by zero error
          rb.AddForce(Vector3.forward);
          //initialise position var to object position
          position = rb.position;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

     private void FixedUpdate()
     {
          //FIXME stagger AI reset. looks weird when they all stop and choose new targets at once
          //20 second timer resets AI.
          //Avoids constant orbits or other infinite loops encountered in Ai
          //Also refinds nearest target to keep it fresh
          if (timer <= 0)
          {
               FindTarget();
               timer = 20.0f;
               //rb.velocity = Vector3.zero;
          }

          //AI always trying to move forward for now
          //FIXME maybe add decrease to velocity when trying to turn towards target?
          if (currentSpeed <= maxSpeed)
          {
               currentSpeed = currentSpeed + thrust * Time.deltaTime;
          }

          if (!isBouncing)
          {
               rb.velocity = rb.transform.forward * currentSpeed;
          }
          else
          {
               rb.AddForce(rb.transform.forward);
               currentSpeed = rb.velocity.magnitude;
               bounceTimer -= Time.deltaTime;
               if (bounceTimer < 0)
               {
                    isBouncing = false;
               }
          }
          //calculate time to hit
          relativeSpeed = (targetEnt.rb.velocity - rb.velocity).magnitude;
          distance = (targetEnt.rb.position - rb.position).magnitude;
          timeToHit = distance / relativeSpeed;
          
          //calculate predicted position from time to hit
          predictedPos = targetEnt.rb.position + (targetEnt.rb.velocity * timeToHit);

          //Orients enemy toward target entity
          direction = predictedPos - rb.position;
          rb.transform.forward = direction;

          //dec timer for Ai reset
          timer -= Time.deltaTime;

        
     }

     //IDEA maybe find random target to make it more unpredictrable
     //Runs through list of entities to find closet target
     //sets this enemy's target ent
     public void FindTarget()
     {
          float min = Mathf.Infinity;
          float diff;

          for (int i = 0; i < mainMenu.inst.numOfEnemies; i++)
          {
               if (EntityMgr.inst.entities[i] != this)
               {
                    diff = (rb.position - EntityMgr.inst.entities[i].rb.position).magnitude;
                    if (min > diff)
                    {
                         min = diff;
                         targetEnt = EntityMgr.inst.entities[i];
                    }
               }
          }
     }



     public void OnCollisionEnter(Collision collision)
     {


          isBouncing = true;
          bounceTimer = 1.0f;

          if (collision.gameObject.CompareTag("Entity"))
          {
               Rigidbody otherRB = collision.gameObject.GetComponent<Rigidbody>();
               rb.AddForce((collision.GetContact(0).normal * Vector3.Dot(otherRB.velocity, collision.GetContact(0).normal)) * 10, ForceMode.Impulse);
          }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            TakeDamage(1);
        }
     }

    //health
    public int maxHealth = 3;
    public int currentHealth;
    public HealthBar healthBar;

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if(currentHealth<=0)
        {
            Destroy(gameObject);
        }
       
    }
    public void Heal(int heal)
    {
        currentHealth += heal;
        healthBar.SetHealth(currentHealth);
    }

}
