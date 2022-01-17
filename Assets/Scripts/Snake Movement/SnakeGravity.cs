using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeGravity : MonoBehaviour
{
    const float G = 667.4F;

    public Rigidbody rb;

    public GameObject targetObject;

    private void Start()
    {

    }
    private void FixedUpdate()
    {
        
        //SnakeGravity[] snakeGravities = FindObjectsOfType<SnakeGravity>();
        //foreach(SnakeGravity snakeGravity in snakeGravities)
        //{
        //    if(snakeGravity != this)
        //    {
        //        Attract(snakeGravity);
        //    }
        //}

        Attract(this);
    }

    void Attract(SnakeGravity objToAttract)
    {
        GameObject rbToAttract = objToAttract.targetObject;

        Vector3 direction = rbToAttract.transform.position - rb.position;
        float distance = direction.magnitude;

        float forceMagnitude = G * (rb.mass * 1) / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forceMagnitude;

        rb.AddForce(force);
    }
}
