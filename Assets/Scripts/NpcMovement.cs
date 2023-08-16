using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class NpcMovement : MonoBehaviour
{
    public bool isVertical;
    public float distance = 300f;
    [Range(0, 5f)] public float speed = 0.3f;

    [SerializeField] private float smallBorder = 2f;
    [SerializeField] private float bigBorder = 5f;

    private bool _isLeft = true;
    private bool _isFacingRight = true;
    private bool _isMoving;

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (isVertical)
            distance = transform.position.y;
        else
            distance = transform.position.x;

        if (distance > bigBorder || (distance > bigBorder & !_isLeft))
        {
            _isMoving = false;
            if (!_isLeft)
            {
                Flip();
                _isLeft = true;
            }
        }

        if (distance < smallBorder || (distance < smallBorder & _isLeft))
        {
            _isMoving = true;
            if (_isLeft)
            {
                Flip();
                _isLeft = false;
            }
        }

        if (_isMoving)
        {
            if (isVertical)
                transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.fixedDeltaTime);
            else
                transform.position = new Vector2(transform.position.x + speed * Time.fixedDeltaTime, transform.position.y);
        }
        else
        {
            if (isVertical)
                transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.fixedDeltaTime);
            else
                transform.position = new Vector2(transform.position.x - speed * Time.fixedDeltaTime, transform.position.y);}
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;

        Vector3 theSale = transform.localScale;
        theSale.x *= -1;
        transform.localScale = theSale;
    }
}