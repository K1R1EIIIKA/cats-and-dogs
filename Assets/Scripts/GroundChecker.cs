using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerLogic.IsGround = true;

        if (other.gameObject.CompareTag("Enemy"))
        {
            PlayerLogic.IsGround = true;
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        PlayerLogic.IsGround = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        PlayerLogic.IsGround = false;
    }
}
