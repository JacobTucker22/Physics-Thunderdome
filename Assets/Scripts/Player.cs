using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Entity
{
     //euler angles used to transforom orientation with mouse
     public Vector3 eulerAngles = Vector3.zero;

     private void Start()
     {
          rb = GetComponent<Rigidbody>();
          //mouse cursor hidden. Use ESCAPE to quit
          Cursor.visible = false;

          collisionSound = GetComponent<AudioSource>();
          currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

     }
    float waitTime = 2.0f;
     private void Update()
     {
          //Moves the player orientation with mouse movement
          //Which then moves the camera
          moveCamera();
          //Basic keyboard controls
          HandleInput();
        //ram
        if (!ram)
        {
            new WaitForSeconds(ramTimer);
            maxSpeed = 500;
            currentSpeed = maxSpeed;
            ram = true;
        }
    }

     //WS add/subtract from current speed
     //Space stops the player for testing purposes 
     //FIXME change stop to something else. Space and Click to be used for ram
     public void HandleInput()
     {
          if(Input.GetKey(KeyCode.W)) 
          {
               if (currentSpeed <= maxSpeed)
               {
                    currentSpeed = currentSpeed + thrust * Time.deltaTime;
               }
          }
          if (Input.GetKey(KeyCode.S))
          {
               if (currentSpeed >= minSpeed)
               {
                    currentSpeed = currentSpeed - thrust * Time.deltaTime;
               }
          }
          if (Input.GetKey(KeyCode.D))
          {
               rb.MovePosition(rb.position + rb.transform.right * 3);              
          }
          if (Input.GetKey(KeyCode.A))
          {
               rb.MovePosition(rb.position - rb.transform.right * 3);
          }
          if(Input.GetKeyDown(KeyCode.Space))  
          {
            if(ram)
            {
                maxSpeed = 1000;
                currentSpeed = maxSpeed;
                ram = false;
            }
          }
          if (Input.GetKeyDown(KeyCode.Escape))
          {
               QuitGame();
          }
          

     }
    int ramTimer = 2;
    bool ram = true;
     //transforms rigidbody component based on mouse movement
     public void moveCamera()
     {

          float x = 5 * Input.GetAxis("Mouse X");
          float y = 5 * -Input.GetAxis("Mouse Y");
          rb.transform.Rotate(y, x, 0);
          eulerAngles = rb.transform.localEulerAngles;
          eulerAngles.z = 0;
          rb.transform.localEulerAngles = eulerAngles;

          //keeps velocity moving in forward direction
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
          
     }

     //ESC will close program or stop play in editor
     public void QuitGame()
     {
          // save any game data here
#if UNITY_EDITOR
          // Application.Quit() does not work in the editor so
          // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
          UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
     }

    //audio
    public AudioSource collisionSound;
    private void OnCollisionEnter(Collision collision)
    {
         collisionSound.Play();

          isBouncing = true;
          bounceTimer = 0.5f;

          if (collision.gameObject.CompareTag("Entity"))
          {
               Rigidbody otherRB = collision.gameObject.GetComponent<Rigidbody>();
               rb.AddForce((collision.GetContact(0).normal * Vector3.Dot(otherRB.velocity, collision.GetContact(0).normal)) * 10, ForceMode.Impulse);
          }
          if(collision.gameObject.CompareTag("Obstacle"))
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
        if (currentHealth <= 0)
        {
               Debug.Log("GAME OVER");
               Cursor.visible = true;
               SceneManager.LoadScene("Defeat Credits");
               //QuitGame();
        }
            
    }
    public void Heal(int heal)
    {
        currentHealth += heal;
        healthBar.SetHealth(currentHealth);
    }
}
