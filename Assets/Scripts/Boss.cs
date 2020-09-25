using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Boss : MonoBehaviour
{

    public float bossMaxHealth;
    public float bossHealth;
    public Animation_Test anim;
    // Start is called before the first frame update
    void Start()
    {
        bossHealth = bossMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (bossHealth <= 0)
        {

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            GameManager.Instance.bossHealth--;
            bossHealth--;
            Destroy(other.gameObject);
        }
    }
}
