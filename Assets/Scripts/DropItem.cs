using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject item;
    [SerializeField] [Range(0, 10f)] private float impulsePower = 2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(item, transform.position, Quaternion.identity);
        Destroy(gameObject);

        other.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 10 * impulsePower), ForceMode2D.Impulse);
    }
}