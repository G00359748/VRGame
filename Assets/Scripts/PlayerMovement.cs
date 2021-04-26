using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class PlayerMovement : MonoBehaviour
{
    private GrammarRecognizer gr;
    private Transform player;
    public float speed;
    private Rigidbody2D rb;


    private void Start()
    {
        gr = new GrammarRecognizer(Path.Combine(Application.streamingAssetsPath, "Grammer.xml"), ConfidenceLevel.Low);
        gr.OnPhraseRecognized += GR_OnPhraseRecognized;
        gr.Start();
        Debug.Log("Grammar Loaded and Recogniser Started");
        player = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void GR_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        StringBuilder message = new StringBuilder();

        Debug.Log("Recognised a Phrase");
        //Read Semantic Meanings In args passed in

        SemanticMeaning[] meanings = args.semanticMeanings;
        foreach (SemanticMeaning meaning in meanings)
        {
            string keyString = meaning.key.Trim();
            string valueString = meaning.values[0].Trim();
            message.Append("Key: " + keyString + "Value: " + valueString);

            if (valueString == "up")
            {
                Up();
            }
            if (valueString == "down")
            {
                Down();
            }
            if (valueString == "left")
            {
                Left();
            }
            if (valueString == "right")
            {
                Right();
            }
            if (valueString == "chance")
            {
                Chance();
            }
            if (valueString == "move")
            {
                Move();
            }
        }
        Debug.Log(message);


    }


    void Right()
    {
        transform.Translate(2, 0, 0);
        Debug.Log("You said Right");
    }

    void Left()
    {
        transform.Translate(-2, 0, 0);
        Debug.Log("You said Left");
    }

    void Down()
    {
        transform.Translate(0, -1, 0);
        Debug.Log("You said Down");
    }

    void Up()
    {
        transform.Translate(0, 1, 0);
        Debug.Log("You said Up");
    }

    void Chance()
    {
        transform.Translate(0, 2, 0);
        Debug.Log("You said Chance");
    }

    void Move()
    {
        transform.Translate(0, -2, 0);
        Debug.Log("You said Move");
    }


    private void OnApplicationQuit()
    {
        if (gr != null && gr.IsRunning)
        {
            gr.OnPhraseRecognized -= GR_OnPhraseRecognized;
            gr.Stop();
        }
    }
}
