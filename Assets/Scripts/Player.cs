using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    [SerializeField]
    private float forceMagnitude = 3;

    [SerializeField]
    private float jumpForceMagnitude = 11;

    private bool isGround = true;

    private Animator animator;

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground") isGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
        jumpPlayer();
    }

    private void movePlayer()
    {
        float direction = Input.GetAxisRaw("Horizontal");
        animator.SetBool("Walk", direction != 0);
        Vector3 newPos = transform.position;
        newPos.x += direction * Time.deltaTime * 5;
        transform.position = newPos;
        switch (direction)
        {
            case -1:
                spriteRenderer.flipX = true;
                break;
            case 1:
                spriteRenderer.flipX = false;
                break;
            case 0:
                rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
                break;
        }
    }

    private void jumpPlayer()
    {
        if (Input.GetButtonDown("Jump") && isGround)
        {
            rigidBody
                .AddForce(new Vector2(0, jumpForceMagnitude),
                ForceMode2D.Impulse);
            isGround = false;
        }
    }
}
