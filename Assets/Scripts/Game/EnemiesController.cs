using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> enemiesPrefabs;

    [SerializeField]
    private List<GameObject> enemiesGO;

    private int maxEnemiesOnGame = 3;

    void Update()
    {
        CleanEnemiesGOList();

        if (enemiesPrefabs.Count == 0)
        {
            Debug.LogError("Add enemies prefabs to Enemies Controller");
            return;
        }

        if (enemiesGO.Count < maxEnemiesOnGame)
        {
            int newEnemyIndex = Random.Range(0, enemiesPrefabs.Count);
            Vector3 randomEnemyPosition = new Vector3(Random.Range(-1.6f, 1.6f), 11.0f, 0);
            GameObject newEnemy = Instantiate(enemiesPrefabs[newEnemyIndex], randomEnemyPosition, Quaternion.identity);
            enemiesGO.Add(newEnemy);
        }
    }

    private void CleanEnemiesGOList()
    {
        for (var enemiesGOIndex = enemiesGO.Count - 1; enemiesGOIndex >= 0; enemiesGOIndex--)
        {
            if (enemiesGO[enemiesGOIndex] == null)
            {
                enemiesGO.RemoveAt(enemiesGOIndex);
            }
        }
    }
}
