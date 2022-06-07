using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startingWave = 0;
    [SerializeField] bool looping = false;
    
    public List<Transform> tempWaypoint;
    public float tempspeed;
  
    private static EnemySpawner _instance;

    public static EnemySpawner Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<EnemySpawner>();
            }

            return _instance;
        }
    }
    
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
   

	// Use this for initialization
	IEnumerator Start()
    {
        //do
        //{
            yield return StartCoroutine(SpawnAllWaves());
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene("TheEnd");
            FindObjectOfType<GameSession>().ResetGame();


        //} 
        //while (looping);
    }
  
	
    public IEnumerator SpawnAllWaves()
    {
        for (int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            yield return new WaitForSeconds(3f);
            textWave.Instance.GetText(waveIndex + 1);
            yield return new WaitForSeconds(2f);
            textWave.Instance.GetTextover();
            yield return new WaitForSeconds(3f);
            var currentWave = waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
            yield return new WaitUntil(() => Player.enemydie == waveConfigs[waveIndex].GetNumberOfEnemies());

            Player.enemydie = 0;
           
        }
    }

    public IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount++)
        {
            tempWaypoint = waveConfig.GetWaypoints(enemyCount);
            var newEnemy = Instantiate(
                waveConfig.GetEnemyPrefab(enemyCount),
               tempWaypoint[0].transform.position,
                Quaternion.identity);
      
            tempspeed = waveConfig.GetMoveSpeed(enemyCount);
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
           
        }
     
    }
     public List<Transform> GetWaypoint()
    {
        return tempWaypoint;
    }

    public float GetSpeed()
    {
        return tempspeed;
    }
}
