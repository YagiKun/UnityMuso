using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*リザルト画面のボタン関連*/
public class ResultButtons : MonoBehaviour
{
    bool ClickF = false;
    float count = 0;

    //使わないほうのナイフ
    [SerializeField] GameObject elseKnife;
    Vector2 elsePos;

    Animator anim;
    AudioSource BGM;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        elsePos = elseKnife.gameObject.transform.localPosition;

        BGM = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ClickF)
        {
            if(0<=count && count <= 1.0f)
            {
                anim.SetBool("RollF", true);
                elseKnife.transform.localPosition = Vector2.Lerp(elsePos, new Vector2(1300, elsePos.y), 1 - Mathf.Pow(1 - count, 3));
            }
            else
            {

            }

            count += Time.deltaTime;
        }
    }

    //クリックしたとき共通の動き
    public void ButtonClick()
    {
        if (!ClickF)
        {
            Invoke("ChangeScene_1", 0.5f);
            if(gameObject.name == "TitleButton")
            {
                Invoke("ChangeScene_2_Title", 2);
            }
            else if (gameObject.name == "RetryButton")
            {
                Invoke("ChangeScene_2_Game", 2);
            }
            BGM.Stop();
        }
        ClickF = true;
    }

    //シーン遷移の為、フェード
    void ChangeScene_1()
    {
        FadeController.FadeIn();
    }

    //タイトルへ
    void ChangeScene_2_Title()
    {
        SceneManager.LoadScene("Title");
    }
    //ゲームへ
    void ChangeScene_2_Game()
    {
        SceneManager.LoadScene("GameScene");
    }
}
