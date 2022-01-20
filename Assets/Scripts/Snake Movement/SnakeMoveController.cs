using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Snake.Data;

public class SnakeMoveController : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    [SerializeField] private GameObject BodyPrefabRed;
    [SerializeField] private GameObject BodyPrefab;

    private List<GameObject> bodyParts = new List<GameObject>();
    private List<Vector3> positionHistory = new List<Vector3>();

    public float moveSpeed = 5;
    public float steerSpeed = 90;
    public int gap = Mathf.Abs(10);
    public int fark = 5;

    public bool rigtFlag = false;
    public bool leftFlag = false;
    public bool grow = false;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0;i<= 100; i++)
        {
            growSnake();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameData.GameState)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;

            if (rigtFlag)
            {
                right();
            }

            if (leftFlag)
            {
                left();
            }

            //store position history
            positionHistory.Insert(0, transform.position);

            if(positionHistory.Count == 5000)
            {
                positionHistory.RemoveAt(positionHistory.Count - 1);
            }
            Debug.Log(positionHistory.Count);

            //move body parts
            if(positionHistory.Count > fark)
            {
                int index = fark;
                foreach (var body in bodyParts)
                {
                    Vector3 point = positionHistory[Mathf.Min(index * gap, positionHistory.Count - 1)];
                    body.transform.position = point;
                    index++;
                }
            }
        }

        if (grow)
        {
            growSnake();
            grow = false;
        }
    }

    private void growSnake()
    {
        GameObject body;
        if (bodyParts.Count <= 5)
        {
            body = Instantiate(BodyPrefabRed);
        }
        else
        {
            body = Instantiate(BodyPrefab);
        }
        bodyParts.Add(body);
    }

    public void right()
    {
        transform.Rotate(Vector3.up * steerSpeed * Time.deltaTime);
    }

    public void left()
    {
        transform.Rotate(-Vector3.up * steerSpeed * Time.deltaTime);
    }

    public void leftDown()
    {
        leftFlag = true;
    }

    public void rightDown()
    {
        rigtFlag = true;
    }

    public void leftUp()
    {
        leftFlag = false;
    }

    public void rightUp()
    {
        rigtFlag = false;
    }
}
