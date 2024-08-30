using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetection : MonoBehaviour
{
    private string NowScene;
    private GameObject Grassbject = null;
    private GameObject MoleObject = null;
    public int ScoreFlag = 0;
    AudioSource audioSource;
    public AudioSource moleCollisionSound;
    public GameObject newPrefab;
    public int isMoguraDestory = 0;
    private GrassCounter counter;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        counter = FindObjectOfType<GrassCounter>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("grass"))
        {
            Grassbject = collision.gameObject;
        }

        if (collision.gameObject.CompareTag("Mole"))
        {
            MoleObject = collision.gameObject;
        }
    }

    void Update()
    {
        if (counter == null)
        {
            // Debug.Log("counter is null");
        }
        else
        {
            // Debug.Log("counter is not null");
            // Debug.Log(Time.deltaTime);
        }

        SerialReceive SerialReceive;
        GameObject M5Stack = GameObject.Find("M5stack_Evnet");
        SerialReceive = M5Stack.GetComponent<SerialReceive>();

        if (SerialReceive.Flag == 3)
        {
            Debug.Log("up");
        }

        NowScene = SceneManager.GetActiveScene().name;

        if (NowScene == "start")
        {
            // startシーンの処理（未実装）
        }
        else if (NowScene == "main")
        {
            if (ReadyToStart.flag)
            {
                if (Grassbject != null)
                {
                    Vector3 position = Grassbject.transform.position;
                    position.y = 0;
                    Destroy(Grassbject);
                    audioSource.PlayOneShot(audioSource.clip);
                    ScoreFlag = 1;

                    position.x -= 5;
                    position.z -= 5;
                    GameObject newObject = Instantiate(newPrefab, position, Quaternion.Euler(90, 0, 0));
                    newObject.tag = "AfterGrass";

                    // if (counter != null)
                    // {
                    counter.DecrementCount();
                    // }

                }

                if (MoleObject != null)
                {
                    Destroy(MoleObject);
                    audioSource.PlayOneShot(moleCollisionSound.clip);
                    ScoreFlag = 2;
                    isMoguraDestory = 1;
                }
            }
        }
        else if (NowScene == "end")
        {
            // ゲーム終了時の処理（未実装）
        }
    }
}
