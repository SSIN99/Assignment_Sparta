using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float weight;

    private Rigidbody2D rb;
    private Animator ani;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(-speed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Hero"))
        {
            ani.SetBool("IsAttacking", true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Hero"))
        {
            ani.SetBool("IsAttacking", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor"))
        {
            rb.mass = 1;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor"))
        {
            rb.mass = weight;
        }
    }
    private void OnAttack()
    {
        //애니메이션 이벤트 메소드 호출 오류용
    }
}
