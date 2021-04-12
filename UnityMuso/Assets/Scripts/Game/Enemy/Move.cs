using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*プレイヤーに向かうボール*/

public class Move : MonoBehaviour
{
    float speed = 2;
    GameObject Player;

    Vector3 PlayerPos;
    Vector3 MyPos;

    //進むべき方向
    Vector3 direction;
    //進む速度
    Vector3 velocity;
    //進んだ後の位地
    Vector3 AfterPos;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("unitychan");
        rb = GetComponent<Rigidbody>();

        //最初に回転させる
        rb.AddRelativeTorque(new Vector3(0, Random.RandomRange(0, 180), Random.RandomRange(0, 180)) * 2.0f);
        rb.AddRelativeTorque(new Vector3(Random.RandomRange(0, 180), 0, -Random.RandomRange(0, 180)) * 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPos = Player.transform.position;
        PlayerPos = new Vector3(PlayerPos.x, 0, PlayerPos.z);
        MyPos = transform.position;
        MyPos = new Vector3(MyPos.x, 0, MyPos.z);

        //進む方向、速度を決める
        direction = (PlayerPos - MyPos).normalized;
        velocity = direction * speed;

        //進んだ後の位地を決める
        AfterPos = velocity * Time.deltaTime;

        //位置を設定する
        rb.velocity = Vector3.zero;
        transform.position += AfterPos;
        switch (this.gameObject.tag)
        {
            case "Orange":
                transform.position = new Vector3(transform.position.x, Bounce.posYOrange, transform.position.z);
                break;
            case "Lemon":
                transform.position = new Vector3(transform.position.x, Bounce.posYLemon, transform.position.z);
                break;
            case "Lime":
                transform.position = new Vector3(transform.position.x, Bounce.posYLime, transform.position.z);
                break;
        }
    }
}
