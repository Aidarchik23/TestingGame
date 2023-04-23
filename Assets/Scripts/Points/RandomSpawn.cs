using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    [SerializeField] 
    private SpawnPoint[] spawnPoints;
    [SerializeField] 
    private Point PointPrefab;

    private void Start() => Spawn();

    private void Spawn()
    {
        while (true)
        {
            int id = Random.Range(0, spawnPoints.Length);

            if (spawnPoints[id].Spawned) 
            {
                continue;
            }

            Point point = Instantiate(PointPrefab, spawnPoints[id].Position, Quaternion.identity);
            point.onCollision.AddListener(OnCollisionWithPlayer);
            spawnPoints[id].CoinSpawned();
            break;
        }
    }

    private void OnCollisionWithPlayer()
    {
        Spawn();

        for (int i = 0; i < spawnPoints.Length; i++)
            spawnPoints[i].DeInit();

        GameManager.Instance.AddCoins();
    }
}
