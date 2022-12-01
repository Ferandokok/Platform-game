using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBeh : MonoBehaviour
{
    public float speed = 8;
    public float LifeTime = 2;
    [HideInInspector] public float dirX = 1f;

    public GameObject Bullet;
    private float facingDirX = 1;
    private bool canShoot = true;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, LifeTime);

        Vector3 characterScale = transform.localScale;
        if (dirX == -1 || dirX == 1)
        {
            facingDirX = dirX;
            Debug.Log(facingDirX);
        }
        transform.localScale = characterScale * facingDirX;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(transform.right * dirX * speed * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        transform.Translate(transform.right * dirX * speed * Time.deltaTime);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        Debug.Log("Hit");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            AIpatrol enemyScript = collision.gameObject.GetComponent<AIpatrol>();

            enemyScript.TakeDamage();
        }
    }
}
