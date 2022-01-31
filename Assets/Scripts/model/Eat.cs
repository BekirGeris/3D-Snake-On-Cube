using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Snake.UIController;

public class Eat : MonoBehaviour
{
    [SerializeField] private EatController eatController;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        string collisionName = collision.gameObject.name;
        if (collisionName.Length > 7)
        {
            Debug.Log(collisionName.Substring(collisionName.Length - 7));
            if (collisionName.Substring(collisionName.Length - 7).Equals("(Clone)"))
            {
                gameObject.SetActive(false);
                eatController.randomItemOpenFromList();
            }
        }
    }

}
