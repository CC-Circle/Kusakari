using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAfterGrassField : MonoBehaviour
{
    public Transform blockParent;
    public GameObject blockPrefab_AfterGrass;

    public const int MAP_WIDTH = 500;
    public const int MAP_HEIGHT = 250;

    void Start()
    {
        Vector3 defaultPos = new Vector3(0.0f, 13.5f, 0.0f);
        defaultPos.x = -(MAP_WIDTH / 2);
        defaultPos.z = -(MAP_HEIGHT / 2);


        // ここがワールドのブロックのパターンを生成するところ
        for (int i = 0; i < MAP_WIDTH; i += 40)
        {
            for (int j = 0; j < MAP_HEIGHT; j += 40)
            {
                Vector3 pos = defaultPos;
                pos.x += i;
                pos.z += j;

                GameObject obj;
                obj = Instantiate(blockPrefab_AfterGrass, blockParent);
                obj.transform.position = pos;
            }
        }
    }
}
