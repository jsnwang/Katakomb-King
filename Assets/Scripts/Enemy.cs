using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float step;
    public EnemySpawner enemySpawner;
    // Start is called before the first frame update
    void Start()
    {
        enemySpawner = GameObject.FindObjectOfType<EnemySpawner>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
