using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemy;
    public float xPos;
    public float zPos;
    public float enemyCount = 10;
    public float spawnRate;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    public IEnumerator EnemyDrop()
    {
        while (enemyCount > 0)
        {
            xPos = Random.Range(-41, 41);
            zPos = Random.Range(-41, 41);
            Instantiate(enemy, new Vector3(xPos, 15, zPos), Quaternion.identity);
            yield return new WaitForSeconds(spawnRate);
            enemyCount--;
        }
    }
}
