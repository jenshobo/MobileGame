using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointSystem : MonoBehaviour
{
    public GameObject pointCircle;
    public GameObject cameraObject;
    public Text pointText;

    public float maxRandomX;
    public float maxRandomY;
    public float minRandomX;
    public float minRandomY;

    private int points = 0;
    private int highScore;
    private int currentsie;
    private float randomLocationX;
    private float randomLocationY;
    private int neededPoints = 5;

    void Update()
    {
        pointText.text = "points: " + points.ToString();

        if (highScore > PlayerPrefs.GetInt("HighScore", 0))
            PlayerPrefs.SetInt("HighScore", points);
        PlayerPrefs.SetInt("Currentsie", currentsie);

        if (points >= neededPoints)
        {
            neededPoints += 5;
            LevelSystem selectNewLevel = cameraObject.transform.GetComponent<LevelSystem>();
            selectNewLevel.LoadNewLevel();
        }

        highScore = points;
    }

    void Start()
    {
        InvokeRepeating("UpdateLocation", 0, 15);
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        currentsie = PlayerPrefs.GetInt("Currentsie", 0);
    }

    public void UpdateLocation()
    {
        randomLocationX = Random.Range(minRandomX, maxRandomX);
        randomLocationY = Random.Range(minRandomY, maxRandomY);
        pointCircle.transform.position = new Vector2(randomLocationX, randomLocationY);

        Instantiate(pointCircle);
    }

    public void UpdateState()
    {
        currentsie += 100; //moet 100 zijn
        points++;
    }
}