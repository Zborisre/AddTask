using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
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
}
