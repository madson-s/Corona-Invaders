using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player;
    public GameObject spawn;
    public int enimiesDirection;
    public int life = 5;
    public int score = 0;
    public int enemiesCount = 16;
    private Text lifeText;
    private Text scoreText;
    private Text gameOverText;
    private Image gameOverImage;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);

        enimiesDirection = 1;
        lifeText = GameObject.Find("Life").GetComponent<Text>();
        scoreText = GameObject.Find("Score Text").GetComponent<Text>();
        gameOverText = GameObject.Find("GameOverText").GetComponent<Text>();
        gameOverImage = GameObject.Find("GameOverImage").GetComponent<Image>();
        gameOverImage.enabled = false;
        gameOverText.enabled = false;

        lifeText.text = "VIDAS: " + life;
        scoreText.text = "PONTOS: " + score;

        DontDestroyOnLoad(gameObject);
    }

    public void LossLife(int damage)
    {
        life -= damage;
        lifeText.text = "VIDAS: " + life;
        if (life == 0)
            GameOver();
        else
            Instantiate(player, spawn.transform.position, Quaternion.identity);
    }

    public void AddScore(int point)
    {
        score += point;
        scoreText.text = "PONTOS: " + score;

        enemiesCount--;
        if (enemiesCount == 0)
            YouWon();
    }

    void YouWon()
    {
        gameOverText.text = "YOU WON!";
        gameOverImage.enabled = true;
        gameOverText.enabled = true;
    }

    public void GameOver()
    {
        gameOverImage.enabled = true;
        gameOverText.enabled = true;
    }
}
