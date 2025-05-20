using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    [Header("Truck")]
    [SerializeField] private Transform[] wheels;
    [SerializeField] private float startRotateSpeed;
    [SerializeField] private float rotateReductionAmount;

    [Header("BG")]
    [SerializeField] private Transform backGround;
    [SerializeField] private float startMoveSpeed;
    [SerializeField] private float moveReductionAmount;

    private int collidedMonsterCount;

    private void Update()
    {
        RotateWheel();
        MoveBackGround();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            collidedMonsterCount++;
            Debug.Log("asd");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            collidedMonsterCount--;
            Debug.Log("dd");
        }
    }
    private void RotateWheel()
    {
        float rotationSpeed = Mathf.Max(0, startRotateSpeed - rotateReductionAmount * collidedMonsterCount);
        foreach (Transform wheel in wheels)
        {
            wheel.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        }
    }
    private void MoveBackGround()
    {
        float moveSpeed = Mathf.Max(0, startMoveSpeed - moveReductionAmount * collidedMonsterCount);
        backGround.Translate(-moveSpeed * Time.deltaTime, 0, 0);
    }
}
