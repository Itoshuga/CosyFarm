using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rB;
    private Animator animator;
    private Vector2 movementPosition;

    public float moveSpeed = 5f;
    public float sprintMultiplier = 1.3f;
    private bool isSprinting = false;

    void Start() {
        rB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        movementPosition = Vector2.zero;
        movementPosition.x = Input.GetAxisRaw("Horizontal");
        movementPosition.y = Input.GetAxisRaw("Vertical");

        isSprinting = Input.GetKey(KeyCode.LeftShift);

        UpdateAnimation();
    }

    void UpdateAnimation() {
        if (movementPosition != Vector2.zero) {
            UpdateMovement();

            animator.SetFloat("Horizontal", movementPosition.x);
            animator.SetFloat("Vertical", movementPosition.y);
            animator.SetBool("isWalking", true);
        } else {
            animator.SetBool("isWalking", false);
        }
    }

    void UpdateMovement()
    {
        float currentMoveSpeed = moveSpeed;

        if (isSprinting)
        {
            currentMoveSpeed *= sprintMultiplier; 
        }

        rB.MovePosition(rB.position + movementPosition.normalized * currentMoveSpeed * Time.fixedDeltaTime);
    }
}
