using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D rb;
    private Animator ani;
    private bool isAttacking;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        isAttacking = false;
    }

    private void Update()
    {
        if (isAttacking)
            rb.velocity = new Vector2(0, rb.velocity.y);
        else
        {
            rb.velocity = new Vector2(-1 * speed, rb.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Hero"))
        {
            isAttacking = true;
            ani.SetBool("IsAttacking", true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Hero"))
        {
            isAttacking = false;
            ani.SetBool("IsAttacking", false);
        }
    }
    private void OnAttack()
    {
        //애니메이션 이벤트 메소드 호출 오류용
    }
}
