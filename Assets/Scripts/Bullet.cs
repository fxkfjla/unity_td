using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 20f;
    public int damage = 50;

    public void setTarget(Transform target)
    {
        this.target = target;
    }

    void HitTarget()
    {
        Destroy(gameObject);
        Enemy enemy = target.GetComponent<Enemy>();

        if(enemy != null)
            enemy.TakeDamage(damage);
    }

    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distance = speed * Time.deltaTime;

        // if length of direction is less than distance to fly avoid overshoot
        if(direction.magnitude <= distance)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distance, Space.World);
    }
}
