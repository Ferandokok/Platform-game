using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public Transform EnemySpawnPos;
    public Transform Enemy;

    public Transform StartPos;
    public Transform Player;

    public Transform SpikeBallLoc;
    public Transform SpikeBall;
    private Rigidbody2D RB;
    // Start is called before the first frame update
    void Start()
    {
        RB = SpikeBall.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.position = StartPos.position;
        }
        if (collision.gameObject.CompareTag("SpikeBall"))
        {
            SpikeBall.position = SpikeBallLoc.position;
            RB.velocity = new Vector3(0, 0, 0);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy.position = EnemySpawnPos.position;
        }
    }
}
