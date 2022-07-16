using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : MonoBehaviour
{
    public int Health;
    public int Speed;
    public int Damage;

    NavMeshAgent NavAgent;

    GameObject[] DamagableObjects;
    GameObject closest;
    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        DamagableObjects = GameObject.FindGameObjectsWithTag("Damagable");
        NavAgent = GetComponent<NavMeshAgent>();
        NavAgent.speed = Speed + Random.Range(0.5f, 1.5f);

    }

    GameObject ClosetObject()
    {
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in DamagableObjects)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    // Update is called once per frame
    void Update()
    {
        target = ClosetObject().transform;
        float Mesto = Vector3.Distance(transform.position, target.position);

        NavAgent.SetDestination(target.position);
        if (Mesto <= NavAgent.stoppingDistance)
        {
            ClosetObject().GetComponent<DamagableObject>().Attack(Damage);
        }
    }
}
