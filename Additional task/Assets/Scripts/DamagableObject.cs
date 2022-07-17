using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagableObject : MonoBehaviour
{
    public int HealthNum = 10;
    private int Health;

    // Start is called before the first frame update
    void Start()
    {
        Health = HealthNum;
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            gameObject.SetActive(false);
            Health = HealthNum;
            GameObject bullet = ObjectPooler.instance.SpawnTarget();
            if (bullet != null)
            {
                bullet.transform.position = new Vector3(Random.Range(-23, 24), 0, Random.Range(-23, 24));
                bullet.transform.rotation = transform.rotation;
                bullet.SetActive(true);
            }
        }
    }

    public void Attack(int Damage)
    {
        Health = Health - Damage;
    }    
}
