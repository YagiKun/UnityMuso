using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*スコア表示*/

public class ScoreBar : MonoBehaviour
{
    [SerializeField] Image ScoreImg;
    float scoreMax = 15000f;      //ランクSのスコア

    [SerializeField] Text t;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t.text = ""+ GameControler.Score;

        ScoreImg.fillAmount = GameControler.Score / scoreMax;
    }
}
