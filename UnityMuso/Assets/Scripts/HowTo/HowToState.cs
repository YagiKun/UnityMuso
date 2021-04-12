using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*遊び方画面状態遷移*/
public class HowToState : MonoBehaviour
{
    //1~3
    int state = 1;
    float count = 1;
    Vector2 BeforePos;

    [SerializeField] GameObject StatePanel;
    Vector2[] pos = new Vector2[3];

    [SerializeField] Text UnityText;

    // Start is called before the first frame update
    void Start()
    {
        BeforePos = Vector2.zero;
        pos[0] = Vector2.zero;
        pos[1] = new Vector2(-1300, 0);
        pos[2] = new Vector2(-2600, 0);
    }

    // Update is called once per frame
    void Update()
    {
        StatePanel.transform.localPosition = Vector2.Lerp(BeforePos, pos[state-1], 1 - Mathf.Pow(1 - count, 3));
      
        if (count < 1.0f)
        {

            count += Time.deltaTime;
        }
        else
        {
            count = 1.0f;
        }
    }

    public void BeforeState()
    {
        if(state != 1)
        {
            state--;
            count = 0;
            BeforePos = StatePanel.transform.localPosition;
            switch (state)
            {
                case 1:
                    UnityText.text = "地面に付いたタイミングで切るといいよ！";
                    break;
                case 2:
                    UnityText.text = "画面構成だよ！\n気になるところにマウスをもっていこう！";
                    break;
                case 3:
                    UnityText.text = "ふむふむ。こうやってうごかすのか。";
                    break;
            }
        }
    }
    public void AfterState()
    {
        if (state != 3)
        {
            state++;
            count = 0;
            BeforePos = StatePanel.transform.localPosition;
            switch (state)
            {
                case 1:
                    UnityText.text = "地面に付いたタイミングで切るといいよ！";
                    break;
                case 2:
                    UnityText.text = "画面構成だよ！\n気になるところにマウスをもっていこう！";
                    break;
                case 3:
                    UnityText.text = "ふむふむ。こうやってうごかすのか。";
                    break;
            }
        }

    }
}
