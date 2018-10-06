using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;

public class Recognition : MonoBehaviour
{

    KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    void start()
    {
        //initializa stuff
        keywords.Add("go", () => 
        
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

    void GoCalled()
    {

        Debug.Log("You just said go");

    }




	
}
