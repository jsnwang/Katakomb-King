using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Deflector : MonoBehaviour
{
    public bool deflecting;
    public bool canDeflect;
    public float deflectCd;
    private float timer;
    public float deflectTime;
    public Image crosshair;
    public Material bulletMat;
    public float bulletSpeed;
    public GameObject cooldownBar;
    public Slider cooldownSlider;

    private void Start()
    {
        cooldownSlider.maxValue = deflectCd;
    }
    private void Update()
    {
        if(deflecting)
        { crosshair.color = new Color(255, 0, 0); }
        else
            crosshair.color = new Color(255, 255, 255);
        if (canDeflect == true)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                StartCoroutine(Deflecting());
                canDeflect = false;
                
            }
        }

        if (timer >= deflectCd)
        {
            cooldownBar.SetActive(false);
            canDeflect = true;
        }

        if (!canDeflect)
        {
            cooldownBar.SetActive(true);
            cooldownSlider.value = timer;
            timer += Time.deltaTime;
        }
    }

    public void Deflect(GameObject projectile)
    {
        projectile.GetComponent<Renderer>().material = bulletMat; 
        projectile.transform.position += Camera.main.transform.forward;
        projectile.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * bulletSpeed;
    }

    public IEnumerator Deflecting()
    {
        deflecting = true;
        timer = 0;
        yield return new WaitForSeconds(deflectTime);
        deflecting = false;
    }

    public bool IsDeflecting()
    {
        return deflecting;
    }


}
