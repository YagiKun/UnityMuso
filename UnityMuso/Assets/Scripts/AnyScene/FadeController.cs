using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*フェード処理を呼び出すスクリプト*/
public class FadeController : MonoBehaviour
{
    public static GameObject Fade;
    void Start()
    {
        Fade = Resources.Load("FadeObject") as GameObject;
        

        FadeOut();
    }

    //フェードイン（暗く）
    public static void FadeIn()
    {
        Instantiate(Fade);
        //FadeScript.Panels[0].sizeDelta = FadeScript.Panels[1].sizeDelta = new Vector2(0, 1080);
        //FadeScript.Panels[2].sizeDelta = FadeScript.Panels[3].sizeDelta = new Vector2(1920, 0);
        FadeScript.FadeCode = "in";
    }

    //フェードアウト（明るく）
    public static void FadeOut()
    {
        Instantiate(Fade);
        //FadeScript.Panels[0].sizeDelta = FadeScript.Panels[1].sizeDelta = new Vector2(960, 1080);
        //FadeScript.Panels[2].sizeDelta = FadeScript.Panels[3].sizeDelta = new Vector2(1920, 540);
        FadeScript.FadeCode = "out";
    }
}
