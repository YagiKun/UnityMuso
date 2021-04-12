using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*エネミーを倒す*/

public class SwordScript : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Enemy" || col.gameObject.tag == "Orange" || col.gameObject.tag == "Lemon")
        {
            Destroy(col.gameObject);
        }
    }
}
