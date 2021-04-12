using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*カメラのマウス移動*/

public class Camera : MonoBehaviour
{
    float mouseX = 0;
    [SerializeField] float speed = 5;   //カメラの移動スピード

    [SerializeField] GameObject Player;     //プレイヤー位置

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        mouseX += Input.GetAxis("Mouse X") * speed;
        gameObject.transform.eulerAngles = new Vector3(0, mouseX, 0);

    }

    // Update is called once per frame
    void LateUpdate()
    {
        gameObject.transform.position = Player.transform.position;
    }
}
