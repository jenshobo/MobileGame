using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float lerpSpeed = 0.1f;
    public float offset;
    public GameObject gameOverScreen;

    public SpriteRenderer spriteRenderer;
    public Sprite yellowSprite;
    public Sprite blueSprite;
    public Sprite greenSprite;
    public Sprite redSprite;
    public Sprite purpleSprite;

    private Vector3 touchEndPosition;
    private Vector3 targetPos;
    private Vector3 thisPos;
    private float angle;
    private bool gameOver = true;

    void Start()
    {
        if (gameObject.tag == "Player")
        {
            if (PlayerPrefs.GetString("SpriteState") == "3367")
            {
                spriteRenderer.sprite = redSprite;
            }
            else if (PlayerPrefs.GetString("SpriteState") == "5065")
            {
                spriteRenderer.sprite = greenSprite;
            }
            else if (PlayerPrefs.GetString("SpriteState") == "4472")
            {
                spriteRenderer.sprite = blueSprite;
            }
            else if (PlayerPrefs.GetString("SpriteState") == "9614")
            {
                spriteRenderer.sprite = yellowSprite;
            }
            else
            {
                spriteRenderer.sprite = purpleSprite;
            }
        }
    }

    void Update()
    {
        if (gameOver)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = 0f;

                touchEndPosition = touchPosition;
            }

            if (gameObject.tag != "Player")
            {
                transform.Rotate(Vector3.forward);
            }
            else
            {
                targetPos = touchEndPosition;
                thisPos = transform.position;
                targetPos.x = targetPos.x - thisPos.x;
                targetPos.y = targetPos.y - thisPos.y;
                angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;

                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));
            }

            transform.position = Vector3.Lerp(transform.position, touchEndPosition, lerpSpeed);
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Projectal" && this.gameObject.transform.tag == "Player" || collision.transform.tag == "WormPart" && this.gameObject.transform.tag == "Player")
        {
            gameOverScreen.SetActive(true);
            gameOver = false;
        }
        else if (collision.transform.tag == "PointCircle" && this.gameObject.transform.tag == "Player")
        {
            PointSystem pointSystem = this.gameObject.GetComponent<PointSystem>();
            Destroy(collision);
            pointSystem.UpdateState();
        }
    }
}