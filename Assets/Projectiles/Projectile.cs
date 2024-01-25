using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public LayerMask hitLayerMask;

    bool moving = false;
    Vector3 dir;
    GameObject caster;

    public void Shoot(Vector2 targetPos, GameObject caster)
    {
        this.caster = caster;

        Vector3 mousePos3D = new Vector3(targetPos.x, targetPos.y, 0);
        Vector3 direction = mousePos3D - transform.position;
        direction.z = 0;
        dir = direction;

        moving = true;
    }

    private void Update()
    {
        if (!moving)
            return;

        transform.position += dir * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hitLayerMask != (hitLayerMask | (1 << other.gameObject.layer)))
            return;

        if (other.gameObject != caster)
        {
            IDamageable hitDamageable = other.GetComponent<IDamageable>();

            if (hitDamageable != null)
            {
                hitDamageable.Hit();
            }

            Debug.Log("Hit " + other.name);
            Destroy(this.gameObject);
        }
    }
}