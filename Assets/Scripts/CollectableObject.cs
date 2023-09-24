using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    public CollectableType type;
    public Sprite icon;

    Rigidbody2D rB;
    bool hasTarget;
    Vector3 targetPosition;
    private float speedAttraction = 2f;

    private void Awake()
    {
        rB = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player)
        {
            player.inventory.Add(this);
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (hasTarget)
        {
            Vector2 targetDirection = (targetPosition - transform.position).normalized;
            rB.velocity = new Vector2(targetDirection.x, targetDirection.y) * speedAttraction;
        }
    }
    
    public void SetTarget(Vector3 position)
    {
        targetPosition = position;
        hasTarget = true;
    }
}

public enum CollectableType
{
    NONE, SEED
}