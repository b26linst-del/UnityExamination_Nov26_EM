using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    [SerializeField] private List<Sprite> idleSprites = new List<Sprite>();
    [SerializeField] private List<Sprite> talkSprites = new List<Sprite>();
    [SerializeField] private SpriteRenderer activeSpriteRenderer;

    [SerializeField] private GameObject pratBubbla;
     
    [SerializeField] private BoxCollider2D collider;
    
    [SerializeField] float _timer;
    [SerializeField] int _activeSpriteNum = 0;

    [SerializeField] private bool isTalking = false;
    
    [SerializeField] private float animationCooldown;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        
        if(_timer >= animationCooldown)
        {
            _activeSpriteNum++;
            if (_activeSpriteNum >= idleSprites.Count)
            {
                _activeSpriteNum = 0;
            }
            _timer = 0;
            
        }

        
        if (isTalking)
        {
            activeSpriteRenderer.sprite = talkSprites[_activeSpriteNum];
        }
        else
        {
            activeSpriteRenderer.sprite = idleSprites[_activeSpriteNum];
        }
        
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            pratBubbla.SetActive(true);
            pratBubbla.GetComponent<TMP_Text>().text = "hämta 1 mynt, pysen!";
            
            isTalking = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            pratBubbla.SetActive(false);
            //pratBubbla.GetComponent<TMP_Text>().text = "hämta 1 mynt, pysen!";
            isTalking = false;
        }
    }
}
