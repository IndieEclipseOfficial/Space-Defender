using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public float SpawnRadius = 10f;
    public GameObject enemy;

    public float nextSpawnTime = 1f;
    public float speed = 1;

    private void Start() {
        InvokeRepeating("SpawnEnemy", 0.1f, nextSpawnTime);
    }

    private void SpawnEnemy() {
        Vector2 spawnPos = GameObject.FindGameObjectWithTag("Planet").transform.position;
        spawnPos += Random.insideUnitCircle.normalized * SpawnRadius;

        Instantiate(enemy, spawnPos, Quaternion.identity);
        nextSpawnTime -= 0.01f;
        speed += 0.01f;

        if (speed > 10)
            speed = 10;

        enemy.GetComponent<EnemyAI>().speed = speed;

        if (nextSpawnTime < 0.01)
            nextSpawnTime = 0.01f;
    }
}
