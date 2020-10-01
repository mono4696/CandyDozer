using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineScripts : MonoBehaviour
{
    Vector3 rot;
    bool isRot;//回っているかいないか

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") && rot.magnitude==0)
        {
            StartCoroutine(Rot());
        }
        if(rot.magnitude > 0)
        {
            transform.Rotate(rot);
        }
    }

    IEnumerator Rot()
    {
        rot.y = 1f;
        yield return new WaitForSeconds(2f);
        rot.y = 0;
        rot.x = 1f;
        yield return new WaitForSeconds(2f);
        rot.x = 0;
        rot.z = 1f;
        yield return new WaitForSeconds(3f);
        rot.z = 0;
    }
}
