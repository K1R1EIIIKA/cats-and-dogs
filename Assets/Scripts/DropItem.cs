using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject item;
    public float prob = 100;
    float rnb;
    private void OnMouseDown()
    {
        GameObject Item = Instantiate(item, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
