using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int ColOfBots = 3;
    private float cooldown = 0.1f;
    [SerializeField]private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCooldown());
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown == 0)
        {
            cooldown = 3;
            for (int i = 0; i < 3; i++)
            {
                GameObject bullet = ObjectPooler.instance.SpawnTarget();
                if (bullet != null)
                {
                    bullet.transform.position = new Vector3(Random.Range(-23, 24), 0, Random.Range(-23, 24));
                    bullet.transform.rotation = transform.rotation;
                    bullet.SetActive(true);
                }
            }
            for (int i = 0; i < ColOfBots; i++)
            {
                GameObject bot = ObjectPooler.instance.SpawnBot();
                if (bot != null)
                {
                    bot.transform.position = new Vector3(Random.Range(-23, 24), 0, Random.Range(-23, 24));
                    bot.transform.rotation = transform.rotation;
                    bot.SetActive(true);
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                GameObject bot = ObjectPooler.instance.SpawnBot();
                if (bot != null)
                {
                    bot.transform.position = new Vector3(raycastHit.point.x, 0, raycastHit.point.z);
                    bot.transform.rotation = transform.rotation;
                    bot.SetActive(true);
                }
                Debug.Log("X " + raycastHit.point.x + " Z " + raycastHit.point.z + " Pos " + raycastHit.point);
            }
        }
    }

    IEnumerator SpawnCooldown()
    {
        yield return new WaitForSeconds(cooldown);

        cooldown = 0;
        StopCoroutine(SpawnCooldown());
    }
}
