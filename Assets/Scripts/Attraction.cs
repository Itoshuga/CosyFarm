using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attraction : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
         if (collision.gameObject.TryGetComponent<CollectableObject>(out CollectableObject collectableObject))
        {
            collectableObject.SetTarget(transform.parent.position);
        }
    }
}
