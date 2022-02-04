//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class move : MonoBehaviour
//{
//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class move : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
            transform.position += Vector3.left * Time.deltaTime * 5;
        if (Input.GetKey(KeyCode.D))
            transform.position += Vector3.right * Time.deltaTime * 5;
        ;
        if (Input.GetKey(KeyCode.W))
            transform.position += Vector3.up * Time.deltaTime * 5;

        if (Input.GetKey(KeyCode.S))
            transform.position += Vector3.down * Time.deltaTime * 5;

    }

}