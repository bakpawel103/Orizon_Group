using UnityEngine;

public abstract class AAbility : MonoBehaviour
{
    public abstract float speed { get; }

    public EnemiesSpawnController enemiesSpawnController;

    public abstract void Invoke();
}
