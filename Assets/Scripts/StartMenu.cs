using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StartMenu : MonoBehaviour
{
    //references
    [SerializeField] private GameObject player;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private AudioSource btnSound;
    //variables
    public float rotatingSpeed=2f;
    int highScore=0;
    // Start is called before the first frame update
    void Start()
    {
        highScore=PlayerPrefs.GetInt("highscore");
    }

    // Update is called once per frame
    void Update()
    {
        player.transform.Rotate(Vector3.up*rotatingSpeed*Time.deltaTime);
        highScoreText.text="HIGHSCORE : "+highScore;
    }
    public void PlayBtn()
    {
        btnSound.Play();
        SceneManager.LoadScene(1);
    }
    public void ExitBtn()
    {
        btnSound.Play();
        Application.Quit();
    }
}
