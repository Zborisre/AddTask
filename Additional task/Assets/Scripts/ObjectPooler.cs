using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

    public Dictionary<string, Queue<GameObject>> poolDictionary;
    public static ObjectPooler instance;

    public static List<GameObject> poolObjectsTarget = new List<GameObject>();
    private List<GameObject> poolObjectsBot = new List<GameObject>();
    public int ColOfPool = 20;

    [SerializeField] private GameObject TargedPre;
    [SerializeField] private GameObject BotPre;

    public int ColObjects = 3;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {

        for (int i = 0; i < ColOfPool - 16; i++)
        {
            GameObject obj = Instantiate(TargedPre);
            obj.SetActive(false);
            poolObjectsTarget.Add(obj);
        }

        for (int i = 0; i < ColOfPool; i++)
        {
            GameObject obj = Instantiate(BotPre);
            obj.SetActive(false);
            poolObjectsBot.Add(obj);
        }



        for (int i = 0; i < ColObjects; i++)
        {
            GameObject bullet = ObjectPooler.instance.SpawnTarget();
            if (bullet != null)
            {
                bullet.transform.position = new Vector3(Random.Range(-23, 24), 0, Random.Range(-23, 24));
                bullet.transform.rotation = transform.rotation;
                bullet.SetActive(true);
            }
        }
    }

    public GameObject SpawnTarget()
    {
        for (int i = 0; i < poolObjectsTarget.Count; i++)
        {
            if (!poolObjectsTarget[i].activeInHierarchy)
            {
                return poolObjectsTarget[i];
            }

        }
        return null;
    }

    public GameObject SpawnBot()
    {
        for (int i = 0; i < poolObjectsBot.Count; i++)
        {
            if (!poolObjectsBot[i].activeInHierarchy)
            {
                return poolObjectsBot[i];
            }

        }
        return null;
    }

}