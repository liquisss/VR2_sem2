using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5f;
    private bool movingForward = false;

    private void Update()
    {
        // Проверяем нажатие клавиш W или S для движения вперед или назад
        float moveDirection = Input.GetAxis("Vertical");

        // Движение вперед
        if (moveDirection > 0)
        {
            movingForward = true;
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        // Движение назад
        else if (moveDirection < 0)
        {
            movingForward = false;
            transform.Translate(-Vector3.forward * speed * Time.deltaTime);
        }

        // Переворачиваем фигурку при движении назад
        if (!movingForward)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }
    }
}
