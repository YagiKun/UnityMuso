using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//半分の果物を消す
public class HalfDeath : MonoBehaviour
{
    private void Start()
    {
        //2秒後にオブジェクトを消す
        Invoke("Destroy", 2);
    }

    //Invokeで使う
    void Destroy()
    {
        Destroy(gameObject);
    }
}
