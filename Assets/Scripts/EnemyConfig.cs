using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Config")]
public class EnemyConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float moveSpeed = 2f;

    public GameObject GetEnemyPrefabs() { return enemyPrefab; }
    public List<Transform> GetWayspoints()
    {
        var waveWaypoints = new List<Transform>();
        foreach (Transform child in pathPrefab.transform)
        {
            waveWaypoints.Add(child);
        }
        return waveWaypoints;
    }

    public float GetMoveSpeeds() { return moveSpeed; }
}
