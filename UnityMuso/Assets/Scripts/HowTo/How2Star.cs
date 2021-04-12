using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*★*/

public class How2Star : MonoBehaviour
{
    bool upf = false;
    float count = 0;

    [SerializeField] Text panel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (upf)
        {
            if(count < 1.0f)
            {
                count += Time.deltaTime;
            }
            else if(1<= count)
            {
                count = 1.0f;
            }
        }
        else
        {
            if (count > 0.0f)
            {
                count -= Time.deltaTime;
            }
            else if (0 >= count)
            {
                count = 0.0f;
            }
        }

        panel.color = Color.Lerp(new Color(0, 0, 0, 0), new Color(0, 0, 0, 1), 1 - Mathf.Pow(1 - count, 3));
    }

    public void UpStar()
    {
        upf = true;
    }

    public void ExitStar()
    {
        upf = false;
    }
}
