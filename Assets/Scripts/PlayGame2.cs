using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class PlayGame2 : MonoBehaviour
{
    private GrammarRecognizer gr;

    // Start is called before the first frame update
    void Start()
    {
        gr = new GrammarRecognizer(Path.Combine(Application.streamingAssetsPath, "Grammer.xml"), ConfidenceLevel.Low);
        gr.OnPhraseRecognized += GR_OnPhraseRecognized;
        gr.Start();
        Debug.Log("Grammar Loaded and Recogniser Started");
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

            if (valueString == "play")
            {
                Play();
            }
        }
        Debug.Log(message);


    }

    void Play()
    {
        SceneManager.LoadScene("Level2");
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


