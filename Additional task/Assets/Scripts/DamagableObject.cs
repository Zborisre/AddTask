using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamagableObject : MonoBehaviour
{
    public int HealthNum = 10;
    private int Health;

    public Image HealthBar;
    private float fill;

    // Start is called before the first frame update
    void Start()
    {
        fill = 1f;
        Health = HealthNum;
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.fillAmount = fill;
        if (Health <= 0)
        {
            Death();
        }
    }

    public void Attack(int Damage)
    {
        Health = Health - Damage;
        fill = (float)Health / HealthNum;
    }

    private void Death()
    {
        fill = 1f;
        gameObject.SetActive(false);
        Health = HealthNum;
        GameObject bullet = ObjectPooler.instance.SpawnTarget();
        if (bullet != null)
        {
            bullet.transform.position = new Vector3(UnityEngine.Random.Range(-23, 24), 0, UnityEngine.Random.Range(-23, 24));
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
        }
    }

}
