using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*死んでしまった時のスクリプト*/

public class DeathStateScript : MonoBehaviour
{
    GameObject UnityChan;
    Animator animator;
    AudioSource audio;
    [SerializeField] AudioClip DeathVoice;

    bool fadeF = false;

    //状態遷移に使用するカウント
    public static float count = 0.0f;
    public static float countLimit = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        count = 0.0f;
        UnityChan = GameObject.Find("unitychan");
        animator = UnityChan.GetComponent<Animator>();
        audio = UnityChan.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //死亡時
        if(GameControler.State == GameControler.DeathState_s)
        {
            if(count == 0)
            {
                animator.SetBool("DeathF", true);
                audio.PlayOneShot(DeathVoice);
            }
            if(count >= 2.0f && !fadeF)
            {
                FadeController.FadeIn();
                fadeF = true;
            }

            count += Time.deltaTime;
        }
    }
}
