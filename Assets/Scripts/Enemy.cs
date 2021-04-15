using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{

     Rigidbody rb;

     private void Start()
     {
          rb = GetComponent<Rigidbody>();
     }

     private void FixedUpdate()
     {
          rb.AddForce(0, -1, 0);
     }
}
