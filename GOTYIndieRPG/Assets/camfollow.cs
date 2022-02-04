using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camfollow : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
                

    }

    // Update is called once per frame
    void Update()
    {
        //transform.position.x = target.position.x;
        //transform.position.y = target.position.y;
        transform.position = new Vector3( target.position.z, target.position.y,-19);
    }
}
