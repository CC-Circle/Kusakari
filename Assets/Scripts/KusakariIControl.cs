using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KusakariControl : MonoBehaviour
{
    public float moveSpeed = 70f;
    public SerialReceive serialReceive;
    private int leftRightCount = 0;
    private bool isSwinging = false; // 振り回し動作のフラグ
    private float swingDirection = 0; // 現在の振り回し方向
    private float swingAmount = 30f; // 振り回しの角度
    private float swingSpeed = 50f; // 振り回しの速度
    private float swingTime = 0; // 振り回しの経過時間
    public GameObject M5Stack;
    private Vector3 lastMousePosition;

    public int ChangeMain = 0;
    public int Changecount = 0;

    void Start()
    {
        // 初期化時にマウスの位置を保存
        lastMousePosition = Input.mousePosition;
    }

    void Update()
    {
        bool isRotating = false; // 視点操作が実行されているかどうかを判定するフラグ

        // Flagを入手するためのコード
        SerialHandler SerialHandler; //呼ぶスクリプトにあだなつける
        GameObject M5Stack = GameObject.Find("M5stack_Evnet"); //Playerっていうオブジェクトを探す
        SerialHandler = M5Stack.GetComponent<SerialHandler>(); //付いているスクリプトを取得

        // ジャイロを入手するためのコード
        SerialReceive SerialReceive; //呼ぶスクリプトにあだなつける
        SerialReceive = M5Stack.GetComponent<SerialReceive>(); //付いているスクリプトを取得

        float rotationSpeed = 10f; // 回転速度
        float moveAmount = 1f * Time.deltaTime;

        Debug.Log(isRotating);

        // // M5Stack
        if (SerialHandler.Settingsflag)
        {
            if (serialReceive.Flag == 1 || serialReceive.Flag == 2)
            {
                // 振り回し動作を開始する
                if (!isSwinging)
                {
                    isSwinging = true;
                    swingDirection = serialReceive.Flag == 1 ? -1 : 1; // 振り回しの方向を設定
                    swingTime = 0; // 経過時間のリセット
                }

                // 振り回し動作を実行する
                swingTime += Time.deltaTime * swingSpeed;
                float angle = Mathf.Sin(swingTime) * swingAmount; // 振り回しの角度を計算
                transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + angle * swingDirection, 0);

                // 振り回しが終了したらフラグをリセット
                if (swingTime > Mathf.PI * 2) // 振り回しが一周したら終了
                {
                    isSwinging = false;
                    swingTime = 0;
                    leftRightCount++;
                }
            }

            // 左右に一回ずつ振ったら前進
            if (leftRightCount >= 2)
            {
                leftRightCount = 0; // カウントをリセット
                Changecount++;
                Debug.Log(Changecount);
            }

            // ステージ変更のフラグ
            if (Changecount >= 10)
            {
                ChangeMain = 1;
            }

            //マウス
            else if (!SerialHandler.Settingsflag)
            {

                // Debug.Log(h);

                // マウスのX方向の移動距離を計算
                Vector3 currentMousePosition = Input.mousePosition;
                float mouseDeltaX = currentMousePosition.x - lastMousePosition.x;

                // マウスの移動に応じてプレイヤーを回転
                transform.Rotate(0, mouseDeltaX * rotationSpeed * 0.001f, 0);

                //マウスの移動量がいって位置を越えたらフラグを変更
                if (mouseDeltaX > 250 || mouseDeltaX < -250)
                {
                    ChangeMain = 1;
                }

                // 現在のマウス位置を次のフレーム用に保存
                lastMousePosition = currentMousePosition;
            }
        }
    }
}