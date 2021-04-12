using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


/*ゲームのシステムを管理する*/
public class GameControler : MonoBehaviour
{
    public enum GameState
    {
        Leady,      //準備
        Game,       //ゲーム中
        Finish,     //ゲーム終了

        Death       //死亡
    };

    //スコア用変数
    public static int Score = 0;
    public static int ScoreCut = 0;
    public static int ScoreExcellent = 0;
    public static int ScoreGood = 0;
    public static int ScoreBad = 0;
    public static string ScoreRank = "aa";
    public static int HP = 100;

    int RankS = 15000;
    int RankA = 9750;
    int RankB = 7500;

    //スコア用テキスト
    [SerializeField] Text ScoreCutT;
    [SerializeField] Text ScoreExcellentT;
    [SerializeField] Text ScoreGoodT;
    [SerializeField] Text ScoreBadT;

    //画面状態
    public static GameState State = GameState.Leady;
    //サンプル
    public static GameState LeadyState_s = GameState.Leady;
    public static GameState GameState_s = GameState.Game;
    public static GameState FinishState_s = GameState.Finish;
    public static GameState DeathState_s = GameState.Death;

    AudioSource BGM;

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        ScoreCut = 0;
        ScoreExcellent = 0;
        ScoreGood = 0;
        ScoreBad = 0;
        ScoreRank = "";
        HP = 100;

        State = GameState.Leady;
        BGM = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //スコア等表示
        ScoreCutT.text = "" + ScoreCut;
        ScoreExcellentT.text = "" + ScoreExcellent;
        ScoreGoodT.text = "" + ScoreGood;
        ScoreBadT.text = "" + ScoreBad;



        //状態遷移 - ゲーム開始
        if(LeadyStateScript.count >= LeadyStateScript.countLimit)
        {
            if(State == GameState.Leady)
            {
                BGM.Play();
            }
            State = GameState.Game;
        }
        //状態遷移 - 死亡
        if (HP <= 0)
        {
            if (State == GameState.Game)
            {
                BGM.volume = 0;
            }
            State = GameState.Death;
        }
        //状態遷移 - 終了
        if (State == GameState.Game && Bounce.BGM.time == 0.0f && !Bounce.BGM.isPlaying)
        {
            State = GameState.Finish;
            RankCorrect();
            Invoke("GoResult", 4.5f);
        }
        if (DeathStateScript.count >= DeathStateScript.countLimit)
        {
            RankCorrect();
            GoResult();
        }
    }

    //リザルトへ行く
    void GoResult()
    {
        SceneManager.LoadScene("Result");
    }

    //ランク決定
    void RankCorrect()
    {
        if(Score < RankB)
        {
            ScoreRank = "C";
        }
        else if (Score < RankA)
        {
            ScoreRank = "B";
        }
        else if (Score < RankS)
        {
            ScoreRank = "A";
        }
        else
        {
            ScoreRank = "S";
        }
    }
}
