using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class Playermovement : MonoBehaviour
{
    private Animator anim;

    public AudioSource Shoot;

    public Transform Player;
    public Transform PlayerSpawn;

    public float speed;
    public float JumpForce;

    public GameObject Bullet;
    private float facingDirX = 1;
    private bool canShoot = true;
    public Transform shootPos;

    private bool DoubleJump = true;

    private Rigidbody2D _rigidbody;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        Vector3 characterScale = transform.localScale;
        transform.Translate(transform.right * dirX * speed * Time.deltaTime);

        if (dirX == 1 || dirX == -1)
        {
            facingDirX = -dirX;
            characterScale.x = facingDirX;
        }
        transform.localScale = characterScale;
    }
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001)
        {
            DoubleJump = true;
            Jump();
        }
        else if (DoubleJump == true && Input.GetButtonDown("Jump"))
        {
            DoubleJump = false;
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.X) && canShoot == true)
        {
            Shoot.Play();
            GameObject spawnedBullet = Instantiate(Bullet, shootPos.position, Quaternion.identity);
            spawnedBullet.GetComponent<BulletBeh>().dirX = -facingDirX;
            StartCoroutine(Reload());
        }
        float IsRunning = Input.GetAxis("Horizontal");
        IsRunning = Mathf.Abs(IsRunning);
        anim.SetFloat("Run", IsRunning);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Player.position = PlayerSpawn.position;
        }
    }
    void Jump()
    {
        _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0.0f, 0.0f);
        _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
    }
    IEnumerator Reload()
    {
        canShoot = false;
        yield return new WaitForSeconds(1f);
        canShoot = true;
    }
}
