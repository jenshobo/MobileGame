using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    [Header("Scene Selection")]
    public int sceneNumber;
    public int levelNumber;
    public GameObject cameraObject;

    [Header("Canvas Selection")]
    public GameObject mainCanvas;
    public GameObject secondCanvas;

    [Header("Shopping")]
    public int itemCosts;
    public string itemID;
    public Text buttonText;
    public GameObject levelSystem;
    public string stateKey;

    private bool itemState = true;
    private int newCurrentsie;

    public void LoadScene()
    {
        LevelSystem selectLevel = cameraObject.GetComponent<LevelSystem>();
        selectLevel.LevelToLoad(levelNumber);

        SceneManager.LoadScene(sceneNumber);
    }

    public void OpenCanvas()
    {
        mainCanvas.SetActive(false);
        secondCanvas.SetActive(true);
    }

    public void Shopping()
    {
        if (PlayerPrefs.GetInt("Currentsie", 0) >= itemCosts && itemState)
        {
            itemState = false;
            buttonText.text = "purchased";
            newCurrentsie = PlayerPrefs.GetInt("Currentsie", 0) - itemCosts;
            PlayerPrefs.SetInt("Currentsie", newCurrentsie);
            PlayerPrefs.SetString("SpriteState", itemID);
            PlayerPrefs.SetInt(stateKey, 1);
        }
        else if (PlayerPrefs.GetInt(stateKey) == 1)
        {
            PlayerPrefs.SetString("SpriteState", itemID);
        }
    }

    void Start()
    {
        if (PlayerPrefs.GetInt(stateKey) == 1 && this.transform.tag == "ShopButton")
        {
            itemState = false;
            buttonText.text = "purchased";
        }
    }
}