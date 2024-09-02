using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGrass : MonoBehaviour
{
    private int isCollide = 0;
    public GameObject grass;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isCollide == 1)
        {
            Vector3 pos = transform.position;
            pos.y = 13.5f;
            Instantiate(grass, pos, Quaternion.Euler(270, 0, 0));
            isCollide = 0;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AfterGrass")
        {
            // Debug.Log("Playerが草に触れました");
            Destroy(other.gameObject);
            isCollide = 1;
        }
    }
}
