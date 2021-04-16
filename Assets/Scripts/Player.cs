using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
     public Vector3 eulerAngles = Vector3.zero;
     private void Start()
     {
          rb = GetComponent<Rigidbody>();
          //mouse cursor hidden. Use ESCAPE to quit
          Cursor.visible = false;
     }

     private void Update()
     {
          if(Input.GetKeyDown(KeyCode.Escape))
          {
               QuitGame();
          }

          moveCamera();


     }

     public void moveCamera()
     {
          float x = 5 * Input.GetAxis("Mouse X");
          float y = 5 * -Input.GetAxis("Mouse Y");
          rb.transform.Rotate(y, x, 0);
          eulerAngles = rb.transform.localEulerAngles;
          eulerAngles.z = 0;
          rb.transform.localEulerAngles = eulerAngles;
     }

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
}
