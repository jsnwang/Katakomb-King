using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public float speed = 10.0f;
    private float vert;
    private float horiz;

    // Use this for initialization
    void Start()
    {
        // turn off the cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.gameOver)
        {
            // Input.GetAxis() is used to get the user's input
            // You can furthor set it on Unity. (Edit, Project Settings, Input)
            vert = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            horiz = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            transform.Translate(horiz, 0, vert);
        }
    }
}