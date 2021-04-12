using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] float speed = 5.0f;
    Rigidbody rb;
    float x, z;

    [SerializeField] GameObject CameraObject;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        //移動
        if (x == 0 && z == 0)
        {
            rb.velocity = Vector3.zero;
            Debug.Log("ss");
        }

        rb.AddForce(transform.forward * 10);

        //if (rb.velocity.magnitude < speed)
        //{
        //rb.AddForce(CameraObject.transform.forward * x + CameraObject.transform.right * -z);
        //}
    }

    void LateUpdate()
    {
        //方向転換
        gameObject.transform.eulerAngles = new Vector3(0, CameraObject.transform.eulerAngles.y, 0);

    }
}
