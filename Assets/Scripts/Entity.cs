using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
     public Rigidbody rb;
     public float thrust = 5.0f;
     public float maxSpeed = 20;
     public float minSpeed = -5;
     public float currentSpeed = 0;
     public Vector3 position, velocity;
     public Vector3 direction = Vector3.zero;

}
