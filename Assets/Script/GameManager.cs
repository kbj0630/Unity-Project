using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerController player;
    public PoolManager pool;
    public GameObject gameoverText;
    public Text timeText;
    public Text killScoreText;
    public GameObject playerOJ;
    public Text messageText;
    public bool isGameOver = false;
    public Text lifeText;

    private float surviveTime;
    private int killScore = 0;
    private Vector3 initialTextPosition;

    void Awake() {
        instance = this;

    }

    // Start is called before the first frame update
    void Start() {
        surviveTime = 0;
        isGameOver = false;
        initialTextPosition = killScoreText.transform.position;
        UpdateKillScoreText();
    }

    // Update is called once per frame
    void Update() {
        if (!isGameOver) {
            surviveTime += Time.deltaTime;

            timeText.text = "Time: " + (int)surviveTime;
        }
        else {
            if (Input.GetKeyDown(KeyCode.R)) {
                RestartGame();
            }
        }
    }

    public void EndGame() {
        isGameOver = true;

        gameoverText.SetActive(true);
        playerOJ.SetActive(false);


        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if (surviveTime > bestTime) {
            bestTime = surviveTime;

            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        messageText.text = "Game Over\n Press 'R' to restart";
    }

    public void IncreaseKillScore() {
        killScore++;
        UpdateKillScoreText();
    }

    void UpdateKillScoreText() {
        killScoreText.text = "Kills: " + killScore.ToString();
        killScoreText.transform.position = initialTextPosition;
    }

    void RestartGame() {
        SceneManager.LoadScene("SampleScene");
    }

    public void UpdateLifeText(int currentLife) {
        lifeText.text = "Life: " + currentLife.ToString();
    }
}
