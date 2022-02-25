using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject moveObject;
    public GameObject goalPoint;

    Vector3 move_Position;
    Vector3 toGoPoint;

    float moveSpeed = 0.01f; //�ړ����x�@

    void Start()
    {
        move_Position = moveObject.transform.position; //�ړ����������I�u�W�F�N�g�̍��W
        toGoPoint = goalPoint.transform.position;      //�ړI�n�ɐݒu�����I�u�W�F�N�g�̍��W
    }

    void Update()
    {
        if (move_Position.z > toGoPoint.z)
        {
            move_Position.z -= moveSpeed;
            moveObject.transform.position = move_Position;
        }

    }
}
