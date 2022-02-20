using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatController : MonoBehaviour
{
    private Eat[] eats;

    
    // Start is called before the first frame update
    void Start()
    {
        eats = FindObjectsOfType<Eat>();
        foreach(Eat eat in eats)
        {
            eat.gameObject.SetActive(false);
        }
        randomItemOpenFromList();
        randomItemOpenFromList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void randomItemOpenFromList()
    {
        int randomIndex;
        randomIndex = Random.Range(0, eats.Length - 1);
        if(eats[randomIndex].gameObject.active == true)
        {
            randomItemOpenFromList();
        }
        else
        {
            int activeEatSize = 0;
            foreach(Eat eat in eats)
            {
                if(eat.gameObject.active == true)
                {
                    activeEatSize++;
                }
            }
            if(activeEatSize < 2)
            {
                eats[randomIndex].gameObject.SetActive(true);
            }
            else
            {
                return;
            }
        }
    }

}
