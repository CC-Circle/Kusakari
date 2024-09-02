using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Gauge : MonoBehaviour
{
    public Slider gauge;
    GrassCounter grassCounter;

    // Start is called before the first frame update
    void Start()
    {
        gauge = GetComponent<Slider>();
        gauge.value = 85;

    }

    // Update is called once per frame
    void Update()
    {
        gauge.value = GrassCounter.grassCount;

    }
}
