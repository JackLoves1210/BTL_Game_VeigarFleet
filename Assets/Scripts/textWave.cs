using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textWave : MonoBehaviour
{

    Text WaveText;
    private static textWave _instance;

    public static textWave Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<textWave>();
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
        WaveText = GetComponent<Text>();
    }
    // Update is called once per frame
    public  void GetText(int indext)
    {
        WaveText.text = "Wave " + indext.ToString();
    }
    public void GetTextover()
    {
        WaveText.text = "";
    }
    
}
