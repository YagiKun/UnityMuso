using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*クレジット画面のフェード*/
public class CreditFadeScript : MonoBehaviour
{
    [SerializeField] GameObject[] FadePanel = new GameObject[4];
    Outline[] FadeOutline = new Outline[4];

    //フェードの状態
    string FadeMode = "";

    float count = 0;

    AudioSource DoorSound;
    AudioSource BGM;
    AudioSource voice;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 4; i++)
        {
            FadeOutline[i] = FadePanel[i].GetComponent<Outline>();
        }

        //各パネル初期設定
        FadeOutline[0].effectColor = FadeOutline[1].effectColor = FadeOutline[2].effectColor = FadeOutline[3].effectColor = new Color(0, 0, 0, 0);
        FadePanel[0].transform.localPosition = new Vector2(0, 540);
        FadePanel[1].transform.localPosition = new Vector2(-960, 0);
        FadePanel[2].transform.localPosition = new Vector2(0, -540);
        FadePanel[3].transform.localPosition = new Vector2(960, -540);

        DoorSound = GameObject.Find("CreditFade").GetComponent<AudioSource>();
        BGM = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        voice = GameObject.Find("UnityChanImage").GetComponent<AudioSource>();

        Invoke("CreditFadeIn", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(FadeMode == "in")
        {
            //枠を出す
            if (0 <= count && count < 0.5f)
            {
                FadeOutline[0].effectColor = FadeOutline[1].effectColor = FadeOutline[2].effectColor = FadeOutline[3].effectColor = new Color(0, 0, 0, count * 2);
            }
            //フェード
            else if (0.5f <= count && count < 1.5f)
            {
                if (!DoorSound.isPlaying)
                {
                    BGM.Play();
                    DoorSound.Play();
                }
                FadePanel[0].transform.localPosition = Vector2.Lerp(new Vector2(0, 540), new Vector2(0, 1000), 1 - Mathf.Pow(1 - (count - 0.5f), 3));
                FadePanel[1].transform.localPosition = Vector2.Lerp(new Vector2(-960, 0), new Vector2(-1800, 0), 1 - Mathf.Pow(1 - (count - 0.5f), 3));
                FadePanel[2].transform.localPosition = Vector2.Lerp(new Vector2(0, -540), new Vector2(0, -1000), 1 - Mathf.Pow(1 - (count - 0.5f), 3));
                FadePanel[3].transform.localPosition = Vector2.Lerp(new Vector2(960, -540), new Vector2(1800, -83), 1 - Mathf.Pow(1 - (count - 0.5f), 3));
            }

            count += Time.deltaTime * 2;
        }
        else if(FadeMode == "out")
        {
            //フェード
            if (0f <= count && count < 1f)
            {
                FadePanel[0].transform.localPosition = Vector2.Lerp(new Vector2(0, 1000), new Vector2(0, 540), 1 - Mathf.Pow(1 - (count), 3));
                FadePanel[1].transform.localPosition = Vector2.Lerp(new Vector2(-1800, 0), new Vector2(-960, 0), 1 - Mathf.Pow(1 - (count), 3));
                FadePanel[2].transform.localPosition = Vector2.Lerp(new Vector2(0, -1000), new Vector2(0, -540), 1 - Mathf.Pow(1 - (count), 3));
                FadePanel[3].transform.localPosition = Vector2.Lerp(new Vector2(1800, -83), new Vector2(960, -540), 1 - Mathf.Pow(1 - (count), 3));
            }
            //枠を消す
            else if (1 <= count && count < 1.5f)
            {
                FadeOutline[0].effectColor = FadeOutline[1].effectColor = FadeOutline[2].effectColor = FadeOutline[3].effectColor = new Color(0, 0, 0, 1 - (count-1.0f) * 2);
            }
            else
            {
                FadeOutline[0].effectColor = FadeOutline[1].effectColor = FadeOutline[2].effectColor = FadeOutline[3].effectColor = new Color(0, 0, 0, 0);
            }

            count += Time.deltaTime * 2;
        }
    }

    public void CreditFadeIn()
    {
        if (FadeMode != "in")
        {
            count = 0;
        }
        FadeMode = "in";
    }

    //フェードアウト→タイトルへ
    public void CreditFadeOut()
    {
        if (FadeMode != "out")
        {
            BGM.Stop();
            DoorSound.Play();
            voice.Play();
            count = 0;
        }
        FadeMode = "out";
    }
}
