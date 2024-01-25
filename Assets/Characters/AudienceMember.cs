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
        appreciation = Random.Range(scoreRange.x, scoreRange.y);
        baseSkinColour = faceSprite.color;
        CheckAppreciation();
        SetCooldownTime();
    }

    public Object projectile;

    bool canShoot = false;
    public Vector2 shootCooldownLow = new Vector2(1.2f, 2f);
    public Vector2 shootCooldownMid = new Vector2(2f, 3f);
    Vector2 shootCooldown;
    public float currentCooldownTime;
    float cooldownT = 0;

    public Vector2Int scoreRange = new Vector2Int(5, 16);
    int m_appreciation;
    int appreciation
    {
        get
        {
            return m_appreciation;
        }

        set
        {
            m_appreciation = value;
            m_appreciation = m_appreciation < 0 ? 0 : m_appreciation;
        }
    }
    public int appreciationOnHit = 3;
    public float scoreTime = 1f;
    float scoreT = 0;
    public float appreciationLoss = 5f;
    float appreciationT;

    public SpriteRenderer faceSprite;
    Color baseSkinColour, flashColour;
    public Color highAppreciation, midAppreciation, lowAppreciation;
    public int highThreshold = 30, midThreshold = 15;
    float flashT;
    bool flashAdvancing = true;

    // Update is called once per frame
    void Update()
    {
        cooldownT += Time.deltaTime;

        if (cooldownT >= currentCooldownTime && canShoot)
        {
            Shoot();
        }

        scoreT += Time.deltaTime;

        if (scoreT >= scoreTime)
        {
            scoreT = 0;
            ScoreManager.instance.AddScore(appreciation);
        }

        appreciationT += Time.deltaTime;

        if (appreciationT >= appreciationLoss)
        {
            appreciationT = 0;
            appreciation--;

            CheckAppreciation();
        }

        faceSprite.color = LerpColour(baseSkinColour, flashColour, flashT);

        if (flashAdvancing)
        {
            flashT += Time.deltaTime;

            if (flashT >= 1)
            {
                flashAdvancing = false;
            }
        }
        else
        {
            flashT -= Time.deltaTime;

            if (flashT <= 0)
            {
                flashAdvancing = true;
            }
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
        appreciation += appreciationOnHit;
        CheckAppreciation();
    }

    void CheckAppreciation()
    {
        if (appreciation >= highThreshold)
        {
            canShoot = false;
            flashColour = highAppreciation;
        }
        else if (appreciation >= midThreshold)
        {
            canShoot = true;
            flashColour = midAppreciation;
            shootCooldown = shootCooldownMid;
        }
        else
        {
            canShoot = true;
            flashColour = lowAppreciation;
            shootCooldown = shootCooldownLow;
        }
    }

    Color LerpColour(Color a, Color b, float t)
    {
        Color returnColour = new Color();

        returnColour.r = Mathf.Lerp(a.r, b.r, t);
        returnColour.g = Mathf.Lerp(a.g, b.g, t);
        returnColour.b = Mathf.Lerp(a.b, b.b, t);
        returnColour.a = Mathf.Lerp(a.a, b.a, t);

        return returnColour;
    }
}