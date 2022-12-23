using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    // ����������� (Quaternion) ������������ ��� �������� �������� � Unity.
    // ���������� - ��� ���� � ��� ��������.

    // ������� ������������ ����� ��������!!!
    // ��� ��������� ������������: ������ ���������� ���������� ������ ������� ������� �����������.


    // ���������� ����������
    Quaternion originRotation;
    float Angle;
    float MouseX;
    float MouseY;

    void Start()
    {
        // ����������� ������������ ���������
        originRotation = transform.rotation;
        // ���������� �������
        Cursor.lockState = CursorLockMode.Locked;
    }

    // FixedUpate ���������� ������ 0.002 ������� (�����, ��� ������ Update, 
    // ����� �������� �������� ������� �� �������� ����������)
    void FixedUpdate()
    {
        // ���������� ��������� ����
        MouseX += Input.GetAxis("Mouse X") * 3;
        MouseY -= Input.GetAxis("Mouse Y") * 3;

        MouseY = Mathf.Clamp(MouseY, -60, 60);

        Quaternion rotationY = Quaternion.AngleAxis(MouseX, Vector3.up);
        Quaternion rotationX = Quaternion.AngleAxis(MouseY, Vector3.right);
        // ��������� ������� ������
        transform.rotation = originRotation * rotationY * rotationX;

        // ��������� ��������� ������ � ������������
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward / 9;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward / 9;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right / 9;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right / 9;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.position += transform.up / 9;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.position -= transform.up / 9;
        }
    }
}
