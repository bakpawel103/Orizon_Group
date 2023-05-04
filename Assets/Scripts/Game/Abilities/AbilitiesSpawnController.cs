using System.Collections.Generic;
using UnityEngine;

public class AbilitiesSpawnController : MonoBehaviour
{
    [SerializeField]
    private float minAbilitySpawningPeriod = 10.0f;
    [SerializeField]
    private float maxAbilitySpawningPeriod = 40.0f;

    [SerializeField]
    private List<GameObject> abilitiesPrefabs;

    [SerializeField]
    private EnemiesSpawnController enemiesSpawnController;

    private float lastFreezeSpawnedDeltaTime;
    private float randomFreezeSpawnPeriod;

    void Start()
    {
        randomFreezeSpawnPeriod = Random.Range(minAbilitySpawningPeriod, maxAbilitySpawningPeriod);
    }

    void Update()
    {

        TrySpawnFreeze();
    }

    private void TrySpawnFreeze()
    {
        var currentRealtimeSinceStartup = Time.realtimeSinceStartup;
        if (currentRealtimeSinceStartup - lastFreezeSpawnedDeltaTime >= randomFreezeSpawnPeriod)
        {
            int newAbilityIndex = Random.Range(0, abilitiesPrefabs.Count);
            Vector3 randomAbilityPosition = new Vector3(Random.Range(-1.6f, 1.6f), 11.0f, 0);
            var newAbility = Instantiate(abilitiesPrefabs[newAbilityIndex], randomAbilityPosition, Quaternion.identity);
            newAbility.GetComponent<AAbility>().enemiesSpawnController = enemiesSpawnController;

            lastFreezeSpawnedDeltaTime = currentRealtimeSinceStartup;
            randomFreezeSpawnPeriod = Random.Range(minAbilitySpawningPeriod, maxAbilitySpawningPeriod);
        }
    }
}
