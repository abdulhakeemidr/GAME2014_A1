using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    private Rigidbody2D zombieRb;
    private Animator animator;
    private GameObject playerObj;
    private Vector2 moveDir;
    public float moveSpeed;

    private Vector2 finalPos;

    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        zombieRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(moveDir.magnitude);
        MoveZombie();
        AnimateMovement();
        zombieRb.MovePosition((Vector2)transform.position + (moveSpeed * moveDir * Time.deltaTime));
        
    }

    void MoveZombie()
    {
        finalPos = playerObj.transform.position;
        moveDir = (finalPos - (Vector2)transform.position).normalized;
        FlipZombie();
    }

    void AnimateMovement()
    {
        if(moveDir.magnitude  != 0)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    void FlipZombie()
    {
        var charScale = transform.localScale;
        if(moveDir.x > 0)
        {
            charScale.x = -Mathf.Abs(charScale.x);
        }
        else if (moveDir.x < 0)
        {
            charScale.x = Mathf.Abs(charScale.x);
        }

        transform.localScale = charScale;
    }
}
