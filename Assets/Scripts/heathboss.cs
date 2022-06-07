using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class heathboss : MonoBehaviour
{


    Text textheathboss;
    Enemyboss boss;
    private static heathboss _instance;

    public static heathboss Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<heathboss>();
            }

            return _instance;
        }
    }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        textheathboss = GetComponent<Text>();
        boss = FindObjectOfType<Enemyboss>();
    }

    // Update is called once per frame
    public void Update()
    {
        textheathboss.text = boss.Getheath().ToString();
    }

    public void over()
    {
        textheathboss.text = "";
    }
}   
