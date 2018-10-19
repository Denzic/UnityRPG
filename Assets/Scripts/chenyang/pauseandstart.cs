using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;

public class pauseandstart : MonoBehaviour
{

    KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    void Start()
    {
        //initializa stuff
        keywords.Add("stop", () =>

        {

            Pause();

        });
        

        keywords.Add("start", () =>

        {

            Continue();

        });

        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizerOnphraseRecognized;
        keywordRecognizer.Start();

    }

    void KeywordRecognizerOnphraseRecognized(PhraseRecognizedEventArgs args)
    {

        System.Action keywordAction;

        if (keywords.TryGetValue(args.text, out keywordAction))
        {

            keywordAction.Invoke();

        }

    }

    void Pause()
    {

        Debug.Log("You just said pause");
        Time.timeScale = 0;

    }

    void Continue()
    {
        Debug.Log("You just said continue");
        Time.timeScale = 1;


    }



}