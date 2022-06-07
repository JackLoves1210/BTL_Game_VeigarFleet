using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    [SerializeField] int damage = 100;
    

    public int GetDamage()
    {
        //Debug.Log(damage + Player.damageitem * 50);
        return damage+Player.damageitem*50;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
