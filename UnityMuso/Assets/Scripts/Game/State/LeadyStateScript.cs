using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeadyStateScript : MonoBehaviour
{
    AudioSource UnityChanVoice;
    [SerializeField] AudioClip ReadyVoice;

    bool voicef = false;

    //状態遷移のために画面のカウントをする
    public static float count = 0.0f;
    public static float countLimit = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        count = 0.0f;
        UnityChanVoice = GameObject.Find("unitychan").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameControler.State == GameControler.LeadyState_s)
        {
            if (count >= 1.0f )
            {
                //開始時ボイス再生
                if (!voicef)
                {
                    UnityChanVoice.PlayOneShot(ReadyVoice);
                }
                voicef = true;
            }
            count += Time.deltaTime;
        }
    }
}
