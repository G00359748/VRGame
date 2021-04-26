using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BrickScript : MonoBehaviour
{
    public Text MylifeText;
    private int LifeScore = 0;
    private int StartLifeScore = 1;

    // Start is called before the first frame update
    void Start()
    {
        LifeScore = StartLifeScore;
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
            LifeScore = 0;
            SceneManager.LoadScene("GameOver");
        }
    }
}
