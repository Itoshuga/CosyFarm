using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    public Animator animator;

    public float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        animator.SetFloat("Horizontal", x);
        animator.SetFloat("Vertical", y);
        animator.SetFloat("Speed", moveDelta.sqrMagnitude);

        moveDelta = new Vector3(x, y, 0);

        if (moveDelta.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (moveDelta.x < 0)
        { 
            transform.localScale = new Vector3(-1, 1, 1);
        }

        transform.Translate(moveDelta * Time.deltaTime * moveSpeed);
    }
}
