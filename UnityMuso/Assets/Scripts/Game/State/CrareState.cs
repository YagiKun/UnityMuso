using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*クリア時の動き*/

public class CrareState : MonoBehaviour
{
    float count = 0;
    [SerializeField] AudioSource audio;
    [SerializeField] AudioClip WinVoice;
    [SerializeField] AudioSource audioSE;
    [SerializeField] Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //終了時
        if(GameControler.State == GameControler.GameState.Finish)
        {
            if(count == 0f)
            {
                audio.PlayOneShot(WinVoice);
                audioSE.Play();
                animator.SetBool("WinF", true);
            }
            if(2.5f <= count && count <= 3.0f)
            {
                FadeController.FadeIn();
                count = 3.5f;
            }

            count += Time.deltaTime;
        }
    }
}
