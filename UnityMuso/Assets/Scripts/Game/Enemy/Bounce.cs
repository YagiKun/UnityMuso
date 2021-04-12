using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*跳ねる*/

public class Bounce : MonoBehaviour
{
    float defaultHeightOrange = 0.7f;
    float defaultHeightLemon = 0.6f;
    float defaultHeightLime = 0.6f;
    Vector3 defaultPos;
    float topHeight = 2.5f;
    Vector3 topPos;
    [SerializeField] float BPM = 128;         //跳ねるBPM
    public static float speed = 60.0f / 128;       //跳ねるスピ―ド

    //それぞれの果物の高さ
    public static float posYOrange;
    public static float posYLemon;
    public static float posYLime;
    //public static float posY;

    float gameTime;
    public static float t;        //Lerpの第三引数

    public static AudioSource BGM;

    // Start is called before the first frame update
    void Start()
    {
        gameTime = 0;
        speed = 60.0f / BPM;
        
        //defaultPos = new Vector3(transform.position.x, defaultHeight, transform.position.z);
        //topPos = new Vector3(transform.position.x, topHeight, transform.position.z);

        BGM = GetComponent<AudioSource>();
        //BGM.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //ゲーム中
        if (GameControler.State == GameControler.GameState_s || GameControler.State == GameControler.DeathState_s)
        {
            //時間の更新
            //gameTime += Time.deltaTime;
            gameTime = BGM.time;
            t = gameTime % speed;

            //上昇する動き
            if (t < speed / 2)
            {
                //gameObject.transform.position = Vector3.Lerp(defaultPos, topPos, 1 - Mathf.Pow(1 - (t * (1 / (speed / 2))), 3));
                posYOrange = Mathf.Lerp(defaultHeightOrange, topHeight, 1 - Mathf.Pow(1 - (t * (1 / (speed / 2))), 2.7f));
                posYLemon = Mathf.Lerp(defaultHeightLemon, topHeight, 1 - Mathf.Pow(1 - (t * (1 / (speed / 2))), 2.7f));
                posYLime = Mathf.Lerp(defaultHeightLime, topHeight, 1 - Mathf.Pow(1 - (t * (1 / (speed / 2))), 2.7f));
                //posY = Mathf.Lerp(defaultHeight, topHeight, 1 - Mathf.Pow(1 - (t * (1 / (speed / 2))), 3));
            }
            //下降する動き
            else
            {
                //gameObject.transform.position = Vector3.Lerp(defaultPos, topPos, 1 - Mathf.Pow(((t - speed/2) * (1 / (speed / 2))) , 3));
                posYOrange = Mathf.Lerp(defaultHeightOrange, topHeight, 1 - Mathf.Pow(((t - speed / 2) * (1 / (speed / 2))), 2.7f));
                posYLemon = Mathf.Lerp(defaultHeightLemon, topHeight, 1 - Mathf.Pow(((t - speed / 2) * (1 / (speed / 2))), 2.7f));
                posYLime = Mathf.Lerp(defaultHeightLime, topHeight, 1 - Mathf.Pow(((t - speed / 2) * (1 / (speed / 2))), 2.7f));
                //posY = Mathf.Lerp(defaultHeight, topHeight, 1 - Mathf.Pow(((t - speed / 2) * (1 / (speed / 2))), 3));
                //Debug.Log(gameObject.transform.position);
            }
        }
    }
}
