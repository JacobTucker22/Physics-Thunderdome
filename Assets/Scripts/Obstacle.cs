using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public Rigidbody rb;
    public float thrust = 0f;
    public float maxSpeed = 20;
    public float minSpeed = -20;
    //To be put in UI
    public float currentSpeed = 0;

    private float movementDuration = 2.0f;
    private float waitBeforeMoving = 1.0f;
    private bool hasArrived = false;


    //Used for AI
    public Vector3 position, velocity;
    public Vector3 direction = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasArrived)
        {
            hasArrived = true;
            float randX = Random.Range(-500.0f, 700.0f);
            float randZ = Random.Range(-500.0f, 2100.0f);
            float randY = Random.Range(-180.0f, 200.0f);
            StartCoroutine(MoveToPoint(new Vector3(randX, randY, randZ)));
        }
    }

    private IEnumerator MoveToPoint(Vector3 targetPos)
    {
        float timer = 0.0f;
        Vector3 startPos = transform.position;

        while (timer < movementDuration)
        {
            timer += Time.deltaTime;
            float t = timer / movementDuration;
            t = t * t * t * (t * (6f * t - 15f) + 10f);
            transform.position = Vector3.Lerp(startPos, targetPos, t);

            yield return null;
        }
        yield return new WaitForSeconds(waitBeforeMoving);
        hasArrived = false;
    }
}
