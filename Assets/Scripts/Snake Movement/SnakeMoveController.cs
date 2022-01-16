using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Snake.Data;

public class SnakeMoveController : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    [SerializeField] private GameObject BodyPrefab;

    private List<GameObject> bodyParts = new List<GameObject>();
    private List<Vector3> positionHistory = new List<Vector3>();

    public float moveSpeed = 5;
    public float steerSpeed = 90;
    public int gap = 10;

    public bool rigtFlag = false;
    public bool leftFlag = false;
    public bool grow = false;

    // Start is called before the first frame update
    void Start()
    {

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

            //move body parts
            int index = 0;
            foreach (var body in bodyParts)
            {
                Vector3 point = positionHistory[Mathf.Min(index * gap, positionHistory.Count - 1)];
                body.transform.position = point;
                index++;
            }
            Debug.Log(positionHistory.Count);
        }

        if (grow)
        {
            growSnake();
            grow = false;
        }
    }

    private void growSnake()
    {
        GameObject body = Instantiate(BodyPrefab);
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
