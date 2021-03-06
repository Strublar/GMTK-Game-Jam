using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Entity, IAttackable
{
    public static Player p;
    public bool debug = false;
    [SerializeField] private int maxHp;
    [SerializeField] private float hp;
    [SerializeField] float moveSpeedSplit;
    private float moveSpeedCombined;

    private bool isCombined = true;
    public Soul soul;
    private Collider2D soulCollider;
    private bool isSoulInRange = true;
    private SpriteRenderer spriteRenderer;
    public float timerBeforeCombineAgain = 0f;
    

    [SerializeField] private float immunityFrame;

    [SerializeField] private GameObject model;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject projectilePrefab, projectileContainer;

    [SerializeField] private float bumpCooldown;

    [SerializeField] private int bumpForce;

    //variable related to the heal and damage from the soul
    [SerializeField] float healPerSecond;
    [SerializeField] float baseDmgPerSecond;
    [SerializeField] private ChargingBar chargingBar;

    private float lastDamageFrame;
    private float currentCooldown;
    private bool isCharging;
    [SerializeField] public int Level;

    #region Sounds containers
    [SerializeField] private GameObject aspirationSounds,separationSounds,throwSounds,
        hitGirlSounds,hitBoySounds,deathBoySounds,deathGirlSounds;
    #endregion
    #region VFX

    [SerializeField] private ParticleSystem combineVFX, splitVFX;

    #endregion

    public float Hp { get => hp; set => hp = Mathf.Clamp(value,0,maxHp); }

    public float ImmunityFrame { get => immunityFrame; set => immunityFrame = value; }
    public float LastDamageFrame { get => lastDamageFrame; set => lastDamageFrame = value; }
    public bool IsCombined { get => isCombined; set => isCombined = value; }
    public int MaxHp { get => maxHp; set => maxHp = value; }
    public bool IsCharging { get => isCharging; set => isCharging = value; }

    public void Awake()
    {
        p = this;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        soulCollider = soul.GetComponent<Collider2D>();
        if (GameManager.Instance != null) spriteRenderer.sprite = GameManager.Instance.GetSprite();
    }
    public void Start()
    {
        lastDamageFrame = immunityFrame;
        moveSpeedCombined = moveSpeed;
        
    }

    void Update()
    {
        #region Timer combine
        if (timerBeforeCombineAgain > 0)
        {
            timerBeforeCombineAgain -= Time.deltaTime;
        }

        


        if (isSoulInRange == false && debug == true)
        {
            spriteRenderer.color = Color.green;
        }

        if (isSoulInRange == true && debug == true)
        {
            spriteRenderer.color = Color.white;
        }
        #endregion

        #region Damage immunity
        rb.velocity *= 0.9f;
        lastDamageFrame += Time.deltaTime;
        model.SetActive(true);
        int flashPerSecond = 3;
        if (lastDamageFrame < immunityFrame)
        {
            if ((lastDamageFrame * flashPerSecond - Mathf.Floor(lastDamageFrame * flashPerSecond)) < 0.5f)
            {
                model.SetActive(false);
            }
            else
            {
                model.SetActive(true);
            }
        }
        #endregion

        #region Charge Throw

        if(Level>=2)
        {
            currentCooldown -= Time.deltaTime;

            chargingBar.UpdateChargingBar(currentCooldown,bumpCooldown);
        }
        

        #endregion

        #region health change from soul

        if (isCombined)
        {
            hp += healPerSecond / 60f * Time.deltaTime;
            hp = Mathf.Min(hp, maxHp);
        }
        else
        {
            float distance = (transform.position - soul.transform.position).magnitude;
            hp -= baseDmgPerSecond / 60f * Time.deltaTime * distance;
            if (hp <= 0)
                Die();
        }

        #endregion
    }
    public override void Move(Vector3 direction, float duration)
    {
        base.Move(direction, duration);
        soul.transform.position += moveSpeed * direction * duration;

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Soul" && timerBeforeCombineAgain <= 0)
        {
            //isSoulInRange = true;
            Combine();
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.name == "Soul")
        {
            isSoulInRange = false;
        }
    }



    public void OnAttacked(OnAttackedArgs args)
    {
        if (lastDamageFrame > immunityFrame)
        {
            Debug.Log("OUCH i got hit by " + args.attacker.name);
            lastDamageFrame = 0;

            //Damages
            hp -= args.damage;
            if (GameManager.Instance.selectedCharacter == 0)
            {
                SoundManager.PlaySound(hitGirlSounds);
            }
            else
            {
                SoundManager.PlaySound(hitBoySounds);
            }

            //Force
            int forceStrength = 1500;
            Vector3 force = transform.position - args.attacker.transform.position;
            force.Normalize();
            rb.AddForce(forceStrength * force);

            if(args.splitSoul)
            {
                Split();
            }

            if (hp <= 0)
                Die();
        }
    }
    public void StartCharging()
    {
        currentCooldown = 0;
        IsCharging = true;
    }

    public void Bump(Vector3 direction)
    {
        if (currentCooldown <= 0)
        {
            soul.Bump(bumpForce);
            currentCooldown = bumpCooldown;

        }

        
        IsCharging = false;

    }

    public void Split()
    {
        IsCombined = false;
        soul.gameObject.SetActive(true);
        moveSpeed = moveSpeedSplit;
        timerBeforeCombineAgain = 1f;
        SoundManager.PlaySound(separationSounds);
        splitVFX.Play();
    }

    public void Combine()
    {
        IsCombined = true;
        moveSpeed = moveSpeedCombined;
        soul.Combine();
        soul.gameObject.SetActive(false);
        SoundManager.PlaySound(aspirationSounds);
        combineVFX.Play();
    }

    public override void Die()
    {
        if(GameManager.Instance.selectedCharacter == 0)
        {
            SoundManager.PlaySound(deathGirlSounds);
        }
        else
        {
            SoundManager.PlaySound(deathBoySounds);
        }

        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    

}
