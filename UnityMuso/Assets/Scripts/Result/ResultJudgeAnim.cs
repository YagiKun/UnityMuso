using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*リザルト画面、ジャッジ文字を動かす*/
public class ResultJudgeAnim : MonoBehaviour
{
    ResultState state;

    //動かすオブジェクトのグループ
    [SerializeField] GameObject Group1;
    [SerializeField] GameObject Group2;

    [SerializeField] Animator Unitychan;

    [SerializeField] Animator CutAnim;
    [SerializeField] Animator RankAnim;

    [SerializeField] Animator[] JudgeBar = new Animator[3];
    [SerializeField] Animator[] Judge = new Animator[3];
    float count = 0;

    
    [SerializeField] Text[] ScoreText = new Text[3];
    [SerializeField] Text CutText;
    [SerializeField] GameObject RankText;

    [SerializeField] AudioSource countSound;
    bool soundF = false;

    [SerializeField] Animator TextAnim;

    [SerializeField] AudioSource MoveSound;
    
    [SerializeField] AudioSource UnitychanAudio;
    [SerializeField] AudioClip[] RankVoice = new AudioClip[4];

    void Start()
    {
        state = GameObject.Find("Main Camera").GetComponent<ResultState>();
    }

    // Update is called once per frame
    void Update()
    {
        //判定表示
        if (state.RS == ResultState.R_State.JudgeView)
        {
            //上三つ、バー
            if (0.0f <= count && count < 0.2f)
            {
                Unitychan.SetBool("AnimF", true);
                CutAnim.SetBool("AnimF", true);
                RankAnim.SetBool("AnimF", true);
                JudgeBar[0].SetBool("AnimF", true);
            }
            if (0.2f <= count && count < 0.4f)
            {
                JudgeBar[1].SetBool("AnimF", true);
            }
            if (0.4f <= count && count < 0.6f)
            {
                JudgeBar[2].SetBool("AnimF", true);
            }
            //上三つ、ロゴ
            if (0.6f <= count && count < 0.8f)
            {
                Judge[0].SetBool("AnimF", true);
            }
            else if (0.8f <= count && count < 1.0)
            {
                Judge[1].SetBool("AnimF", true);
            }
            else if (1.0f <= count && count < 1.2f)
            {
                Judge[2].SetBool("AnimF", true);
            }
            //各スコア
            else if (1.4f <= count && count < 2.4f)
            {
                if (!soundF)
                {
                    countSound.Play();
                    soundF = true;
                }
                ScoreText[0].text = Mathf.Lerp(0, GameControler.ScoreExcellent, count - 1.4f).ToString("0");
                ScoreText[1].text = Mathf.Lerp(0, GameControler.ScoreGood, count - 1.4f).ToString("0");
                ScoreText[2].text = Mathf.Lerp(0, GameControler.ScoreBad, count - 1.4f).ToString("0");
            }
            else if(2.4f <= count)
            {
                soundF = false;
                ScoreText[0].text = "" + GameControler.ScoreExcellent;
                ScoreText[1].text = "" + GameControler.ScoreGood;
                ScoreText[2].text = "" + GameControler.ScoreBad;
            }

            count += Time.deltaTime;

            //状態遷移
            if (count >= 2.6f)
            {
                count = 0;
                state.RS = ResultState.R_State.CutView;
            }
        }
        //切ったフルーツを表示
        if (state.RS == ResultState.R_State.CutView)
        {
            //スコア
            if (0f <= count && count < 1.0f)
            {
                if (!soundF)
                {
                    countSound.Play();
                    soundF = true;
                }
                CutText.text = Mathf.Lerp(0, GameControler.ScoreCut, count).ToString("0");
            }

            count += Time.deltaTime;

            //状態遷移
            if (count >= 1.2f)
            {
                soundF = false;
                count = 0;
                state.RS = ResultState.R_State.RankView;
            }
        }
        //ランクを表示
        if (state.RS == ResultState.R_State.RankView)
        {
            //スコア
            if(0 == count)
            {
                switch (GameControler.ScoreRank)
                {
                    case "S":
                        UnitychanAudio.PlayOneShot(RankVoice[0]);
                        break;
                    case "A":
                        UnitychanAudio.PlayOneShot(RankVoice[1]);
                        break;
                    case "B":
                        UnitychanAudio.PlayOneShot(RankVoice[2]);
                        break;
                    case "C":
                        UnitychanAudio.PlayOneShot(RankVoice[3]);
                        break;
                }
            }
            if (0f <= count && count < 1.0f)
            {
                RankText.GetComponent<Text>().text = GameControler.ScoreRank;
                RankText.gameObject.transform.localScale = Vector2.Lerp(new Vector2(1.5f, 1.5f), Vector2.one, 1 - Mathf.Pow(1 - count, 3));
            }
            else
            {
                TextAnim.SetBool("AnimF", true);
            }

            count += Time.deltaTime;

            //状態遷移 クリックしたら
            if (count >= 1.2f && Input.GetMouseButton(0))
            {
                MoveSound.Play();
                count = 0;
                state.RS = ResultState.R_State.NextMove;
            }
        }
        //次の行動を選んでね
        if (state.RS == ResultState.R_State.NextMove)
        {
            if(0f <= count && count <= 1.0f)
            {
                Group1.transform.localPosition = Vector2.Lerp(Vector2.zero, new Vector2(0, 1100), 1 - Mathf.Pow(1 - count, 4));
                Group2.transform.localPosition = Vector2.Lerp(new Vector2(0, -1000), Vector2.zero, 1 - Mathf.Pow(1 - count, 4));

                count += Time.deltaTime;
            }

        }

    }
}
