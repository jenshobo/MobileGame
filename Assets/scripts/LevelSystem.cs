using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;
    public Text currentsieText;
    public GameObject spawnerTop;
    public GameObject spawnerBothem;
    public GameObject spawnerLeft;
    public GameObject spawnerRight;

    [Header("developer settings")]
    public bool resetEverything = false;

    static int levelToLoadNumber;

    private string itemID;

    public void LevelToLoad(int levelNumber)
    {
        levelToLoadNumber = levelNumber;
    }

    public void LoadNewLevel()
    {
        levelToLoadNumber++;
    }

    void Start()
    {
        if (levelToLoadNumber == 0 || levelToLoadNumber >= 7)
        {
            levelToLoadNumber = 1;
        }
    }

    void Update()
    {
        if (highScoreText != null)
            highScoreText.text = "highscore: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        if (currentsieText != null)
            currentsieText.text = "coints: " + PlayerPrefs.GetInt("Currentsie", 0).ToString();

        if (scoreText != null)
        {
            scoreText.text = "Level " + levelToLoadNumber.ToString();

            if (levelToLoadNumber >= 1)
            {
                spawnerTop.SetActive(true);
            }

            if (levelToLoadNumber >= 2)
            {
                spawnerBothem.SetActive(true);
            }

            if (levelToLoadNumber >= 3)
            {
                spawnerRight.SetActive(true);
            }

            if (levelToLoadNumber >= 4)
            {
                spawnerLeft.SetActive(true);
            }

            if (levelToLoadNumber >= 5)
            {
                Spawners spawner = spawnerTop.transform.GetComponent<Spawners>();
                spawner.UpdateState(true);
            }

            if (levelToLoadNumber >= 6)
            {
                Spawners spawner = spawnerBothem.transform.GetComponent<Spawners>();
                spawner.UpdateState(true);
            }
        }

        if (resetEverything)
        {
            PlayerPrefs.SetInt("HighScore", 0);
            PlayerPrefs.SetInt("Currentsie", 0);
        }
    }
}