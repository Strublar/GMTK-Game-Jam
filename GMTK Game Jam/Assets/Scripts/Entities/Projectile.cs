using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Entity
{
    [SerializeField] private float lifeTime;
    [SerializeField] List<Sprite> spritesGrey;
    [SerializeField] List<Sprite> spritesColor;
    [SerializeField] SpriteRenderer spriteRenderer;

    [SerializeField] private GameObject throwHitSounds;

    private bool hasImpact = false;
    private float currentLifeTime;
    public Vector3 direction;

    private void Start()
    {
        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Level2")
        {
            int index = Random.Range(0, spritesGrey.Count);
            spriteRenderer.sprite = spritesGrey[index];
        }
        else
        {
            int index = Random.Range(0, spritesColor.Count);
            spriteRenderer.sprite = spritesColor[index];
        }
        
    }

    public void Update()
    {
        if(hasImpact) currentLifeTime += Time.deltaTime;
        if (currentLifeTime >= lifeTime)
            Destroy(this.gameObject);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {

        hasImpact = true;
        Debug.Log("Hit with " + other.name);
        //Destroy(this.gameObject);
        PlaySound(throwHitSounds);
    }

    public void Throw(Vector3 direction, float currentForce)
    {
        this.GetComponent<Rigidbody2D>().AddForce(direction * currentForce);
    }

    public void PlaySound(GameObject sound)
    {
        AudioSource[] sources = sound.GetComponents<AudioSource>();
        sources[Random.Range(0, sources.Length - 1)].Play();
    }
}
