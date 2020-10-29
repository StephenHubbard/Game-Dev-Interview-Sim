using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlatformMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float changeDirectionTime = 2f;
    public Rigidbody2D rb;
    private Vector2 moveDirection;


    void Start()
    {
        StartCoroutine(ChangeDirection());
        changeDirectionTime = Random.Range(1f, 3f);
    }

    void Update()
    {
        Move();
    }


    IEnumerator ChangeDirection()
    {
        float RandomX = Random.Range(-1f, 1f);
        float RandomY = Random.Range(-1f, 1f);

        moveDirection = new Vector2(RandomX, RandomY).normalized;
        yield return new WaitForSeconds(changeDirectionTime);
        StartCoroutine(ChangeDirection());
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
