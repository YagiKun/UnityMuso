using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*タイトルのリズムを刻む*/
public class TitleRhythm : MonoBehaviour
{
    int BPM = 128;
    AudioSource BGM;

    //リズムを刻むタイミング
    float rhythm = 60.0f / 128;

    float gameTime = 0;
    public static float t;        //Lerpの第三引数

    //動かすObject群
    GameObject UnityChan;
    GameObject Title_speaker;
    GameObject Title_word;


    // Start is called before the first frame update
    void Start()
    {
        BGM = GetComponent<AudioSource>();

        UnityChan = GameObject.Find("CharctorImage");
        Title_speaker = GameObject.Find("Title_Speaker");
        Title_word = GameObject.Find("Title_Word");
    }

    // Update is called once per frame
    void Update()
    {
        gameTime = BGM.time;
        t = gameTime % rhythm;

        //上昇する動き
        if (t < rhythm / 2)
        {
            //Title_speaker.transform.localScale = Vector2.Lerp(new Vector2(1.5f, 1.5f), new Vector2(1.375f, 1.375f), 1 - Mathf.Pow(1 - (t * (1 / (rhythm / 2))), 10));
            //Title_word.transform.localScale = Vector2.Lerp(new Vector2(1.25f, 1.25f), new Vector2(1.375f, 1.375f), 1 - Mathf.Pow(((t - rhythm / 2) * (1 / (rhythm / 2))), 10));
            Title_speaker.transform.localScale = Vector2.Lerp(new Vector2(1.5f, 1.5f), new Vector2(1.375f, 1.375f), t * (1 / (rhythm / 2)));
            UnityChan.transform.localScale = Vector2.Lerp(new Vector2(1, 0.9f), Vector2.one, t * (1 / (rhythm / 2)));
        }
        //下降する動き
        else
        {
            //Title_speaker.transform.localScale = Vector2.Lerp(new Vector2(1.375f, 1.375f), new Vector2(1.5f,1.5f), 1 - Mathf.Pow(1 - (t * (1 / (rhythm / 2))), 10));
            //Title_word.transform.localScale = Vector2.Lerp(new Vector2(1.375f, 1.375f), new Vector2(1.25f, 1.25f), 1 - Mathf.Pow(1 - (t * (1 / (rhythm / 2))), 10));
        }
    }
}
