using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movee : MonoBehaviour
{
    private Transform cameraTransform; // Приватная переменная для хранения трансформа камеры
    public float moveSpeed = 5f; // Скорость движения персонажа
    public float retreatDistance = 2f; // Расстояние отступления персонажа при приближении камеры

    void OnCollisionEnter(Collision collision)
    {
        // Если есть столкновение с другим объектом
        foreach (ContactPoint contact in collision.contacts)
        {
            // Перемещаем объект на короткое расстояние в обратном направлении от точки столкновения
            transform.position -= contact.normal * 0.1f;
        }
    }

    void Start()
    {
        // Ищем объект камеры по тегу "MainCamera" и получаем его трансформ
        cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    void Update()
    {
        MovePlayer();
    }


    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        // Проверяем расстояние между камерой и персонажем
        if (cameraTransform != null)
        {
            float distanceToCamera = Vector3.Distance(transform.position, cameraTransform.position);

            if (distanceToCamera < retreatDistance)
            {
                Retreat();
            }
        }
    }

    void Retreat()
    {
        Vector3 retreatDirection = transform.position - cameraTransform.position;
        retreatDirection.y = 0f;
        retreatDirection.Normalize();

        Vector3 newPosition = transform.position + retreatDirection * moveSpeed * Time.deltaTime;

        transform.position = newPosition;
    }
}
