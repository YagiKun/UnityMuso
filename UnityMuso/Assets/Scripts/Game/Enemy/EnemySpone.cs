using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*敵を生成する*/
public class EnemySpone : MonoBehaviour
{
    [SerializeField] GameObject[] FruitsPrefab = new GameObject[3];
    GameObject[] Sponer = new GameObject[14];

    //エネミー人数
    public static int EnemyNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        EnemyNum = 0;

        //スポナー取得
        for (int i = 0; i < 14; i++)
        {
            Sponer[i] = GameObject.Find("Spone" + (i + 1));
        }
    }

    // Update is called once per frame
    void Update()
    {
        //ゲーム中
        if (GameControler.State == GameControler.GameState_s)
        {
            while (EnemyNum < 10)
            {
                Instantiate(FruitsPrefab[(int)Random.RandomRange(0, 2.9f)], Sponer[(int)Random.RandomRange(0, 13.9f)].transform.position, Quaternion.identity);

                EnemyNum++;
            }
        }
    }
}
