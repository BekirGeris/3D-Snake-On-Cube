using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeGravity : MonoBehaviour
{
    const float G = 1000f;

    private List<Transform> targetObjects = new List<Transform>();
    private Cube[] cubes;

    [SerializeField] private Rigidbody rb;

    private Transform nearestTargetObject;

    private void Start()
    {
        cubes = FindObjectsOfType<Cube>();
        foreach(var cube in cubes)
        {
            targetObjects.Add(cube.transform);
        }
    }
    private void FixedUpdate()
    {
        float distance = float.MaxValue;
        int nearestTargetIndex = 0;
        for(int i = 0;i < targetObjects.Count; i++)
        {
            if((targetObjects[i].transform.position - rb.position).magnitude <= distance)
            {
                distance = (targetObjects[i].transform.position - rb.position).magnitude;
                nearestTargetIndex = i;
            }
        }
        nearestTargetObject = targetObjects[nearestTargetIndex];

        Attract(nearestTargetObject, distance);
    }

    void Attract(Transform rbToAttract, float distance)
    {
        Vector3 direction = rbToAttract.position - rb.position;

        float forceMagnitude = G * (rb.mass * 1) / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forceMagnitude;

        rb.AddForce(force);
    }
}
