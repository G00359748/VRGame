using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour
{
    private Transform bullet;
    public float speed;
    public Text MyscoreText;
    private int ScoreNum;

    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Transform>();
        ScoreNum = 0;
        MyscoreText.text = "Score : " + ScoreNum;
    }

    void FixedUpdate()
    {
        bullet.position += Vector3.up * speed;

        if (bullet.position.y >= 10)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D coin)
    {
        if (coin.tag == "coin")
        {
            ScoreNum += 50;
            Destroy(coin.gameObject);
            MyscoreText.text = "Score : " + ScoreNum;
        }
    }
}
