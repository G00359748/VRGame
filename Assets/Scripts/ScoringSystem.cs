using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoringSystem : MonoBehaviour
{
    public Text MyscoreText;
    private int ScoreNum;

    // Start is called before the first frame update
    void Start()
    {
        ScoreNum = 0;
        MyscoreText.text = "Score : " + ScoreNum;
    }

    private void OnTriggerEnter2D(Collider2D antman)
    {
        if (antman.tag == "antman")
        {
            ScoreNum += 10;
            Destroy(antman.gameObject);
            MyscoreText.text = "Score : " + ScoreNum;
        }
        else if (antman.tag == "brick")
        {
            SceneManager.LoadScene("GameOver");
        }

    }

}

