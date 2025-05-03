using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] zombiePrefabs; // 4 farklý zombi prefab'ý
    public Transform[] spawnPoints; // Spawn noktalarý
    public float spawnInterval = 5f;

    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnZombie();
            timer = 0f;
        }

    }

    void SpawnZombie()
    {
        int randomZombieIndex = Random.Range(0, zombiePrefabs.Length);
        int randomSpawnIndex = Random.Range(0, spawnPoints.Length);

        GameObject selectedZombie = zombiePrefabs[randomZombieIndex];
        Transform selectedSpawnPoint = spawnPoints[randomSpawnIndex];

        Instantiate(selectedZombie, selectedSpawnPoint.position, Quaternion.identity);
    }
}
