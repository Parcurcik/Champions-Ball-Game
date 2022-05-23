using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 3.0F;
    [SerializeField]
    new private Rigidbody2D rigidbody;
    private SpriteRenderer sprite;
    public bool canShoot;
    public bool grounded;
    private GameObject ball;
    public Transform checkGround;
    public LayerMask ground_layer;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        ball = GameObject.FindGameObjectWithTag("Ball");
    }

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(checkGround.position, 0.2f, ground_layer);
    }
    private void Update()
    {
        if (Input.GetButton("Horizontal2")) Walker();
        if (Input.GetButtonDown("Jump1")) Jump();
        if (Input.GetButton("Fire2")) Shoot();
    }

    private void Walker()
    {
        if (Controller.instance.isScore == false && Controller.instance.EndMatch == false)
        {

        Vector3 direction = transform.right * Input.GetAxis("Horizontal2");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        }
    }

    private void Jump()
    {
        if(grounded == true && Controller.instance.isScore == false && Controller.instance.EndMatch == false)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, 15);
        }
    }

    public void Shoot()
    {
        if(canShoot == true && Controller.instance.isScore == false && Controller.instance.EndMatch == false)
        {
            ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(-100, 100));
        }
    }
}
