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

    GameObject closest;
    GameObject targetobj;

    public GameObject[] Active;
    private int cooldown = 0;

    // Назначение навигационного агента, и передача полученной скорости
    void Start()
    {
        NavAgent = GetComponent<NavMeshAgent>();
        NavAgent.speed = Speed + Random.Range(0.5f, 1.5f);

    }

    // Получение местоположения ближайщего объекта
    GameObject ClosetObject()
    {
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        foreach (GameObject go in ObjectPooler.poolObjectsTarget)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance && go.active)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    // Направление к ближайщему объекту и нанесение урона если дистанция оставноки меньше или равно позиции
    void Update()
    {
        targetobj = ClosetObject();
        float Mesto = Vector3.Distance(transform.position, targetobj.transform.position);

        NavAgent.SetDestination(targetobj.transform.position);
        if (Mesto <= NavAgent.stoppingDistance && cooldown == 0)
        {
            ClosetObject().GetComponent<DamagableObject>().Attack(Damage);
            cooldown = 2;
            StartCoroutine(DamageCooldown());
        }
    }

    // Корутина обновления ударов
    IEnumerator DamageCooldown()
    {
        yield return new WaitForSeconds(cooldown);

        cooldown = 0;
        StopCoroutine(DamageCooldown());
    }
}
