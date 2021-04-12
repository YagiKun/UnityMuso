using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//UIが音楽に合わせて動く

public class UIRythm : MonoBehaviour
{
    Vector3 BeforeScaleVec = Vector3.one;
    Vector3 AfterScaleVec = new Vector3(1.1f, 1.1f, 1.1f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ゲーム中 or 死亡時
        if (GameControler.State == GameControler.GameState_s || GameControler.State == GameControler.DeathState_s)
        {
            if (Bounce.t < Bounce.speed / 2)
            {
                transform.localScale = Vector3.Lerp(AfterScaleVec, BeforeScaleVec, 1 - Mathf.Pow(1 - (Bounce.t * (1 / (Bounce.speed / 2))), 10));
            }
            //下降する動き
            else
            {
                transform.localScale = Vector3.Lerp(AfterScaleVec, BeforeScaleVec, 1 - Mathf.Pow(((Bounce.t - Bounce.speed / 2) * (1 / (Bounce.speed / 2))), 10));
            }
        }     
    }
}
