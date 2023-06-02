using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuChangeScene : MonoBehaviour
{
    public Animator anim;
    public AudioSource auso;
    public AudioClip fiestaSound;
    public AudioClip menuSound;

    public Image imgTitle;
    public Button btnPlay;
    public Button btnExit;
    public Image imgFadeIn;

    private bool start = false;
    private void Start()
    {
        anim = GetComponent<Animator>();
        auso = GetComponent<AudioSource>();
        auso.clip = menuSound;
        auso.loop = true;
        auso.Play();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    public void StartButton()
    {
        if(!start)
        {
            start = true;
            anim.SetTrigger("begin");
            imgFadeIn.gameObject.SetActive(true);
            auso.clip = fiestaSound;
            auso.Play();
        }
        
    }
    public void HideUI()
    {
        imgTitle.gameObject.SetActive(false);
        btnPlay.gameObject.SetActive(false);
        btnExit.gameObject.SetActive(false);
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
