using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*自動でエフェクトを消す*/
public class EffectDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "Slash01(Clone)" || gameObject.name == "Slash02(Clone)")
        {
            transform.localPosition = new Vector3(0, 1.5f, 0);
            transform.localRotation = Quaternion.Euler(-15, 0, 0);
        }
        else if(gameObject.name == "Slash03(Clone)")
        {
            transform.localPosition = new Vector3(0, 1f, 0);
            transform.localRotation = Quaternion.Euler(-45, 0, 90);

        }
        Invoke("DeathEffect", 1.3f);
    }

    void DeathEffect()
    {
        Destroy(this.gameObject);
    }
}
