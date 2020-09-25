using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{

    public float maxHealth;
    public float health;
    public Deflector deflector;
    public TextMeshProUGUI healthText;

   
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "HP: " + health;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {

            if (deflector.IsDeflecting())
            {
                other.tag = "PlayerBullet";
                deflector.Deflect(other.gameObject);
            }

            else
            {
                Destroy(other);
                health--;
            }
        }
    }
}
