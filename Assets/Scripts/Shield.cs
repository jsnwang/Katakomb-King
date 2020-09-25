using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject shield;
    public float shieldMaxHP = 3;
    public float shieldHP;
    // Start is called before the first frame update
    void Start()
    {
        shieldHP = shieldMaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (shieldHP == 0)
        { }
    }
}
