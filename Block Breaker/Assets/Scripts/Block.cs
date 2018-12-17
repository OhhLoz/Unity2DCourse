using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip destroySound;
    [SerializeField] GameObject blockParticles;

    [SerializeField] Sprite[] hitSprites;

    LevelScript level;

    [SerializeField] int currHits;

    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        if (tag == "Breakable")
        {
            level = FindObjectOfType<LevelScript>();
            level.blockAdded();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            currHits++;
            int maxHits = hitSprites.Length + 1;
            if (currHits >= maxHits)
            {
                level.blockDestroyed();
                FindObjectOfType<GameStatusScript>().updateScore();
                AudioSource.PlayClipAtPoint(destroySound, transform.position);//Camera.main.transform.position, 0.25f);
                triggerParticles();
                Destroy(gameObject);
            }
            else
            {
                ShowNextHitSprite();
            }
        }

    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = currHits - 1;
        if (hitSprites[spriteIndex] != null)
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        else
        {
            Debug.Log("Block sprite missing from array: " + gameObject.name);
        }
    }

    private void triggerParticles()
    {
        GameObject particles = Instantiate(blockParticles, transform.position, transform.rotation);
        Destroy(particles, 2f);
    }
}
