using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // The enemy's speed
    public float speed = 5.0f;

    // The player character
    public GameObject player;

    // Whether the enemy is currently chasing the player
    private bool isChasing = false;

    // Update is called once per frame
    void Update()
    {
        // Check if the enemy is currently chasing the player
        if (isChasing)
        {
            // Calculate the direction to the player
            Vector3 direction = player.transform.position - transform.position;

            // Normalize the direction and set the enemy's velocity
            direction.Normalize();
            GetComponent<Rigidbody2D>().velocity = direction * speed;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);

            // Check if the ray hits the ground
            if (hit.collider != null && hit.collider.tag == "Ground")
            {
                // Set the enemy's y position to be equal to the y position of the point where the ray hits the ground
                float transform = hit.point.y;
            }
        }
    }

    // Called when the player's field of view enters the enemy's trigger collider
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            Debug.Log("Chase");
            isChasing = true;
        }
    }

    // Called when the player's field of view exits the enemy's trigger collider
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            isChasing = false;
        }
    }
}