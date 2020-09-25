using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLifetime : MonoBehaviour
{
    public float lifetime = 10f;
    float timer = 0;
    // Start is called before the first frame update
    void Awake()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= lifetime)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Untagged"))
        {
            StartCoroutine(DestroyAfter());
        }
    }

    IEnumerator DestroyAfter()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
