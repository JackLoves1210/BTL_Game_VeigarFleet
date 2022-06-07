using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject {

    [SerializeField] List<EnemyConfig> Enemys;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.3f;

   

    public GameObject GetEnemyPrefab(int index) { return Enemys[index].GetEnemyPrefabs(); }

    public List<Transform> GetWaypoints(int index)
    {

        return Enemys[index].GetWayspoints();
    }

    public float GetTimeBetweenSpawns() { return timeBetweenSpawns; }

    public float GetSpawnRandomFactor() { return spawnRandomFactor; }

    public int GetNumberOfEnemies() { return Enemys.Count; }

    public float GetMoveSpeed(int index) { return Enemys[index].GetMoveSpeeds(); }

}
