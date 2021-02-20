using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Variables
    public float speed;

    public static Enemy enemy;

    private Rigidbody EnemyRb;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        EnemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerFollow();
        Destroy();
    }


    // Makes the enemy follow the player
    private void PlayerFollow()
    {
        // Calculates the direction in which the enemy moves
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        // Make the enemy follow the player
        EnemyRb.AddForce(lookDirection * speed);
    }

    // Destroy the enemy if it appears in the same position as the player
    private void Destroy()
    {
        if (transform.position == player.transform.position)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        // Destroy the enemy if it collides with the objective
        if (other.CompareTag("Objective"))
        {
            Destroy(gameObject);
        }
    }

}
