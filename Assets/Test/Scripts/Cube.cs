using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float amp;//振り幅
    public float speed;
    Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.localPosition;//localPosition...親要素に対してのオフセット、位置取得

    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(new Vector3(0,0,0.01f),Space.World);
        //transform.Rotate(0.1f, 0.1f, 0.1f);
        //transform.localScale = transform.localScale + new Vector3(0.01f,0,0);
        /*
        float x = Mathf.Sin(Time.time*speed);
        transform.position = startPosition+new Vector3(x, 0, 0);
        */

        float x=Mathf.Cos(Time.time*speed)*amp;
        float y=Mathf.Sin(Time.time*speed)*amp;
        float z=Time.time*speed;
        transform.position = startPosition + new Vector3(x,y,z);

    }
}
