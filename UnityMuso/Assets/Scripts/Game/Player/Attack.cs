using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*攻撃のスクリプト*/

public class Attack : MonoBehaviour
{
    int attackF = 0;

    GameObject AttackObj;     //攻撃の当たり判定のオブジェクト
    Collider AttackCol;     //攻撃の当たり判定
    [SerializeField] float AttackInterval = 0.2f;  //攻撃が終わるまでのインターバル
    Animator anim;

    //BGMの小節の内、どのくらいを当たり判定にするか
    [Range(0, 1)]
    [SerializeField]
    float ExcellentRange = 0.1f;     //Excelent判定にする割合
    [Range(0, 1)]
    [SerializeField]
    float GoodRange = 0.3f;         //Good判定にする割合
    public static float ExcellentTime = 0;             //実際にExcelent判定にする時間
    public static float GoodTime = 0;                 //実際にGood判定にする時間
    //判定
    bool JudgeAttF = false;  //攻撃したフラグ(マウスクリック)
    public static bool JudgeTriF = false;  //攻撃範囲が敵に衝突したフラグ
    public static string JudgeStr = "Excellent";                    //この判定は何か
    //判定がプレイヤーにわかるように表示
    [SerializeField] GameObject[] JudgeText = new GameObject[3];

    //各アニメーションのハッシュ値
    int AT1Hash, AT2Hash, AT3Hash, PlaneHash, RunHash;

    //ユニティちゃんの声
    AudioSource voiceSource;
    [SerializeField] AudioClip[] voiceClip = new AudioClip[3];

    //攻撃時のエフェクト
    [SerializeField] GameObject[] Effect = new GameObject[3];
    GameObject EffectIns;   //実体

    // Start is called before the first frame update
    void Start()
    {
        AttackObj = GameObject.Find("AttackCol");
        AttackCol = AttackObj.GetComponent<BoxCollider>();
        anim = GetComponent<Animator>();
        ColliderReset();
        
        ExcellentTime = Bounce.speed * ExcellentRange;
        GoodTime = Bounce.speed * GoodRange;

        PlaneHash = Animator.StringToHash("Base Layer.IDOL");
        RunHash = Animator.StringToHash("Base Layer.Run");
        AT1Hash = Animator.StringToHash("Base Layer.Attack1");
        AT2Hash = Animator.StringToHash("Base Layer.Attack2");
        AT3Hash = Animator.StringToHash("Base Layer.Attack3");

        voiceSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //音ゲー判定
        //Excelent
        if (ExcellentTime > Bounce.t || Bounce.speed - ExcellentTime < Bounce.t)
        {
            JudgeStr = "Excellent";
        }
        //Good
        else if (GoodTime > Bounce.t || Bounce.speed - GoodTime < Bounce.t)
        {
            JudgeStr = "Good";
        }
        //Bad
        else
        {
            JudgeStr = "Bad";
        }


        //攻撃
        if (Input.GetMouseButtonDown(0))
        {
            if (attackF < 3)
            {
                //攻撃中の時
                if (attackF >= 0 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.95f)
                {
                    //当たり判定を表示
                    AttackCol.enabled = true;
                    Invoke("Colfalse", 0.2f);
                    //攻撃したよ
                    JudgeAttF = true;

                    attackF++;
                    voiceSource.PlayOneShot(voiceClip[attackF-1]);
                    //エフェクトを表示
                    EffectIns = Instantiate(Effect[attackF - 1]);
                    EffectIns.transform.SetParent(gameObject.transform.GetChild(0));

                }
                //IDOL,Runの時
                else if(anim.GetCurrentAnimatorStateInfo(0).nameHash == RunHash || anim.GetCurrentAnimatorStateInfo(0).nameHash == PlaneHash)
                {

                    //当たり判定を表示
                    AttackCol.enabled = true;
                    Invoke("Colfalse", 0.2f);
                    //攻撃したよ
                    JudgeAttF = true;

                    attackF++;
                    voiceSource.PlayOneShot(voiceClip[attackF - 1]);
                    //エフェクトを表示
                    EffectIns = Instantiate(Effect[attackF - 1]);
                    EffectIns.transform.SetParent(gameObject.transform.GetChild(0));
                }
            }
        }

        //攻撃アニメーションが終わったら
        if((anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f && anim.GetCurrentAnimatorStateInfo(0).nameHash == AT1Hash) || (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f && anim.GetCurrentAnimatorStateInfo(0).nameHash == AT2Hash) || (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f && anim.GetCurrentAnimatorStateInfo(0).nameHash == AT3Hash))
        {
            ColliderReset();
        }
        //sttackF = 3 になったままバグが起こった時用
        if (anim.GetCurrentAnimatorStateInfo(0).nameHash == PlaneHash && attackF == 3)
        {
            ColliderReset();
        }
        //Debug.Log("time = " + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

        anim.SetInteger("isAttack", attackF);
    }
    void FixedUpdate()
    {
        if (JudgeAttF && JudgeTriF) {
            //判定
            switch (JudgeStr)
            {
                case "Excellent":
                    Instantiate(JudgeText[0]);
                    GameControler.ScoreExcellent++;
                    break;
                case "Good":
                    Instantiate(JudgeText[1]);
                    GameControler.ScoreGood++;
                    break;
                case "Bad":
                    Instantiate(JudgeText[2]);
                    GameControler.ScoreBad++;
                    break;
            }
            JudgeAttF = false;
        }
        JudgeTriF = false;
    }

    void ColliderReset()
    {
        anim.SetInteger("isAttack", 0);
        attackF = 0;
        AttackCol.enabled = false;
    }


    //Invokeで使う
    //当たり判定を消す
    void Colfalse()
    {
        AttackCol.enabled = false;
        JudgeAttF = false;
    }
}
