using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*判定のテキスト*/
/*Canvasの子にする、削除する*/

public class JudgeText : MonoBehaviour
{
    GameObject Canvas;

    // Start is called before the first frame update
    void Start()
    {
        Canvas = GameObject.Find("Canvas");
        gameObject.transform.SetParent(Canvas.transform);
        transform.localPosition = new Vector3(0, -350, 0);

        Invoke("DestroyObj", 1);

    }

    //判定画像を削除する
    void DestroyObj()
    {
        Destroy(this.gameObject);
    }
}
