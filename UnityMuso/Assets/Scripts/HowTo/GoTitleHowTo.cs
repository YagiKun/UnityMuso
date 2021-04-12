using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*How2->タイトル*/

public class GoTitleHowTo : MonoBehaviour
{
    AudioSource BGM;

    // Start is called before the first frame update
    void Start()
    {
        BGM = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    //タイトルへボタン押下
    public void GoTitleButtonClick()
    {
        FadeController.FadeIn();
        BGM.Stop();
        Invoke("SceneChange", 2f);
    }

    //シーン変更
    void SceneChange()
    {
        SceneManager.LoadScene("GameScene");
    }
}
