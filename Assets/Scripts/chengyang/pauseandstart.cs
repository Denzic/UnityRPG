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

            StopCalled();

        });

        keywords.Add("start", () =>

        {

            GoCalled();

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

    void StopCalled()
    {

        Debug.Log("You just said pause");
        Time.timeScale = 0;

    }

    void GoCalled()
    {

        Debug.Log("You just said go");
        Time.timeScale = 1;

    }





}