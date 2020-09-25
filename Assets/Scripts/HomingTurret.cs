using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HomingTurret : MonoBehaviour
{
    [SerializeField]
    private float turnRateRadians = 2 * Mathf.PI;

    [SerializeField]
    private Transform turretTop; // the gun part that rotates

    [SerializeField]
    private Transform bulletSpawnPoint;

    public GameObject target;

    public GameObject bulletPrefab;
    private GameObject bullet;

    public float fireRate;
    private float nextFire = 2;

    void Update()
    {
        if(!GameManager.Instance.gameOver)
            TargetEnemy();


    }

    void TargetEnemy()
    {
       

        if (target != null)
        {
            Vector3 targetDir = target.transform.position - transform.position;
            // Rotating in 2D Plane...
            targetDir.y = 0.0f;
            targetDir = targetDir.normalized;

            Vector3 currentDir = turretTop.forward;

            currentDir = Vector3.RotateTowards(currentDir, targetDir, turnRateRadians * Time.deltaTime, 1.0f);

            Quaternion qDir = new Quaternion();
            qDir.SetLookRotation(currentDir, Vector3.up);
            turretTop.rotation = qDir;
            transform.LookAt(target.transform);
            nextFire += Time.deltaTime;

            if (nextFire > fireRate)
            {
                StartCoroutine(Fire());
                nextFire = 0;
            }

        }
        
    }

    private IEnumerator Fire()
    {
        

        bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        //bullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
        yield return null;
    }
}

