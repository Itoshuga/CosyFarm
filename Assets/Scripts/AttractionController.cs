using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractionController : MonoBehaviour
{
    public float attractionForce = 10f;

    private void OnTriggerStay2D(Collider2D other)
    {
        // Vérifier si l'objet en contact est celui que vous voulez attirer (par exemple, en vérifiant un tag)
        if (other.CompareTag("Attractable"))
        {
            // Calculer la direction de l'attraction (vers le personnage)
            Vector2 direction = transform.position - other.transform.position;

            // Appliquer une force d'attraction à l'objet
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            rb.AddForce(direction.normalized * attractionForce);
        }
    }
}
