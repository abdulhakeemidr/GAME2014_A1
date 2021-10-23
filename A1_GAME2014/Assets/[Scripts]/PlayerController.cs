using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 moveDir;
    private Rigidbody2D playerRb;
    public int moveSpeed = 5;
    private Animator animator;
    public Joystick joystick;
    int MoveRightAnim;
    int MoveLeftAnim;
    int MoveUpAnim;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        MoveRightAnim = Animator.StringToHash("isMovingRight");
        MoveLeftAnim = Animator.StringToHash("isMovingLeft");
        MoveUpAnim = Animator.StringToHash("isMovingUp");
    }

    void Update()
    {
        MoveTouchInput();
        MoveKeyInput();
        AnimateMovement();
        playerRb.MovePosition((Vector2)transform.position + (moveSpeed * moveDir * Time.deltaTime));
    }

    void MoveTouchInput()
    {
        moveDir = new Vector2(joystick.Horizontal, joystick.Vertical);
        //Debug.Log(moveDir.x + ", " + moveDir.y);
    }

    void MoveKeyInput()
    {
        if(Input.anyKeyDown)
        {
            moveDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
    }

    void AnimateMovement()
    {
        // For Moving Left
        if(moveDir.x < 0)
        {
            animator.SetBool(MoveRightAnim, false);
            animator.SetBool(MoveUpAnim, false);
            animator.SetBool(MoveLeftAnim, true);
        }
        else if(moveDir.x == 0)
        {
            animator.SetBool(MoveLeftAnim, false);
        }

        // For Moving Right
        if (moveDir.x > 0)
        {
            animator.SetBool(MoveLeftAnim, false);
            animator.SetBool(MoveUpAnim, false);
            animator.SetBool(MoveRightAnim, true);
        }
        else if (moveDir.x == 0)
        {
            animator.SetBool(MoveRightAnim, false);
        }

        // For Moving Up
        if(moveDir.y > 0 && Mathf.Abs(moveDir.y) > Mathf.Abs(moveDir.x))
        {
            animator.SetBool(MoveLeftAnim, false);
            animator.SetBool(MoveRightAnim, false);
            animator.SetBool(MoveUpAnim, true);
        }
        else if(moveDir.y == 0)
        {
            animator.SetBool(MoveUpAnim, false);
        }
    }
}
