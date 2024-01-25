using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceMember : MonoBehaviour, IDamageable
{
    PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        SetCooldownTime();
    }

    public Object projectile;

    public Vector2 shootCooldown = new Vector2(1.2f, 2f);
    public float currentCooldownTime;
    float cooldownT = 0;

    public int scoreOnHit = 10;

    // Update is called once per frame
    void Update()
    {
        cooldownT += Time.deltaTime;

        if (cooldownT >= currentCooldownTime)
        {
            Shoot();
        }
    }

    void SetCooldownTime()
    {
        currentCooldownTime = Random.Range(shootCooldown.x, shootCooldown.y);
    }

    void Shoot()
    {
        cooldownT = 0;
        SetCooldownTime();

        GameObject projectileGO = Instantiate(projectile, transform.position, new Quaternion(0, 0, 0, 0)) as GameObject;
        Projectile projectileScript = projectileGO.GetComponent<Projectile>();
        projectileScript.Shoot(player.transform.position, this.gameObject);
    }

    public void Hit()
    {
        ScoreManager.instance.AddScore(scoreOnHit);
    }
}