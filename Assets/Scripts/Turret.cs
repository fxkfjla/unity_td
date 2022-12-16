using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;

    [Header("Attributes")]
    public float range = 2f;
    public float fireRate = 1f;
    private float fireCountDown = 0f;

    [Header("Unity Setup")]
    public string enemyTag = "Enemy";

    public Transform partToRotate;
    public float turnSpeed = 10f;
   
    public GameObject bulletPrefab;
    public Transform firePoint;

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

    void Shoot()
    {
        // taking reference to bullet object
        GameObject bulletObj = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        // referencing the bullet script
        Bullet bullet = bulletObj.GetComponent<Bullet>();

        if(bullet != null)
            bullet.setTarget(target);
    }

    void Update()
    {
        // UpdateTargetNearest();
        UpdateTargetFirst();

        if(target == null)
            return;

        // dodac komentarze
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if(fireCountDown <= 0f)
        {
            Shoot();
            fireCountDown = 1f / fireRate;
        }

        fireCountDown -= Time.deltaTime;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}