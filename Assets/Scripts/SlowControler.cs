using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowControler : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public PlayerControler playerControler;
    [SerializeField] private GameObject player;
    private int hits = 5;
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioClip DeathSound;
    // Start is called before the first frame update
    void Start()
    {
        playerControler = GameObject.FindObjectOfType<PlayerControler>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Bullet"))
        {
            if (hits > 1)
            {
                hits = hits - 1;
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-0.5f, 0);
                AudioSource.PlayClipAtPoint(hitSound, transform.position);

            }
            else
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                ChangeSprite();
                AudioSource.PlayClipAtPoint(DeathSound, transform.position);
                Destroy(gameObject, 1);
            }

        }
        if (collision.gameObject.tag == ("Player"))
        {
            playerControler.LoseLife();
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Background")
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
