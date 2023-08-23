using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private float horizontal;
    public float speed, jumpPower;
    public bool willjump, jumpcooldown = false;
    private bool facingright;
    public Rigidbody2D rb;
    public LayerMask ground;

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Jump") && isGrounded() && !jumpcooldown)
        {
            willjump = true;
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (willjump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            willjump = false;
            jumpcooldown = true;
            Invoke("ResetJumpCooldown", 0.1f);
        }
    }

    private void ResetJumpCooldown()
    {
        jumpcooldown = false;
    }

    private bool isGrounded()
    {
        return Physics2D.Raycast(transform.position, new Vector2(0, -1), 1.2f, ground);
    }

    private void Flip()
    {
        if(facingright && horizontal < 0f || !facingright && horizontal > 0f)
        {
            facingright = !facingright;
            Vector3 localscale = transform.localScale;
            localscale.x *= -1f;
            transform.localScale = localscale;
        }
    }


}
