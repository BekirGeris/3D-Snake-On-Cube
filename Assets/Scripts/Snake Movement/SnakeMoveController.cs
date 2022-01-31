using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Snake.Data;
using Snake.UIController;

public class SnakeMoveController : MonoBehaviour, AdsStatae
{
    [SerializeField] private GameData gameData;
    [SerializeField] private SnakeData snakeData;
    [SerializeField] private EatController eatController;
    [SerializeField] private GamePanelController gamePanelController;

    private List<GameObject> bodyParts = new List<GameObject>();
    private List<GameObject> snakeTails = new List<GameObject>();
    private List<Vector3> positionHistory = new List<Vector3>();

    private Vector3 localScale;
    private float snakeLength;
    private Vector3 snakeFirstPosition;
    private Quaternion snakeFirstRotation;

    public float moveSpeed = 5;
    public float steerSpeed = 90;
    public int gap = Mathf.Abs(10);

    private bool rigtFlag = false;
    private bool leftFlag = false;

    private bool isBurn = true;
    private float distance = float.MaxValue;

    // Update is called once per frame
    void Update()
    {
        if (gameData.GameState)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;

            orientationSnake();

            storePositionHistory();

            moveBodyParts();

            didTheSnakeBurn();
        }
    }

    private void didTheSnakeBurn()
    {
        distance = float.MaxValue;
        foreach (GameObject snakeTail in snakeTails)
        {
            if ((snakeTail.transform.position - transform.position).magnitude < distance)
            {
                distance = (snakeTail.transform.position - transform.position).magnitude;
            }
        }

        if (distance < 1 && isBurn)
        {
            if (PlayerPrefs.GetInt("reklam izlendimi", 0) == 0)
            {
                gamePanelController.openAdsPanel(this);
            }
            else
            {
                finishGame();
                gamePanelController.openEndPanel();
            }
            rigtFlag = false;
            leftFlag = false;
            isBurn = false;
        }

        if(distance > 2)
        {
            isBurn = true;
        }
    }

    private void orientationSnake()
    {
        if (rigtFlag)
        {
            right();
        }

        if (leftFlag)
        {
            left();
        }
    }

    private void storePositionHistory()
    {
        //store position history
        positionHistory.Insert(0, transform.position);

        if (positionHistory.Count == 5000)
        {
            positionHistory.RemoveAt(positionHistory.Count - 1);
        }
    }
    private void moveBodyParts()
    { //
        //move body parts
        int index = 0;
        foreach (var body in bodyParts)
        {
            Vector3 point = positionHistory[Mathf.Min(index * gap, positionHistory.Count - 1)];
            body.transform.position = point;
            body.transform.localScale = localScale * (snakeLength / (snakeLength + index));
            index++;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name.Equals("eat"))
        {
            collision.gameObject.SetActive(false);
            eatController.randomItemOpenFromList();
            growSnake();
            growSnake();
            growSnake();
            growSnake();
            growSnake();
            if(bodyParts.Count <= 300)
            {
                growSnake();
                growSnake();
                growSnake();
                growSnake();
                growSnake();
            }
        }
    }

    private void growSnake()
    {
        GameObject body;
        if (bodyParts.Count <= 5 || bodyParts.Count % 2 == 0)
        {
            if(PlayerPrefs.GetInt("selectImage", -1) == 1)
            {
                body = Instantiate(snakeData.bodyRed);
            }
            else if (PlayerPrefs.GetInt("selectImage", -1) == 2)
            {
                body = Instantiate(snakeData.bodyYellow);
            }
            else if (PlayerPrefs.GetInt("selectImage", -1) == 3)
            {
                body = Instantiate(snakeData.bodyPurple);
            }
            else if (PlayerPrefs.GetInt("selectImage", -1) == 4)
            {
                body = Instantiate(snakeData.bodyGreen);
            }
            else if (PlayerPrefs.GetInt("selectImage", -1) == 5)
            {
                body = Instantiate(snakeData.bodyRed);
            }
            else if (PlayerPrefs.GetInt("selectImage", -1) == 6)
            {
                body = Instantiate(snakeData.bodyTurquoise);
            }
            else
            {
                body = Instantiate(snakeData.bodyRed);
            }
        }
        else
        {
            if (PlayerPrefs.GetInt("selectImage", -1) == 1)
            {
                body = Instantiate(snakeData.bodyGrey);
            }
            else if (PlayerPrefs.GetInt("selectImage", -1) == 2)
            {
                body = Instantiate(snakeData.bodyGreen);
            }
            else if (PlayerPrefs.GetInt("selectImage", -1) == 3)
            {
                body = Instantiate(snakeData.bodyGreen);
            }
            else if (PlayerPrefs.GetInt("selectImage", -1) == 4)
            {
                body = Instantiate(snakeData.bodyBlack);
            }
            else if (PlayerPrefs.GetInt("selectImage", -1) == 5)
            {
                body = Instantiate(snakeData.bodyBlack);
            }
            else if (PlayerPrefs.GetInt("selectImage", -1) == 6)
            {
                body = Instantiate(snakeData.bodyBlack);
            }
            else
            {
                body = Instantiate(snakeData.bodyGrey);
            }
        }

        if (bodyParts.Count > 25)
        {
            snakeTails.Add(body);
        }
        bodyParts.Add(body);
        snakeLength = bodyParts.Count;
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

    public void adsSkiped()
    {
        finishGame();
    }

    public void startGame()
    {
        snakeFirstPosition = transform.position;
        snakeFirstRotation = transform.rotation;
        localScale = snakeData.bodyGrey.transform.localScale;
        for (int i = 0; i <= 25; i++)
        {
            growSnake();
        }
    }
    public void finishGame()
    {
        Debug.Log("finishGame");
        transform.position = snakeFirstPosition;
        transform.rotation = snakeFirstRotation;
        foreach(GameObject g in bodyParts)
        {
            Destroy(g);
        }
        bodyParts.Clear();
        snakeTails.Clear();
        positionHistory.Clear();
    }
}
