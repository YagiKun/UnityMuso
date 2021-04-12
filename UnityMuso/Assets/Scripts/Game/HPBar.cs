using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    Image HPImage;

    // Start is called before the first frame update
    void Start()
    {
        HPImage = GameObject.Find("HP_Gauge").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        HPImage.fillAmount = (float)GameControler.HP / 100.0f;
    }
}
