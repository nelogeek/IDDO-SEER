using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class object_inspection : MonoBehaviour
{
    // Preferences
    //public GameObject PlayerCamera; // Camera
    public GameObject Player; // Object with Rigidbody
    // Player
    private Rigidbody rb;
    public float speed = 20;
    // Mouse control
    private float MouseX;
    private float MouseY;
    public float mouseSpeed = 25;


    Quaternion originRotation;
    float Angle;
    
    void Start()
    {

        rb = Player.GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;

        originRotation = transform.rotation;

    }
    void FixedUpdate()
    {
        //MouseX = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;
        //MouseY = Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime;
        //transform.rotation *= Quaternion.Euler(MouseX, MouseY, 0);


        MouseX += Input.GetAxis("Mouse X") * 3;
        MouseY -= Input.GetAxis("Mouse Y") * 3;

        MouseY = Mathf.Clamp(MouseY, -60, 60);

        Quaternion rotationY = Quaternion.AngleAxis(MouseX, Vector3.up);
        Quaternion rotationX = Quaternion.AngleAxis(MouseY, Vector3.right);
        // изменение наклона камеры
        transform.rotation = originRotation * rotationY * rotationX;
    }
}
