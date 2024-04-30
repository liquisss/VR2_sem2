using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float moveSpeed = 3f; // Скорость движения камеры
    public float rotateSpeed = 1f; // Скорость вращения камеры

    void Update()
    {
        // Движение камеры
        MoveCamera();

        // Вращение камеры при нажатии левой кнопки мыши
        if (Input.GetMouseButton(0))
        {
            RotateCamera();
        }

    }

    void MoveCamera()
    {
        // Движение камеры вперед
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }

        // Движение камеры назад
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }

        // Движение камеры влево
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }

        // Движение камеры вправо
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
    }

    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Вращение камеры по горизонтали
        transform.Rotate(Vector3.up * mouseX * rotateSpeed);

        // Вращение камеры по вертикали с ограничением угла обзора
        float newRotationX = transform.eulerAngles.x - mouseY * rotateSpeed;
        transform.rotation = Quaternion.Euler(newRotationX, transform.eulerAngles.y, 0f);
    }


}
