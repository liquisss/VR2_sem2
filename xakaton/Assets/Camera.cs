using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float moveSpeed = 3f; // �������� �������� ������
    public float rotateSpeed = 1f; // �������� �������� ������

    void Update()
    {
        // �������� ������
        MoveCamera();

        // �������� ������ ��� ������� ����� ������ ����
        if (Input.GetMouseButton(0))
        {
            RotateCamera();
        }

    }

    void MoveCamera()
    {
        // �������� ������ ������
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }

        // �������� ������ �����
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }

        // �������� ������ �����
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }

        // �������� ������ ������
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
    }

    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // �������� ������ �� �����������
        transform.Rotate(Vector3.up * mouseX * rotateSpeed);

        // �������� ������ �� ��������� � ������������ ���� ������
        float newRotationX = transform.eulerAngles.x - mouseY * rotateSpeed;
        transform.rotation = Quaternion.Euler(newRotationX, transform.eulerAngles.y, 0f);
    }


}
