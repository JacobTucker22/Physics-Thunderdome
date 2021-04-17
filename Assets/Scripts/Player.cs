using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

     private void Update()
     {
          //Moves the player orientation with mouse movement
          //Which then moves the camera
          moveCamera();
          //Basic keyboard controls
          HandleInput();


     }

     //WASD adds velocity to local axes
     //Seems to work better than add force
     //Space stops the player for testing purposes 
     //FIXME change stop to something else. Space and Click to be used for ram
     public void HandleInput()
     {
          if(Input.GetKey(KeyCode.W)) 
          {
               rb.velocity = rb.velocity + rb.transform.forward * thrust;
               //rb.AddForce(rb.transform.forward * thrust);
          }
          if (Input.GetKey(KeyCode.S))
          {
               rb.velocity = rb.velocity - rb.transform.forward * thrust;
               //rb.AddForce(-rb.transform.forward * thrust);
          }
          if (Input.GetKey(KeyCode.D))
          {
               rb.velocity = rb.velocity + rb.transform.right * thrust;
          }
          if (Input.GetKey(KeyCode.A))
          {
               rb.velocity = rb.velocity - rb.transform.right * thrust;
          }
          if(Input.GetKey(KeyCode.Space))  
          {
               rb.velocity = Vector3.zero;
          }
          if (Input.GetKeyDown(KeyCode.Escape))
          {
               QuitGame();
          }
     }

     //transforms rigidbody component based on mouse movement
     public void moveCamera()
     {
          float x = 5 * Input.GetAxis("Mouse X");
          float y = 5 * -Input.GetAxis("Mouse Y");
          rb.transform.Rotate(y, x, 0);
          eulerAngles = rb.transform.localEulerAngles;
          eulerAngles.z = 0;
          rb.transform.localEulerAngles = eulerAngles;
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
    }
    //health
    public int maxHealth = 100;
    public int currentHealth;
    public UIMgr healthBar;
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
