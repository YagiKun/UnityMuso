using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*フェードイン、フェードアウトを取り扱うスクリプト*/
public class FadeScript : MonoBehaviour
{
    [SerializeField] RectTransform BlackPanel_1;
    [SerializeField] RectTransform BlackPanel_2;
    [SerializeField] RectTransform WhitePanel_1;
    [SerializeField] RectTransform WhitePanel_2;
    
    public static string FadeCode = "";
    public static float count = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.SetParent(GameObject.Find("Canvas").transform);
        transform.localPosition = Vector3.zero;

        if (FadeCode == "in")
        {
            BlackPanel_1.sizeDelta = BlackPanel_2.sizeDelta = new Vector2(0, 1080);
            WhitePanel_1.sizeDelta = WhitePanel_2.sizeDelta = new Vector2(1920, 0);
        }
        else if (FadeCode == "out")
        {
            BlackPanel_1.sizeDelta = BlackPanel_2.sizeDelta = new Vector2(960, 1080);
            WhitePanel_1.sizeDelta = WhitePanel_2.sizeDelta = new Vector2(1920, 540);
        }

        count = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(FadeCode == "in")
        {
            if (0 <= count && count <= 1f)
            {
                BlackPanel_1.sizeDelta = BlackPanel_2.sizeDelta = Vector2.Lerp(new Vector2(0, 1080), new Vector2(960, 1080), 1 - Mathf.Pow(1 - count, 2));
            }
            else
            {
                BlackPanel_1.sizeDelta = BlackPanel_2.sizeDelta = new Vector2(960, 1080);
            }
            if (0.5f<=count && count <1.5f)
            {
                WhitePanel_1.sizeDelta = WhitePanel_2.sizeDelta = Vector2.Lerp(new Vector2(1920, 0), new Vector2(1920, 540), 1 - Mathf.Pow(1 - (count - 0.5f), 2));
            }
            else if(1.5f <= count)
            {
                WhitePanel_1.sizeDelta = WhitePanel_2.sizeDelta = new Vector2(1920, 540);
                //Destroy(this.gameObject);
            }

            count += Time.deltaTime;
        }
        else if(FadeCode == "out")
        {
            if (1.0 <= count && count < 2f)
            {
                WhitePanel_1.sizeDelta = WhitePanel_2.sizeDelta = Vector2.Lerp(new Vector2(1920, 540), new Vector2(1920, 0), 1 - Mathf.Pow(1 - (count - 1.0f), 2));
            }
            else if(2.0f <= count)
            {
                WhitePanel_1.sizeDelta = WhitePanel_2.sizeDelta = new Vector2(1920, 0);
            }
            if (1.5f <= count && count < 2.5f)
            {
                BlackPanel_1.sizeDelta = BlackPanel_2.sizeDelta = Vector2.Lerp(new Vector2(960, 1080), new Vector2(0, 1080), 1 - Mathf.Pow(1 - (count - 1.5f), 2));
            }
            else if(2.5f <= count && count < 4.0f)
            {
                BlackPanel_1.sizeDelta = BlackPanel_2.sizeDelta = new Vector2(0, 1080);
            }
            else if(4.0f <= count)
            {
                Destroy(this.gameObject);
            }

            count += Time.deltaTime;
        }
    }
}
