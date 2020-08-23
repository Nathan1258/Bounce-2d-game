using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public static Point instance;
    public ParticleSystem explosion_1;
    public GameObject Player;

    private void Awake()
    {
        instance = this;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.tag == "Player")
        {
            Die();
        }
    }

    void Die()
    {
        PlayerMovement.instance.accelerateUp();
        Destroy(gameObject);
        GameManger.instance.addScore();
    }
}
