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
        camera.transform.position = cameraTransforms[0].position;
        camera.transform.rotation = cameraTransforms[0].rotation;
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
            if (camera.transform == cameraTransforms[i])
            {
                cameraIndex = i;
            }
        }

        //cameraIndex = 0
        if (cameraIndex == 0)
        {
            if(key == 1)
            {

            }
            else if(key == 2)
            {

            }
            else if (key == 3)
            {

            }
            else if (key == 4)
            {

            }
        }
        //cameraIndex = 1
        if (cameraIndex == 1)
        {
            if (key == 1)
            {

            }
            else if (key == 2)
            {

            }
            else if (key == 3)
            {

            }
            else if (key == 4)
            {

            }
        }
        //cameraIndex = 2
        if (cameraIndex == 2)
        {
            if (key == 1)
            {

            }
            else if (key == 2)
            {

            }
            else if (key == 3)
            {

            }
            else if (key == 4)
            {

            }
        }
        //cameraIndex = 3
        if (cameraIndex == 3)
        {
            if (key == 1)
            {

            }
            else if (key == 2)
            {

            }
            else if (key == 3)
            {

            }
            else if (key == 4)
            {

            }
        }
        //cameraIndex = 4
        if (cameraIndex == 4)
        {
            if (key == 1)
            {

            }
            else if (key == 2)
            {

            }
            else if (key == 3)
            {

            }
            else if (key == 4)
            {

            }
        }
        //cameraIndex = 5
        if (cameraIndex == 5)
        {
            if (key == 1)
            {

            }
            else if (key == 2)
            {

            }
            else if (key == 3)
            {

            }
            else if (key == 4)
            {

            }
        }
        //cameraIndex = 6
        if (cameraIndex == 6)
        {
            if (key == 1)
            {

            }
            else if (key == 2)
            {

            }
            else if (key == 3)
            {

            }
            else if (key == 4)
            {

            }
        }
        //cameraIndex = 7
        if (cameraIndex == 7)
        {
            if (key == 1)
            {

            }
            else if (key == 2)
            {

            }
            else if (key == 3)
            {

            }
            else if (key == 4)
            {

            }
        }
    }
}
