using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyboss : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] float health = 100;
    [SerializeField] int scoreValue = 150;
   

    [Header("Shooting")]
    float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject projectile;
    [SerializeField] List<GameObject> dropitem;
    [SerializeField] float projectileSpeed = 10f;

    [Header("Sound Effects")]
    [SerializeField] GameObject deathVFX;
    [SerializeField] float durationOfExplosion = 1f;
    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.75f;
    [SerializeField] AudioClip shootSound;
    [SerializeField] [Range(0, 1)] float shootSoundVolume = 0.25f;

    
    // Use this for initialization
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }

    public float Getheath()
    {
        return health;
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        GameObject laser = Instantiate(
            projectile,
            transform.position,
            Quaternion.identity
            ) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        DamagePlayer damagePlayer = other.gameObject.GetComponent<DamagePlayer>();
        if (!damagePlayer) { return; }
        if (Player.enemydie >= 6)
        {
            ProcessHit(damagePlayer);
        }
    }

    private void ProcessHit(DamagePlayer damagePlayer)
    {
       
        health -= damagePlayer.GetDamage();
        damagePlayer.Hit();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        

        FindObjectOfType<GameSession>().AddToScore(scoreValue);
        Destroy(gameObject);
        GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(explosion, durationOfExplosion);
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);


        //cout
        Player.enemydie++;

        //code for dropitem
        float rate = Random.Range(0f, 1f);

        if (rate < 0.95f)
        {

            int j = Random.Range(1, dropitem.Count);
            for (int i = 0; i < j; i++)
            {
                int k = Random.Range(0,dropitem.Count);
                Instantiate(dropitem[k], this.transform.position, dropitem[k].transform.rotation);
            }

        }

    }
}
