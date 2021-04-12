using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*敵が負けたとき*/
public class EnemyDeath : MonoBehaviour
{
    GameObject Player;
    GameObject[] HalfObject = new GameObject[3];

    //半分のオブジェクトの実体
    GameObject HalfObjIns;

    void Start()
    {
        Player = GameObject.Find("unitychan");

        HalfObject[0] = Resources.Load("LemonHalf") as GameObject;
        HalfObject[1] = Resources.Load("LimeHalf") as GameObject;
        HalfObject[2] = Resources.Load("OrangeHalf") as GameObject;
    }

    void Update()
    {
        //ゲームクリア時
        if (GameControler.State == GameControler.GameState.Finish)
        {
            FluitsDeath();
        }
    }

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Attack")
        {
            EnemySpone.EnemyNum--;
            FluitsDeath();
        }
    }    

    void FluitsDeath()
    {
        //半分のものを生み出す
        switch (gameObject.tag)
        {
            case "Lemon":
                HalfObjIns = Instantiate(HalfObject[0], transform.position, Quaternion.identity);
                break;
            case "Lime":
                HalfObjIns = Instantiate(HalfObject[1], transform.position, Quaternion.identity);
                break;
            case "Orange":
                HalfObjIns = Instantiate(HalfObject[2], transform.position, Quaternion.identity);
                break;
        }
        //バリエーションの為回転しておく
        HalfObjIns.transform.rotation = Quaternion.Euler(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180));

        //吹っ飛ばす
        //高さの概念を入れないベクトルを作る
        Vector3 fromVec = new Vector3(Player.transform.position.x, 0, Player.transform.position.z);
        Vector3 toVec = new Vector3(transform.position.x, 0, transform.position.z);
        toVec = Vector3.Normalize(toVec - fromVec);

        toVec = toVec + new Vector3(0, 0, 0);

        HalfObjIns.transform.GetChild(0).GetComponent<Rigidbody>().AddForce(toVec * 10, ForceMode.Impulse);
        HalfObjIns.transform.GetChild(1).GetComponent<Rigidbody>().AddForce(toVec * 10, ForceMode.Impulse);
        //吹っ飛びここまで

        //攻撃したよ判定
        Attack.JudgeTriF = true;

        //スコア
        GameControler.ScoreCut++;
        switch (Attack.JudgeStr)
        {
            case "Excellent":
                GameControler.Score += 100;
                break;
            case "Good":
                GameControler.Score += 70;
                break;
            case "Bad":
                GameControler.Score += 30;
                break;
        }

        Destroy(this.gameObject);
    }
}
