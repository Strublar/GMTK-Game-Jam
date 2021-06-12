using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Entity
{
    [SerializeField] private float lifeTime;
    [SerializeField] List<Sprite> sprites;
    [SerializeField] SpriteRenderer spriteRenderer;

    [SerializeField] private GameObject throwHitSounds;

    private bool hasImpact = false;
    private float currentLifeTime;
    public Vector3 direction;

    private void Start()
    {
        int index = Random.Range(0, sprites.Count);
        spriteRenderer.sprite = sprites[index];
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
