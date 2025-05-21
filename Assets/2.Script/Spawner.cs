using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject monsterPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private int spawnCount;
    [SerializeField] private float spawnDelay;

    private string[] nameOfLines = { "Top", "Mid", "Bot" };
    private List<GameObject> monsterPool = new List<GameObject>();

    private void Awake()
    {
        for(int i = 0; i < spawnCount; i++)
        {
            GameObject newMonster = Instantiate(monsterPrefab);
            newMonster.SetActive(false);
            monsterPool.Add(newMonster);
        }
    }
    private void Start()
    {
        SpawnMonster().Forget();
    }
    private async UniTask SpawnMonster()
    {
        for (int i = 0; i < monsterPool.Count; i++)
        {
            int line = Random.Range(0, 3);
            PlaceMonsterOnLine(monsterPool[i], line);

            await UniTask.Delay(TimeSpan.FromSeconds(spawnDelay));
        }
    }
    private void PlaceMonsterOnLine(GameObject monster, int line)
    {
        monster.layer = LayerMask.NameToLayer(nameOfLines[line]);
        SpriteRenderer[] rends = monster.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer sr in rends)
        {
            sr.sortingLayerName = nameOfLines[line];
        }

        monster.transform.position = spawnPoint.position;
        monster.SetActive(true);
    }
}
