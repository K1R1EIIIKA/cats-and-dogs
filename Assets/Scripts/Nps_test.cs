using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nps_test : MonoBehaviour
{
    bool moveing ;
    float speed = 0.3f;
    public float pos=300f;
    public float a = 2f;
    public float b = 5f;
    public bool left = true;

    private bool FacingRight = true;

    void FixedUpdate()
    {
        
        pos = this.gameObject.transform.position.x; ;
        if (pos > b || (pos > b & !left))
        {
            moveing = false;
            if (!left)
            {
                Flip();
                left = true;
            }
        }
        if (pos < a || (pos < a & left))
        {
            moveing = true;
            if (left)
            {
                Flip();
                left = false;
            }
        }

        if (moveing)
        {

            transform.position = new Vector2(transform.position.x+speed*Time.fixedDeltaTime, transform.position.y);
        }
        if (!moveing)
        {
            transform.position = new Vector2(transform.position.x - speed * Time.fixedDeltaTime, transform.position.y);
        }
    }
    private void Flip()
    {
        FacingRight = !FacingRight;

        Vector3 theSale = transform.localScale;
        theSale.x *= -1;
        transform.localScale = theSale;
    }
}
