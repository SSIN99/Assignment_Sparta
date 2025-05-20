using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    [Header("Truck")]
    [SerializeField] private Transform[] wheels;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float rotateSpeedDelta;

    [Header("BG")]
    [SerializeField] private Transform backGround;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float moveSpeedDelta;

    private int collidedMonsterCount;
    private float maxRotateSpeed;
    private float maxMoveSpeed;

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
            rotateSpeed = Mathf.Max(0, rotateSpeed - rotateSpeedDelta * collidedMonsterCount);
            moveSpeed = Mathf.Max(0, moveSpeed - moveSpeedDelta * collidedMonsterCount);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            collidedMonsterCount--;
            rotateSpeed = Mathf.Min(maxRotateSpeed, rotateSpeed + rotateSpeedDelta * collidedMonsterCount);
            moveSpeed = Mathf.Min(maxMoveSpeed, moveSpeed + moveSpeedDelta * collidedMonsterCount);
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
}
