using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int ColObjects = 3;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < ColObjects; i++)
        {
            GameObject bullet = ObjectPooler.instance.SpawnTarget();
            if (bullet != null)
            {
                bullet.transform.position = new Vector3(Random.Range(0, 5), 0, Random.Range(0, 5));
                bullet.transform.rotation = transform.rotation;
                bullet.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
