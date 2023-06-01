using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuChangeScene : MonoBehaviour
{
    public Animator anim;

    public Image imgTitle;
    public Button btnPlay;
    public Image imgFadeIn;
    
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void StartButton()
    {
        imgFadeIn.gameObject.SetActive(true);
    }
    public void HideUI()
    {
        imgTitle.gameObject.SetActive(false);
        btnPlay.gameObject.SetActive(false);
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene("SampleScene Seba");
    }
}
