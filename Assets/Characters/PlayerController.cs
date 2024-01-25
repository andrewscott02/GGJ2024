using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageable
{
    public Vector2 moveSpeed = new Vector2(1, 1);
    public Object projectile;

    public float shootCooldown = 0.8f;
    float cooldownT = 0;

    // Update is called once per frame
    void Update()
    {
        cooldownT += Time.deltaTime;

        if (Input.GetKey(KeyCode.W))
        {
            Move(new Vector3(0, moveSpeed.y * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.S))
        {
            Move(new Vector3(0, -moveSpeed.y * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            Move(new Vector3(-moveSpeed.x * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            Move(new Vector3(moveSpeed.x * Time.deltaTime, 0, 0));
        }

        if (Input.GetMouseButton(0) && cooldownT >= shootCooldown)
        {
            Shoot(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }

    void Move(Vector3 move)
    {
        transform.position += move;
    }

    void Shoot(Vector2 mousePos)
    {
        cooldownT = 0;

        GameObject projectileGO = Instantiate(projectile, transform.position, new Quaternion(0, 0, 0, 0)) as GameObject;
        Projectile projectileScript = projectileGO.GetComponent<Projectile>();
        projectileScript.Shoot(mousePos, this.gameObject);
    }

    public void Hit()
    {
        ScoreManager.instance.RemoveLife();
    }
}

public interface IDamageable
{
    public void Hit();
}