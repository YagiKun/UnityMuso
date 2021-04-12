using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*タイトル画面のボタン関連*/
public class TitleButtons : MonoBehaviour
{
    TitleFade titlefade;

    GameObject[] Knife = new GameObject[3];

    AudioSource BGM;

    // Start is called before the first frame update
    void Start()
    {
        titlefade = GameObject.Find("Main Camera").GetComponent<TitleFade>();

        Knife[0] = GameObject.Find("StartButton");
        Knife[1] = GameObject.Find("CreditButton");
        Knife[2] = GameObject.Find("ExitButton");

        BGM = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoGame()
    {
        BGM.Stop();
        titlefade.TitleFadeOut(Knife[1], Knife[2], Knife[0]);
        Invoke("SceneChange_Game", 2f);
    }
    public void GoCredit()
    {
        BGM.Stop();
        titlefade.TitleFadeOut(Knife[0], Knife[2], Knife[1]);
        Invoke("SceneChange_Credit", 2f);
    }
    public void Exit()
    {
        BGM.Stop();

        titlefade.TitleFadeOut(Knife[0], Knife[1], Knife[2]);

#if UNITY_EDITOR
        Invoke("EndGameEditor", 2f);
#elif UNITY_STANDALONE
        Invoke("EndGameStandalone", 2f);        
#endif
    }

    //シーン移動
    public void SceneChange_Game()
    {
        SceneManager.LoadScene("HowTo");
    }
    public void SceneChange_Credit()
    {
        SceneManager.LoadScene("Credit");
    }

    //ゲーム終了
    public void EndGameEditor()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    public void EndGameStandalone()
    {
#if UNITY_STANDALONE
        UnityEngine.Application.Quit();
#endif
    }
}
