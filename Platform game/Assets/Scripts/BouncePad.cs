using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    public float bounce = 2f;
    private Rigidbody2D RB;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        RB = Player.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D RB = Player.GetComponent<Rigidbody2D>();

        float UpForce = -RB.velocity.y * bounce;
            
        if (collision.gameObject.CompareTag("Player"))
        {
            RB.velocity = new Vector3(0, 0, 0);
            RB.AddForce(Vector2.up * UpForce, ForceMode2D.Impulse);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
    }
}
