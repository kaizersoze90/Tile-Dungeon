using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [SerializeField] float enemySpeed = 1f;

    Rigidbody2D enemyRigidbody;


    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        enemyRigidbody.velocity = new Vector2(enemySpeed, 0f);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        enemySpeed = -enemySpeed;
        FlipEnemyFacing();
    }

    void FlipEnemyFacing()
    {
        transform.localScale = new Vector2(-transform.localScale.x, 1f);
    }
}
