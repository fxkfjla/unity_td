using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;

    public float range = 2f;
    public string enemyTag = "Enemy";

    public Transform partToRotate;
    public float turnSpeed = 10f;

    void UpdateTargetNearest()
    {
        if(target == null)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

            float distanceToTarget = Mathf.Infinity;

            foreach(GameObject enemy in enemies)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

                if (distanceToEnemy < distanceToTarget && distanceToEnemy <= range)
                {
                    distanceToTarget = distanceToEnemy;
                    target = enemy.transform;
                }
            }
        }
        else
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);

            if(distanceToTarget >= range)
                target = null;
        }
    } 

    void UpdateTargetFirst()
    {
        if(target == null)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

            foreach(GameObject enemy in enemies)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

                if(distanceToEnemy < range)
                {
                    target = enemy.transform;
                    break;
                }
            }
        }
        else
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);

            if(distanceToTarget >= range)
                target = null;
        } 
    }

    void Update()
    {
        // UpdateTargetNearest();
        UpdateTargetFirst();

        if(target != null)
        {
            // dodac komentarze
            Vector3 dir = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
            partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}