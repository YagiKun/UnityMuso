using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*クレジット→タイトルのスクリプト*/

public class GoTitleCredit : MonoBehaviour
{
    CreditFadeScript fade;


    // Start is called before the first frame update
    void Start()
    {
        fade = GameObject.Find("Main Camera").GetComponent<CreditFadeScript>();
    }

    //タイトルへボタン押下
    public void GoTitleButtonClick()
    {
        fade.CreditFadeOut();
        Invoke("SceneChange", 2f);
    }

    //シーン変更
    void SceneChange()
    {
        SceneManager.LoadScene("Title");
    }
}
