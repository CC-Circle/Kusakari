using UnityEngine;
using System.Collections;

public class AutoDestroyAndSpawn : MonoBehaviour
{
    public float lifetime = 10.0f; // オブジェクトが生成されてから消滅するまでの時間
    public GameObject spawnPrefab; // 破壊後に生成されるオブジェクトのプレハブ
    private Vector3 initialPosition;
    private GrassCounter counter;

    void Start()
    {
        // カウント用のスクリプトを取得
        counter = FindObjectOfType<GrassCounter>();
    }

    void Update()
    {
        // コルーチンを開始して時間経過後にオブジェクトを破壊
        StartCoroutine(DestroyAfterLifetime());
    }

    IEnumerator DestroyAfterLifetime()
    {
        // 初期位置を記録
        initialPosition = transform.position;

        // 指定された時間だけ待つ
        yield return new WaitForSeconds(lifetime);
        // オブジェクトを破壊
        if (counter != null)
        {
            counter.IncrementCount();
        }
        Destroy(gameObject);
        // 新しいオブジェクトを初期位置に生成
        initialPosition.y = 13.5f; // オブジェクトが地面に埋まらないように少し浮かせる    
        GameObject newObject = Instantiate(spawnPrefab, initialPosition, Quaternion.Euler(270, 0, 0));
        // 新しいオブジェクトのカウントを増やす
        if (newObject.TryGetComponent(out AutoDestroyAndSpawn newObjectScript))
        {
            newObjectScript.counter = counter;
        }
    }
}
