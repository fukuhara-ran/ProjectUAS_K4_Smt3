using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMov : MonoBehaviour
{
    public int jump;
    private Rigidbody2D rb;
    public float runSpeed;
    private float jumpTimeCounter;
    public float jumpTime;
    public float checkRadius;
    private bool isGrounded;
    private bool isJumping;
    public Transform feetPos;
    public LayerMask whatIsGround;
    Animator anim;
    public bool isGameOver = false;
    public GameObject GameOverPanel, scoreText;
    public TextMeshProUGUI FinalScoreText, HighScoreText;
    [SerializeField] private AudioSource jumpSfx;
    [SerializeField] private AudioSource deathSfx;
    
    // Start is called before the first frame update
    void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine("IncraseGameSpeed");
    }
    // Update is called once per frame
    void Update()
    {
        if(!isGameOver)
        {
            transform.position = Vector3.right * runSpeed * Time.deltaTime + transform.position;
            isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        }
        if (Input.GetButtonDown("Jump") && isGrounded == true && !isGameOver)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jump;
            anim.SetTrigger("jump");
            jumpSfx.Play();
        }
        if (Input.GetButton("Jump") && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jump;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }
    }
    public void GameOver()
    {
        isGameOver = true;
        anim.SetTrigger("death");
        StopCoroutine("IncraseGameSpeed");
        StartCoroutine("ShowGameOverPanel");
        deathSfx.Play();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (other.gameObject.CompareTag("Obstacles"))
        {
            GameOver();
        }
        if (other.gameObject.CompareTag("BottomDetector"))
        {
            GameOver();
        }
    }
    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    IEnumerator IncraseGameSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);

            if (runSpeed < 9)
            {
                runSpeed += 0.2f;
            }

            if (GameObject.Find("GroundSpawner").GetComponent<ObstacleSpawner>().obstacleInterfal > 1)
            {
                GameObject.Find("GroundSpawner").GetComponent<ObstacleSpawner>().obstacleInterfal -= 0.1f;
            }
        }
    }
    IEnumerator ShowGameOverPanel()
    {
        yield return new WaitForSeconds(2);
        GameOverPanel.SetActive(true);
        scoreText.SetActive(false);

        FinalScoreText.text = "Score : " + GameObject.Find("ScoreDetector").GetComponent<ScoreSystem>().score;
        HighScoreText.text = "HighScore : " + PlayerPrefs.GetInt("Highscore");
    }
}
