using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Main parent class. Player and enemies inherit from this
//Holds all info common to enemies and player
public class Entity : MonoBehaviour
{
     public Rigidbody rb;
     public float thrust = 5.0f;
     //FIXME Max and Min speed don't do anything yet
     public float maxSpeed = 20;
     public float minSpeed = -5;
     //To be put in UI
     public float currentSpeed = 0;

     //Used for AI
     public Vector3 position, velocity;
     public Vector3 direction = Vector3.zero;

}
