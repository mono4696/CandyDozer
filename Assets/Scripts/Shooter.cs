using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    const int SphereCandyFrequency = 3;
    const int MaxShotPower = 5;
    const int RecoverySeconds = 3;//ショットパワーの回復時間定数

    int sampleCandyCount;
    int shotPower = MaxShotPower;
    AudioSource shotSound;

    public GameObject[] candyPrefabs;
    public GameObject[] candySquarePrefabs;
    public CandyHolder candyHolder;
    public float shotSpeed;
    public float shotTorque;
    public float baseWidth;

    // Start is called before the first frame update
    void Start()
    {
        shotSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shot();//入力の検知(Fire1..マウスクリックや画面タップに反応する)
        }

    }

    //キャンディのプレファブからランダムに１つ選ぶ
    GameObject SampleCandy()
    {
        GameObject prefab = null;

        //特定回数に一回丸いキャンディを選択する
        if(sampleCandyCount % SphereCandyFrequency == 0)
        {
            int index = Random.Range(0,candyPrefabs.Length);
            prefab = candyPrefabs[index];
        }
        else
        {
            int index = Random.Range(0,candySquarePrefabs.Length);
            prefab = candySquarePrefabs[index];
        }

        sampleCandyCount++;
        return prefab;
    }

    //発車位置の計算
    Vector3 GetInstantiatePosition()
    {
        //画面のサイズとInputの割合からキャンディ生成のポジションを計算
        float x = baseWidth *
            (Input.mousePosition.x / Screen.width) - (baseWidth / 2);
        return transform.position + new Vector3(x,0,0);
    }

    public void Shot()
    {
        // キャンディを生成できる条件外ならばShotしない
        if (candyHolder.GetCandyAmount() <= 0)
        {
            return;
        }
        //ショットパワーのチェック
        if (shotPower <= 0)
        {
            return;
        }

        //プレファブからCandyオブジェクトを作成(Instantiate(何を,どこに,どの向きで)登場させるか)
        GameObject candy = Instantiate(
            SampleCandy(),//何を
            GetInstantiatePosition(),//どこに
            Quaternion.identity//どの向き(Quaternion...回転表現、identity...なし)
            );

        //生成したCandyオブジェクトの親をCandyHolderに設定する
        candy.transform.parent = candyHolder.transform;

        //CandyオブジェクトのRigidbodyを取得し力と回転を加える
        Rigidbody candyRigidbody = candy.GetComponent<Rigidbody>();
        candyRigidbody.AddForce(transform.forward*shotSpeed);//forward...z軸のプラス方向を取得
        candyRigidbody.AddTorque(new Vector3(0,shotTorque,0));//AddTorque...回転する力を加える

        //Candyのストックを消費
        candyHolder.ConsumeCandy();
        //ShotPowerを消費
        ConsumePower();

        //サウンドを再生
        shotSound.Play();

    }

    public int GetShotPower()
    {
        return shotPower;
    }

    //ショットパワーの消費処理
    void ConsumePower()
    {
        //ShotPowerを消費すると同時に回復のカウントをスタート
        shotPower--;
        StartCoroutine(RecoverPower());
    }

    //ショットパワーの回復コルーチン
    IEnumerator RecoverPower()
    {
        //一定秒数待った後にshotPowerを回復
        yield return new WaitForSeconds(RecoverySeconds);//フィールドで3秒に設定されている
        shotPower++;
    }
}
