using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*ダメージを受ける*/
public class DamageResave : MonoBehaviour
{
    //以下、処理を連続で行わない内容
    bool ViewF = false;     //処理を行っているかどうかのフラグ
    float interval = 0.8f;

    //被ダメージ時声
    AudioSource audio;
    [SerializeField] AudioClip[] clip = new AudioClip[3];

    //ダメージ音
    AudioSource HitAudio;


    //ダメージを受けたときにスキンを赤くする
    Image DamageEffect;
    float count = 1.0f;

    void Start()
    {
        audio = GameObject.Find("HP_Face").GetComponent<AudioSource>();
        DamageEffect = GameObject.Find("HP_DamageEffect").GetComponent<Image>();

        HitAudio = GameObject.Find("HitAudioObj").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(count < 1.0f)
        {
            count += Time.deltaTime * 2;
            DamageEffect.color = Color.Lerp(new Color(1, 0, 0, 100.0f / 255.0f), new Color(1, 0, 0, 0), count);
        }
    }

    //敵と衝突
    void OnCollisionStay(Collision col)
    {
        //ゲーム中
        if (GameControler.State == GameControler.GameState_s)
        {
            if (col.gameObject.tag == "Lemon" || col.gameObject.tag == "Lime" || col.gameObject.tag == "Orange")
            {
                //体力を減らす
                GameControler.HP--;

                //ヒット音が鳴っていなければ鳴らす
                if (!HitAudio.isPlaying)
                {
                    HitAudio.Play();
                    count = 0;
                }

                if (!ViewF)
                {
                    //ダメージボイス
                    audio.PlayOneShot(clip[(int)Random.Range(0, 3)]);
                    //ダメージ音声

                    //ダメージ画像
                    ImageController.PlayDamage();
                    //数秒後に画像戻す
                    Invoke("DamageEnd", interval);

                    ViewF = true;
                }
            }
        }


    }

    //ダメージ受けている処理終了(立ち絵、声)
    void DamageEnd()
    {
        //まだ体力があれば
        if (GameControler.HP > 0)
        {
            //立ち絵を元に戻し、再度ダメージアニメーションができるようにする
            ImageController.PlayNomal();
            ViewF = false;
        }
    }
}
