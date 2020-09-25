using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public bool gameOver;
    public GameObject gameOverText;
    public Player player;
    public float bossHealth = 0;
    public GameObject[] bosses;
    public GameObject gameUI;
    public Slider bossHealthSlider;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        gameUI.SetActive(true);
        gameOverText.SetActive(false);
        Time.timeScale = 1;
        bosses = GameObject.FindGameObjectsWithTag("Boss");

        foreach (GameObject boss in bosses)
        {
            bossHealth += boss.GetComponent<Boss>().bossMaxHealth;
        }

        bossHealthSlider.maxValue = bossHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.health == 0)
            GameOver();


        bossHealthSlider.value = bossHealth;

        if (bossHealth == 0)
            GameOver();
    }   

    public void GameOver()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        gameOver = true;
        gameUI.SetActive(false);
        gameOverText.SetActive(true);
    }
}
