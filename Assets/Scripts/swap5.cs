using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swap5 : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Player>().swap5();
        Destroy(gameObject);
    }
}
