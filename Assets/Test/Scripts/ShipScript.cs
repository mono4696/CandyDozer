using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{
    public GameObject prefab;
    public float speed;
    Vector3 vec;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vec.x = Input.GetAxis("Horizontal");//横移動
        transform.Rotate(Input.GetAxis("Vertical"),0,0);//回転
        transform.Translate(vec*speed);
        if (Input.GetButtonDown("Jump"))
        {
            GameObject bullet = Instantiate(
                prefab,
                transform.position,
                transform.rotation * Quaternion.Euler(-90f, 0, 0)
                //Quaternion.LookRotation(Quaternion.Euler(-90f, 0, 0) * transform.forward)
            );
            //Debug.Break();
            Destroy(bullet, 1f);
        }
    }
}
