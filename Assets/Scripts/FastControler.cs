using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastControler : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public PlayerControler playerControler;
    [SerializeField] private GameObject player;
    [SerializeField] private AudioClip DeathSound;
    // Start is called before the first frame update
    void Start()
    {
        playerControler= GameObject.FindObjectOfType<PlayerControler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag==("Bullet"))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            ChangeSprite();
            AudioSource.PlayClipAtPoint(DeathSound, transform.position);
            Destroy(gameObject, 1);

        }
        if(collision.gameObject.tag==("Player"))
        {
            playerControler.LoseLife();
            
            Destroy(gameObject);
        }
        if(collision.gameObject.tag=="Background")
        {
            playerControler.LoseLife();
            Destroy(gameObject);
        }
    }
    void ChangeSprite()
    {
        playerControler.ScoreUP();
        gameObject.GetComponent<Animator>().enabled = false;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = newSprite;
        
    }
}
