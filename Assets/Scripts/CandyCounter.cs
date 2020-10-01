using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CandyCounter : MonoBehaviour
{
    public CandyHolder candyHolder;
    Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //キャンディのストック数を表示
        text.text = "Candy：" + candyHolder.GetCandy();
        //回復カウントしている時だけ秒数を表示
        if (candyHolder.GetCounter() > 0)
        {
            text.text += "(" + candyHolder.GetCounter() + "s)";
        }
    }
}
