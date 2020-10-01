using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyHolder : MonoBehaviour
{
    const int DefaultCandyAmount = 30;
    const int RecoverySeconds = 10;

    //現在のキャンディのストック数
    int candy = DefaultCandyAmount;
    //ストック回復までの残り秒数
    int counter;

    public void ConsumeCandy()
    {
        if (candy > 0) candy--;
    }

    public int GetCandyAmount()
    {
        return candy;
    }

    public void AddCandy(int amount)
    {
        candy += amount;
    }

    public int GetCandy()
    {
        return candy;
    }

    public int GetCounter()
    {
        return counter;
    }

    // Update is called once per frame
    void Update()
    {
        //キャンディのストックがデフォルトより少なく、
        //回復カウントをしていない時にカウントをスタートさせる
        if(candy<DefaultCandyAmount && counter<=0)
        {
            StartCoroutine(RecoverCandy());
        }
    }

    IEnumerator RecoverCandy()//コルーチンを作る際は、戻り値は必ずIEnumerator!!
    {
        counter = RecoverySeconds;

        //1秒ずつカウントを進める
        while(counter>0)
        {
            yield return new WaitForSeconds(1.0f);//一秒待ってcounter--をする
            counter--;
        }

        candy++;

    }

}
