using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    //References
    CharacterController controller;
    Animator anim;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject buttons;
    [SerializeField] private GameObject loseText;
    [SerializeField] private GameObject playBtn;
    [SerializeField] private GameObject virtualCameraOne;
    [SerializeField] private GameObject virtualCameraTwo;
    [SerializeField] private GameObject virtualCameraThree;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text coinsText;
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioSource hitSound;
    [SerializeField] private AudioSource coinSound;

    [SerializeField] private AudioSource btnSound;
    

    //Variables
    float horizontal=0f;
    Vector3 moveDirection;
    public float speed=3f;
    public float jumpForce=15f;
    public float gravity=-20f;
    bool isPlaying=true;
    int coins=0;
    int state;
    int highScore;
    float timeCounter=0f;
    int seconds=0;
    int score=0;
    bool isRight=false;
    bool isLeft=false;
    bool isJump=false;
    
    // Start is called before the first frame update
    void Start()
    {
        controller=GetComponent<CharacterController>();
        anim=GetComponent<Animator>();

        highScore=PlayerPrefs.GetInt("highscore");
        isPlaying=true;
        PlayerPrefs.SetInt("coins",0);
        buttons.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
       Move();
       CameraUpdate();
       ScoreUpdate();
    }

    void Move()
    {
        if(isLeft)
        {
            horizontal=-1f;
        }
        else if(isRight)
        {
            horizontal=1f;
        }
        else
        {
            horizontal=0f;
        }
        if(controller.isGrounded)
        {
            moveDirection=new Vector3(horizontal,0f,0f);
            moveDirection*=speed;
            if(isJump)
            {
                jumpSound.Play();
                moveDirection.y=jumpForce;
                state=1;
            }
            else if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                state=2;
            }
            else
            {
                state=0;
            }
        }
        moveDirection.y+=gravity*Time.deltaTime;
        controller.Move(moveDirection*Time.deltaTime);
        anim.SetInteger("state",state);
    }
    void CameraUpdate()
    {
        if(transform.position.x>=-0.05f&&transform.position.x<=0.05f)
        {
            virtualCameraOne.SetActive(true);
            virtualCameraTwo.SetActive(false);
            virtualCameraThree.SetActive(false);
        }
        else if(transform.position.x<=-2.5f)
        {
            virtualCameraOne.SetActive(false);
            virtualCameraTwo.SetActive(true);
            virtualCameraThree.SetActive(false);
        }
        else if(transform.position.x>2.0f)
        {
            virtualCameraOne.SetActive(false);
            virtualCameraTwo.SetActive(false);
            virtualCameraThree.SetActive(true);
        }
    }
    void ScoreUpdate()
    {
        if(isPlaying)
        {
            timeCounter+=Time.deltaTime;
            seconds=(int)(timeCounter%60)+(int)(timeCounter/60);
            score+=(seconds-score);
        }
        
        scoreText.text="Score : "+score;
        if(score>highScore)
        {
            PlayerPrefs.SetInt("highscore",score);
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("GroundSpawn"))
        {
            GameObject ground=GroundPool.instance.GetPooledObject();
            if(ground!=null)
            {
                ground.transform.position=new Vector3(0f,0f,25.8f);
                ground.SetActive(true);
            }
        }
        if(other.gameObject.CompareTag("gold"))
        {
            coinSound.Play();
            coins++;
            coinsText.text="coins : "+coins;
        }
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.CompareTag("obstacle"))
        {
            hitSound.Play();
            Time.timeScale=0;
            isPlaying=false;
            loseText.SetActive(true);
            playBtn.SetActive(false);
            panel.SetActive(true);
        }
    }
    public void PlayBtn()
    {
        Time.timeScale=1;
        isPlaying=true;
        panel.SetActive(false);
        btnSound.Play();
        buttons.SetActive(true);
    }
    public void PauseBtn()
    {
        Time.timeScale=0;
        isPlaying=false;
        panel.SetActive(true);
        btnSound.Play();
        buttons.SetActive(false);
    }
    public void RePlayBtn()
    {
        btnSound.Play();
        Time.timeScale=1;
        panel.SetActive(false);
        SceneManager.LoadScene(1);
        loseText.SetActive(false);
        playBtn.SetActive(true);
        

    }
    public void BackBtn()
    {
        btnSound.Play();
        Time.timeScale=1;
        panel.SetActive(false);
        SceneManager.LoadScene(0);
        loseText.SetActive(false);
        playBtn.SetActive(true);
        PlayerPrefs.SetInt("coins",coins);
    }
    public void LeftBtnUp()
    {
        isLeft=false;
    }
    public void LeftBtnDown()
    {
        isLeft=true;
        Debug.Log("left");
    }
    public void RightBtnDown()
    {
        isRight=true;
        Debug.Log("right");
    }
    public void RightBtnUp()
    {
        isRight=false;
    }
    public void JumpBtnDown()
    {
        isJump=true;
    }
    public void JumpBtnUp()
    {
        isJump=false;
    }
}
