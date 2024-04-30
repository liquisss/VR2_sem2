using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movee : MonoBehaviour
{
    private Transform cameraTransform; // ��������� ���������� ��� �������� ���������� ������
    public float moveSpeed = 5f; // �������� �������� ���������
    public float retreatDistance = 2f; // ���������� ����������� ��������� ��� ����������� ������

    void OnCollisionEnter(Collision collision)
    {
        // ���� ���� ������������ � ������ ��������
        foreach (ContactPoint contact in collision.contacts)
        {
            // ���������� ������ �� �������� ���������� � �������� ����������� �� ����� ������������
            transform.position -= contact.normal * 0.1f;
        }
    }

    void Start()
    {
        // ���� ������ ������ �� ���� "MainCamera" � �������� ��� ���������
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

        // ��������� ���������� ����� ������� � ����������
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
