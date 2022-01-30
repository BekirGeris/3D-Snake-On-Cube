using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMovementController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] public List<Transform> cameraTransforms;

    [SerializeField] public GameObject camera;

    [SerializeField] private float moveSpeed = 0.5f;

    private Vector2 fingerFirstLocation;
    private Vector3 rotateValue;

    public float distanceX;
    public float distanceY;

    private void Start()
    {
        setCameraTrasformWithIndex(0);
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        fingerFirstLocation = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        distanceX = eventData.position.x - fingerFirstLocation.x;
        distanceY = eventData.position.y - fingerFirstLocation.y;

        selectCameraTransform();
    }

    private void selectCameraTransform()
    {
        if (distanceX != 0 && distanceY != 0)
        {
            if (distanceY < 0 && Mathf.Abs(distanceY) > Mathf.Abs(distanceX))
            {
                //up
                setSelectedCameraTransform(1);
            }

            if (distanceY > 0 && Mathf.Abs(distanceY) > Mathf.Abs(distanceX))
            {
                //down
                setSelectedCameraTransform(2);
            }

            if (distanceX < 0 && Mathf.Abs(distanceX) > Mathf.Abs(distanceY))
            {
                //right
                setSelectedCameraTransform(3);
            }

            if (distanceX > 0 && Mathf.Abs(distanceX) > Mathf.Abs(distanceY))
            {
                //left
                setSelectedCameraTransform(4);
            }
        }
    }

    private void setSelectedCameraTransform(int key)
    {
        int cameraIndex = 0;
        for (int i = 0; i < cameraTransforms.Count; i++)
        {
            if (camera.transform.position == cameraTransforms[i].position)
            {
                cameraIndex = i;
            }
        }

        //cameraIndex = 0
        if (cameraIndex == 0)
        {
            if(key == 1)//up 
            {
                setCameraTrasformWithIndex(2);
            }
            else if(key == 2)//down
            {
                setCameraTrasformWithIndex(4);
            }
            else if (key == 3)//right
            {
                setCameraTrasformWithIndex(1);
            }
            else if (key == 4)//left
            {
                setCameraTrasformWithIndex(3);
            }
        }
        //cameraIndex = 1
        if (cameraIndex == 1)
        {
            if (key == 1)//up 
            {
                setCameraTrasformWithIndex(3);
            }
            else if (key == 2)//down
            {
                setCameraTrasformWithIndex(5);
            }
            else if (key == 3)//right
            {
                setCameraTrasformWithIndex(2);
            }
            else if (key == 4)//left
            {
                setCameraTrasformWithIndex(0);
            }
        }
        //cameraIndex = 2
        if (cameraIndex == 2)
        {
            if (key == 1)//up 
            {
                setCameraTrasformWithIndex(0);
            }
            else if (key == 2)//down
            {
                setCameraTrasformWithIndex(6);
            }
            else if (key == 3)//right
            {
                setCameraTrasformWithIndex(3);
            }
            else if (key == 4)//left
            {
                setCameraTrasformWithIndex(1);
            }
        }
        //cameraIndex = 3
        if (cameraIndex == 3)
        {
            if (key == 1)//up 
            {
                setCameraTrasformWithIndex(1);
            }
            else if (key == 2)//down
            {
                setCameraTrasformWithIndex(7);
            }
            else if (key == 3)//right
            {
                setCameraTrasformWithIndex(0);
            }
            else if (key == 4)//left
            {
                setCameraTrasformWithIndex(2);
            }
        }
        //cameraIndex = 4
        if (cameraIndex == 4)
        {
            if (key == 1)//up 
            {
                setCameraTrasformWithIndex(0);
            }
            else if (key == 2)//down
            {
                setCameraTrasformWithIndex(6);
            }
            else if (key == 3)//right
            {
                setCameraTrasformWithIndex(5);
            }
            else if (key == 4)//left
            {
                setCameraTrasformWithIndex(7);
            }
        }
        //cameraIndex = 5
        if (cameraIndex == 5)
        {
            if (key == 1)//up 
            {
                setCameraTrasformWithIndex(1);
            }
            else if (key == 2)//down
            {
                setCameraTrasformWithIndex(7);
            }
            else if (key == 3)//right
            {
                setCameraTrasformWithIndex(6);
            }
            else if (key == 4)//left
            {
                setCameraTrasformWithIndex(4);
            }
        }
        //cameraIndex = 6
        if (cameraIndex == 6)
        {
            if (key == 1)//up 
            {
                setCameraTrasformWithIndex(2);
            }
            else if (key == 2)//down
            {
                setCameraTrasformWithIndex(4);
            }
            else if (key == 3)//right
            {
                setCameraTrasformWithIndex(7);
            }
            else if (key == 4)//left
            {
                setCameraTrasformWithIndex(5);
            }
        }
        //cameraIndex = 7
        if (cameraIndex == 7)
        {
            if (key == 1)//up 
            {
                setCameraTrasformWithIndex(3);
            }
            else if (key == 2)//down
            {
                setCameraTrasformWithIndex(5);
            }
            else if (key == 3)//right
            {
                setCameraTrasformWithIndex(4);
            }
            else if (key == 4)//left
            {
                setCameraTrasformWithIndex(6);
            }
        }
    }

    public void setCameraTrasformWithIndex(int index)
    {
        camera.transform.position = cameraTransforms[index].position;
        camera.transform.rotation = cameraTransforms[index].rotation;
    }
}
