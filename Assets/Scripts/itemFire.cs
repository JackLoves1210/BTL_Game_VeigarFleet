using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemFire : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Player>().Incredamage();
        Destroy(gameObject);
    }
}
