using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward);//Space.World...世界(global)に対してのz軸、Vector3.forward...オブジェクト(local)に対してのz軸
    }
}
