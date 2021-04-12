using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*リザルト画面の状態遷移*/
public class ResultState : MonoBehaviour
{
    public enum R_State
    {
        FadeIn,
        JudgeView,
        CutView,
        RankView,
        NextMove,
        FadeOut
    }

    public R_State RS = R_State.FadeIn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(RS == R_State.FadeIn)
        {
            Invoke("ResultStateChange", 2.0f);
        }
    }

    void ResultStateChange()
    {
        RS = R_State.JudgeView;
    }
}
