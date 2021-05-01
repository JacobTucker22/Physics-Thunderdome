using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Main parent class. Player and enemies inherit from this
//Holds all info common to enemies and player
public class Entity : MonoBehaviour
{
     public Rigidbody rb;
     public float thrust = 200.0f;
     public float maxSpeed = 500;
     public float minSpeed = -250;
     //To be put in UI
     public float currentSpeed = 0;

     public bool isBouncing = false;
     public float bounceTimer = 1.0f;

     //Used for AI
     public Vector3 position, velocity;
     public Vector3 direction = Vector3.zero;

     public virtual void TakeDamage(int damage) { }

}
