using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*シーンが開いた時、他のシーンに行くとき*/

public class TitleFade : MonoBehaviour
{
    [SerializeField] GameObject TitleImage;

    [SerializeField] GameObject Panel1;
    [SerializeField] GameObject Panel2;
    float count = 0.0f;

    //in or out
    string fadeMode = "";

    //消えていくナイフオブジェクト
    GameObject[] Knife = new GameObject[3];
    Vector2[] knifePos = new Vector2[2];

    // Start is called before the first frame update
    void Start()
    {
        Knife[0] = GameObject.Find("StartButton");
        Knife[1] = GameObject.Find("CreditButton");
        Knife[2] = GameObject.Find("ExitButton");

        TitleImage.transform.localPosition = new Vector2(520, 770);
        
        Knife[0].transform.localPosition = new Vector2(400 + 1050, 100);
        Knife[1].transform.localPosition = new Vector2(300 + 1050, 250);
        Knife[2].transform.localPosition = new Vector2(200 + 1050, 400);

        Panel1.transform.localPosition = new Vector2(-1668, 347);
        Panel2.transform.localPosition = new Vector2(968, 75);

        Invoke("TitleFadeIn", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(fadeMode == "in")
        {
            if (0 <= count && count < 1)
            {
                TitleImage.transform.localPosition = Vector2.Lerp(new Vector2(520, 770), new Vector2(520, 250), 1 - Mathf.Pow(1 - count, 3));

                Knife[0].transform.localPosition = Vector2.Lerp(new Vector2(400 + 1050, 100), new Vector2(400, 100), 1 - Mathf.Pow(1 - count, 3));
                Knife[1].transform.localPosition = Vector2.Lerp(new Vector2(300 + 1050, 250), new Vector2(300, 250), 1 - Mathf.Pow(1 - count, 3));
                Knife[2].transform.localPosition = Vector2.Lerp(new Vector2(200 + 1050, 400), new Vector2(200, 400), 1 - Mathf.Pow(1 - count, 3));

                Panel1.transform.localPosition = Vector2.Lerp(new Vector2(-1668, 347), new Vector2(-2000, 347), 1 - Mathf.Pow(1 - count, 3));
                Panel2.transform.localPosition = Vector2.Lerp(new Vector2(968, 75), new Vector2(1300, 75), 1 - Mathf.Pow(1 - count, 3));
            }
            else if (1 <= count && count < 1.5)
            {
                TitleImage.transform.localPosition = new Vector2(520, 250);

                Knife[0].transform.localPosition = new Vector2(400, 100);
                Knife[1].transform.localPosition = new Vector2(300, 250);
                Knife[2].transform.localPosition = new Vector2(200, 400);

                Panel1.transform.localPosition = new Vector2(-2000, 347);
                Panel2.transform.localPosition = new Vector2(1300, 75);
            }

            count += Time.deltaTime * 2;
        }
        else if (fadeMode == "out")
        {
            if (0 <= count && count < 1)
            {
                TitleImage.transform.localPosition = Vector2.Lerp(new Vector2(520, 250), new Vector2(520, 770), 1 - Mathf.Pow(1 - count, 3));

                Knife[0].transform.localPosition = Vector2.Lerp(knifePos[0], new Vector2(knifePos[0].x + 1050, knifePos[0].y), 1 - Mathf.Pow(1 - count, 3));
                Knife[1].transform.localPosition = Vector2.Lerp(knifePos[1], new Vector2(knifePos[1].x + 1050, knifePos[1].y), 1 - Mathf.Pow(1 - count, 3));

                Panel1.transform.localPosition = Vector2.Lerp(new Vector2(-2000, 347), new Vector2(-1668, 347), 1 - Mathf.Pow(1 - count, 3));
                Panel2.transform.localPosition = Vector2.Lerp(new Vector2(1300, 75), new Vector2(968, 75), 1 - Mathf.Pow(1 - count, 3));

                //ナイフの回転
                Knife[2].GetComponent<Animator>().SetBool("RollF", true);
            }
            else if(1 <= count && count < 1.5)
            {
                TitleImage.transform.localPosition = new Vector2(520, 770);

                Knife[0].transform.localPosition = new Vector2(knifePos[0].x + 1050, knifePos[0].y);
                Knife[1].transform.localPosition = new Vector2(knifePos[1].x + 1050, knifePos[1].y);

                Panel1.transform.localPosition = new Vector2(-1668, 347);
                Panel2.transform.localPosition = new Vector2(968, 75);
            }
            else
            {
                Knife[2].GetComponent<Animator>().SetBool("MoveF", true);
            }

            count += Time.deltaTime*2;
        }
    }

    //フェードイン
    public void TitleFadeIn()
    {
        if(fadeMode == "in")
        {
            count = 0;
        }
        fadeMode = "in";
    }

//フェードアウト
public void TitleFadeOut(GameObject knife1, GameObject knife2, GameObject activeKnife)
    {
        if (fadeMode != "out")
        {
            count = 0;
        }
        fadeMode = "out";
        Knife[0] = knife1;
        Knife[1] = knife2;
        Knife[2] = activeKnife;
        knifePos[0] = Knife[0].transform.localPosition;
        knifePos[1] = Knife[1].transform.localPosition;
    }
}
