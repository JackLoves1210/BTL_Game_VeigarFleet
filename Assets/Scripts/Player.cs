using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // configuration parameters
    [Header("Player")]
    [SerializeField] Sprite superfly;
    [SerializeField] Sprite supersuperfly;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 0.25f;
    [SerializeField] int health = 200;
    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.75f;
    [SerializeField] AudioClip shootSound;
    [SerializeField] [Range(0, 1)] float shootSoundVolume = 0.25f;

    [Header("Projectile")]
    [SerializeField] List<GameObject> laserPrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFiringPeriod = 0.1f;

    Coroutine firingCoroutine;

    public static int enemydie=0;
    public static int damageitem=0;
    public static int i = 0;

    //public static Predicate<int> skipWave;

    float xMin;
    float xMax;
    float yMin;
    float yMax;

    Vector3 mousePos;

    // Use this for initialization
    void Start () {
        SetUpMoveBoundaries();
	}
 
    // Update is called once per frame
    void Update () {
        Move();
        Fire();
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        FindObjectOfType<Level>().LoadGameOver();
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);   
    }

    public int GetHealth()
    {
        return health;
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }
    }
    public void IncreHeath()
    {
        health += 100;
    }

    public void Incredamage()
    {
        damageitem += 1;
        if (damageitem == 3)
        {
            GetComponent<SpriteRenderer>().sprite = superfly;
            health += 200;
        }
        if (damageitem == 7)
        {
            GetComponent<SpriteRenderer>().sprite = supersuperfly;
            health += 300;
        }
        
    }

    public void swap1()
    {
        if (i == 0)
            damageitem += 1;
        else
            i = 0;
        if (damageitem == 3)
        {
            GetComponent<SpriteRenderer>().sprite = superfly;
            health += 200;
        }
        if (damageitem == 7)
        {
            GetComponent<SpriteRenderer>().sprite = supersuperfly;
            health += 300;
        }
    }

    public void swap2()
    {
        if (i == 1)
            damageitem += 1;
        else
            i = 1;
        if (damageitem == 3)
        {
            GetComponent<SpriteRenderer>().sprite = superfly;
            health += 200;
        }
        if (damageitem == 7)
        {
            GetComponent<SpriteRenderer>().sprite = supersuperfly;
            health += 300;
        }
    }

    public void swap3()
    {
        if (i == 2)
            damageitem += 1;
        else
            i = 2;
        if (damageitem == 3)
        {
            GetComponent<SpriteRenderer>().sprite = superfly;
            health += 200;
        }
        if (damageitem == 7)
        {
            GetComponent<SpriteRenderer>().sprite = supersuperfly;
            health += 300;
        }
    }

    public void swap4()
    {
        if (i == 3)
            damageitem += 1;
        else
            i = 3;
        if (damageitem == 3)
        {
            GetComponent<SpriteRenderer>().sprite = superfly;
            health += 200;
        }
        if (damageitem == 7)
        {
            GetComponent<SpriteRenderer>().sprite = supersuperfly;
            health += 300;
        }
    }
    public void swap5()
    {
        if (i == 4)
            damageitem += 1;
        else
            i = 4;
        if (damageitem == 3)
        {
            GetComponent<SpriteRenderer>().sprite = superfly;
            health += 200;
        }
        if (damageitem == 7)
        {
            GetComponent<SpriteRenderer>().sprite = supersuperfly;
            health += 300;
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject laser = Instantiate(
                    laserPrefab[i],
                    transform.position,
                    Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
            yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }


    private void Move()
    {
        //move by keyboard
        //var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        //var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        //var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        //var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        //transform.position = new Vector2(newXPos, newYPos);

        //move by mouse
        if(Input.GetMouseButton(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            mousePos = new Vector3(Mathf.Clamp(mousePos.x, xMin, xMax), Mathf.Clamp(mousePos.y, yMin, yMax));
        }
        transform.position = Vector3.Lerp(transform.position, mousePos, moveSpeed * Time.deltaTime);
    }

    private void SetUpMoveBoundaries()
    {
        mousePos = transform.position;
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;

    }
}
