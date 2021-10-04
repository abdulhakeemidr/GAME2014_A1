using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 moveDir;
    private Rigidbody2D playerRb;
    public int moveSpeed = 5;


    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        playerRb.MovePosition((Vector2)transform.position + (moveSpeed * moveDir * Time.deltaTime));
    }
}
