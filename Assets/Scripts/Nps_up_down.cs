using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nps_up_down : MonoBehaviour
{
    bool moveing;
    float speed = 0.3f;
    public float pos = 300f;
    public float a = 2f;
    public float b = 5f;
    public bool left = true;

    private bool FacingRight = true;

    void FixedUpdate()
    {

        pos = this.gameObject.transform.position.y; ;
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

            transform.position = new Vector2(transform.position.x , transform.position.y + speed * Time.fixedDeltaTime);
        }
        if (!moveing)
        {
            transform.position = new Vector2(transform.position.x , transform.position.y- speed * Time.fixedDeltaTime);
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
