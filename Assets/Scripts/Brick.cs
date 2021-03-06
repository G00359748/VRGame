using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Brick : MonoBehaviour
{
    public Text MylifeText;
    private int LifeScore;

    // Start is called before the first frame update
    void Start()
    {
        LifeScore = 1;
        MylifeText.text = "Lives : " + LifeScore;
    }

    private void OnTriggerEnter2D(Collider2D brick)
    {
        if (brick.tag == "brick")
        {
            LifeScore -= 1;
            Destroy(brick.gameObject);
            MylifeText.text = "Lives : " + LifeScore;
        }
       

    }

    private void Life()
    {
        if (LifeScore <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
