using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketScript : MonoBehaviour
{
    Vector3 vec;

    // Start is called before the first frame update
    void Start()
    {
        vec = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        vec.x += Input.GetAxis("Horizontal");
        if (vec.x > 14f)
        {
            vec.x = 14f;
        }
        if (vec.x < -14f)
        {
            vec.x = -14f;
        }
        transform.position = vec;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Object")
        {
            Destroy(other.gameObject);
        }
    }
}
