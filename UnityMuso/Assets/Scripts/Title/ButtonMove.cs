using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*ボタンの上にマウスをかざした時、押した時に動く*/
public class ButtonMove : MonoBehaviour
{

    //のっかっているかどうかのフラグ
    bool OnF = false;
    float count = 0;

    //クリックしたかのフラグ
    bool ClickF = false;

    AudioSource audio;
    [SerializeField] AudioClip clickSound;
    AudioSource unitychanAudio;
    [SerializeField] AudioClip startSound;
    [SerializeField] AudioClip creditSound;
    [SerializeField] AudioClip[] exitSound = new AudioClip[3];
    [SerializeField] AudioClip TitleSound;
    [SerializeField] AudioClip RetrySound;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        if (SceneManager.GetActiveScene().name == "Title" || SceneManager.GetActiveScene().name == "Result")
        {
            unitychanAudio = GameObject.Find("CharctorImage").GetComponent<AudioSource>();
        }
        else if(SceneManager.GetActiveScene().name == "Credit")
        {
            unitychanAudio = GameObject.Find("VoiceObject").GetComponent<AudioSource>();
        }
        else if (SceneManager.GetActiveScene().name == "HowTo")
        {
            unitychanAudio = GameObject.Find("UnityChan").GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (OnF)
        {
            if (count < 1.0f)
            {
                count += Time.deltaTime * 3;
            }
            else
            {
                count = 1.0f;
            }
            transform.localScale = Vector3.Lerp(Vector3.one, new Vector3(1.2f, 1.2f, 1.2f), 1 - Mathf.Pow(1 - count, 3));
        }
        else
        {
            if (count > 0.0f)
            {
                count -= Time.deltaTime * 3;
            }
            else
            {
                count = 0.0f;
            }
            transform.localScale = Vector3.Lerp(Vector3.one, new Vector3(1.2f, 1.2f, 1.2f), Mathf.Pow(count, 3));
        }
    }
            

    //上にかざした時
    public void OnButton()
    {
        if (!ClickF)
        {
            audio.Play();
            OnF = true;
        }
    }

    //外れたとき
    public void ExitButton()
    {
        OnF = false;
    }

    //ボタンを押した時
    public void ClickButton()
    {
        if (!ClickF)
        {
            //クリック音を再生
            audio.PlayOneShot(clickSound);
            //ユニティちゃんボイスを再生
            if(gameObject.name == "StartButton")
            {
                unitychanAudio.PlayOneShot(startSound);
            }
            else if (gameObject.name == "CreditButton")
            {
                unitychanAudio.PlayOneShot(creditSound);
            }
            else if (gameObject.name == "ExitButton")
            {
                unitychanAudio.PlayOneShot(exitSound[(int)Random.Range(0,3)]);
            }
            else if (gameObject.name == "TitleButton")
            {
                unitychanAudio.PlayOneShot(TitleSound);
            }
            else if (gameObject.name == "RetryButton")
            {
                unitychanAudio.PlayOneShot(RetrySound);
            }
        }
        ClickF = true;
        OnF = false;
    }
}
