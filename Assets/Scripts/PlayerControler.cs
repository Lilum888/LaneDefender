using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] private PlayerInput inputs;
    private InputAction move;
    private InputAction shoot;
    private InputAction restart;
    

    private bool isPlayerMoving;
    private float moveDirection;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject Bullet;
    private bool isPlayerShooting;
    public float fireRate = 0.0F;
    private float nextFire = 0.0F;
    public BulletControler bulletControler;

    [SerializeField] GameObject Explosion;
    [SerializeField] GameObject Spawnpoint;

    private int score = 0;
    [SerializeField] private TMP_Text scoretext;

    private int lives = 3;
    [SerializeField] private TMP_Text livestext;

    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private TMP_Text endScoreText;
    [SerializeField] private TMP_Text highScoreText;
    public EnemyControler enemyControler;

    [SerializeField] private AudioClip shootSound;
    [SerializeField] private AudioClip liveSound;
    // Start is called before the first frame update
    void Start()
    {
        enemyControler = GameObject.FindObjectOfType<EnemyControler>();

        gameOverText.gameObject.SetActive(false);
        endScoreText.gameObject.SetActive(false);
        highScoreText.gameObject.SetActive(false);
        //setting up inputs
        inputs.currentActionMap.Enable();
        move = inputs.currentActionMap.FindAction("Move");
        shoot = inputs.currentActionMap.FindAction("Shoot");
        restart = inputs.currentActionMap.FindAction("Restart");
        

        move.started += Move_started;
        shoot.started += Shoot_started;
        restart.started += Restart_started;
        move.canceled += Move_canceled;
        shoot.canceled += Shoot_canceled;

 
    }

    private void Shoot_canceled(InputAction.CallbackContext obj)
    {
        isPlayerShooting = false;
    }

    private void Move_canceled(InputAction.CallbackContext obj)
    {
        isPlayerMoving = false;
    }

    private void Restart_started(InputAction.CallbackContext obj)
    {
        SceneManager.LoadScene(0);
    }

    private void Shoot_started(InputAction.CallbackContext obj)
    {
      
        isPlayerShooting = true;
    }

    private void Move_started(InputAction.CallbackContext obj)
    {
        isPlayerMoving = true;
    }

    // Update is called once per frame
    void Update()
    {
        //finds players direction movement
        if(isPlayerMoving)
        {
            moveDirection = move.ReadValue<float>();
        }
    }
    private void FixedUpdate()
    {
   
            //only has player move when button is pressed
            if (isPlayerMoving)
            {
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 10 * moveDirection);
            }
            else
            {
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
            if (isPlayerShooting)
            {
                StartCoroutine(Shooting());
            }
            else
            {
                StopCoroutine(Shooting());
            }
        
    }
    private IEnumerator Shooting()
    {

            //spawns bullets
            if (Time.time > nextFire)
            {
                GameObject newbullet = Instantiate(Bullet, new Vector2(Spawnpoint.transform.position.x, Spawnpoint.transform.position.y), quaternion.identity);
                AudioSource.PlayClipAtPoint(shootSound, transform.position);
                GameObject newexplosion = Instantiate(Explosion, new Vector2(Spawnpoint.transform.position.x, Spawnpoint.transform.position.y), quaternion.identity);
                newbullet.GetComponent<Rigidbody2D>().velocity = new Vector2(40, 0);
                nextFire = Time.time + fireRate;
                Destroy(newexplosion, 0.2f);
                Destroy(newbullet, 10);
            }
            yield return null;
        
    }
    //increases score
    public void ScoreUP()
    {
        score = score + 100;
        scoretext.text = "Score: " + score;
    }
    public void LoseLife()
    {
        lives = lives - 1;
        livestext.text = "Lives: " + lives;
        AudioSource.PlayClipAtPoint(liveSound, transform.position);
        if (lives ==0)
        {
            HighScoreUpdate();
           
            enemyControler.StopSpawn();
            livestext.gameObject.SetActive(false);
            scoretext.gameObject.SetActive(false);
            gameOverText.gameObject.SetActive(true);
            endScoreText.text = "Score: " + score;
            endScoreText.gameObject.SetActive(true);
            highScoreText.gameObject.SetActive(true);
            AudioSource.PlayClipAtPoint(liveSound, transform.position);
        }
    }
    public void HighScoreUpdate()
    {
        //is there already high score
        if(PlayerPrefs.HasKey("SavedHighScore"))
        {
            //is new score higher
            if(score>PlayerPrefs.GetInt("SavedHighScore"))
            {
                //set new HighSCore
                PlayerPrefs.SetInt("SavedHighScore", score);
            }
        }
        else
        {
            //no high score
            PlayerPrefs.SetInt("SavedHighScore", score);
        }
        highScoreText.text = "Highscore: " + PlayerPrefs.GetInt("SavedHighScore");
    }
}
