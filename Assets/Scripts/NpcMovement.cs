using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class NpcMovement : MonoBehaviour
{
    public bool isVertical;
    public float distance = 300f;
    [Range(0, 5f)] public float speed = 0.3f;

    [SerializeField] private float leftBorder = 2f;
    [SerializeField] private float rightBorder = 5f;
    [SerializeField] private float bottomBorder = 2f;
    [SerializeField] private float topBorder = 5f;

    private bool _isLeft = true;
    private bool _isFacingRight = true;
    private bool _isMoving;

    void FixedUpdate()
    {
        if (isVertical)
            VerticalMovement();
        else
            HorizontalMovement();
    }

    private void VerticalMovement()
    {
        distance = transform.position.y;

        if (distance > topBorder || (distance > topBorder & !_isLeft))
        {
            _isMoving = false;
            if (!_isLeft)
            {
                Flip();
                _isLeft = true;
            }
        }

        if (distance < bottomBorder || (distance < bottomBorder & _isLeft))
        {
            _isMoving = true;
            if (_isLeft)
            {
                Flip();
                _isLeft = false;
            }
        }

        if (_isMoving)
            transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.fixedDeltaTime);
        else
            transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.fixedDeltaTime);
    }

    private void HorizontalMovement()
    {
        distance = transform.position.x;
        
        if (distance > rightBorder || (distance > rightBorder & !_isLeft))
        {
            _isMoving = false;
            if (!_isLeft)
            {
                Flip();
                _isLeft = true;
            }
        }

        if (distance < leftBorder || (distance < leftBorder & _isLeft))
        {
            _isMoving = true;
            if (_isLeft)
            {
                Flip();
                _isLeft = false;
            }
        }

        if (_isMoving)
            transform.position = new Vector2(transform.position.x + speed * Time.fixedDeltaTime, transform.position.y);
        else
            transform.position = new Vector2(transform.position.x - speed * Time.fixedDeltaTime, transform.position.y);
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;

        Vector3 theSale = transform.localScale;
        theSale.x *= -1;
        transform.localScale = theSale;
    }
}