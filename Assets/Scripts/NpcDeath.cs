using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject drop;
    [SerializeField] [Range(0, 10f)] private float impulsePower = 2;
    [SerializeField] private bool hasDrop;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasDrop)
            Instantiate(drop, transform.position, Quaternion.identity);
        
        Destroy(gameObject);
        other.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 10 * impulsePower), ForceMode2D.Impulse);
    }
}