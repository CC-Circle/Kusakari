using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float moveSpeed = 0.001f;
    private Vector3 lastMousePosition;

    void Start()
    {
        // 初期化時にマウスの位置を保存
        lastMousePosition = Input.mousePosition;
    }

    void Update()
    {
        if (ReadyToStart.flag)
        {
            float rotationSpeed = 10f; // 回転速度

            // 現在の位置を取得
            Vector3 currentPosition = transform.position;

            // 十字キーでの進行方向変更（回転）
            float h = Input.GetAxis("Horizontal"); // 左右キーの取得
            transform.Rotate(0, rotationSpeed * h * 0.1f, 0);

            // Debug.Log(h);

            // マウスのX方向の移動距離を計算
            Vector3 currentMousePosition = Input.mousePosition;
            float mouseDeltaX = currentMousePosition.x - lastMousePosition.x;

            // マウスの移動に応じてプレイヤーを回転
            transform.Rotate(0, mouseDeltaX * rotationSpeed * 0.001f, 0);

            // マウスの移動距離に応じて前進
            if (Mathf.Abs(mouseDeltaX) > 0)
            {
                transform.position += transform.forward * Mathf.Abs(mouseDeltaX) * moveSpeed * 10;
                // 高さは固定
                transform.position = new Vector3(transform.position.x, 30, transform.position.z);
            }

            // 現在のマウス位置を次のフレーム用に保存
            lastMousePosition = currentMousePosition;
        }
    }
}
