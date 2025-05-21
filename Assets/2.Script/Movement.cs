using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Truck")]
    [SerializeField] private Transform[] wheels;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float rotateSpeedDelta;

    [Header("BG")]
    [SerializeField] private Transform backGround;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float moveSpeedDelta;

    private float maxRotateSpeed;
    private float maxMoveSpeed;
    private int collidedMonsterCount;

    private void Start()
    {
        maxRotateSpeed = rotateSpeed;
        maxMoveSpeed = moveSpeed;
    }
    private void Update()
    {
        MoveObjects();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            collidedMonsterCount++;
            CalculateSpeed();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            collidedMonsterCount--;
            CalculateSpeed();
        }
    }
    private void MoveObjects()
    {
        foreach (Transform wheel in wheels)
        {
            wheel.Rotate(0, 0, -rotateSpeed * Time.deltaTime);
        }
        backGround.Translate(-moveSpeed * Time.deltaTime, 0, 0);
    }
    private void CalculateSpeed()
    {
        rotateSpeed = maxRotateSpeed - rotateSpeedDelta * collidedMonsterCount;
        rotateSpeed = Mathf.Clamp(rotateSpeed, 0, maxRotateSpeed);
        moveSpeed = maxMoveSpeed - moveSpeedDelta * collidedMonsterCount;
        moveSpeed = Mathf.Clamp(moveSpeed, 0, maxMoveSpeed);
    }
}
