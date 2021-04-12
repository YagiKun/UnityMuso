using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*音楽表示バー*/
public class MusicBar : MonoBehaviour
{
    AudioSource BGM;
    AudioClip clip;
    Image MusicBarImg;

    //BGMの長さ
    float clipSize;
    //現在の再生位置(0~1)
    float nowSize = 0;

    // Start is called before the first frame update
    void Start()
    {
        BGM = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        clip = BGM.clip;
        MusicBarImg = GameObject.Find("MusicBar").GetComponent<Image>();

        clipSize = clip.length;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameControler.State == GameControler.GameState.Game)
        {
            //現在の再生位置を取得
            if (BGM.isPlaying)
                nowSize = BGM.time / clipSize;
            MusicBarImg.fillAmount = nowSize;
        }
        if (GameControler.State == GameControler.GameState.Finish)
        {
            MusicBarImg.fillAmount = 1;
        }
    }
}
