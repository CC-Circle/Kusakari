using UnityEngine;

public class GrassCounter : MonoBehaviour
{
    TimeCounter timeCounter; // TimeCounterスクリプトのインスタンス
    public static int grassCount = 170; // グローバルなカウント変数

    void Start()
    {
        timeCounter = FindObjectOfType<TimeCounter>(); // TimeCounterスクリプトのインスタンスを取得
    }
    void Update()
    {
        // 170
        if (timeCounter.CountTime <= 0)
        {
            // カウントをコンソールに表示
            const int MAX_GRASS_COUNT = 170; // 最大個数
            float grassPercentage = (float)grassCount / MAX_GRASS_COUNT * 100.0f;

            // 割合をコンソールに表示
            Debug.Log("フィールドに存在する割合: " + grassPercentage + "%");
            Debug.Log("Grassタグを持つオブジェクトの数: " + grassCount);
        }
    }
    public void IncrementCount()
    {
        grassCount++;
    }

    public void DecrementCount()
    {
        grassCount--;
    }
}
