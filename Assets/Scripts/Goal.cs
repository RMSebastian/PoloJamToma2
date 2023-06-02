using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void StatementComplete()
    {
        Cursor.lockState = CursorLockMode.Locked;
        anim.SetTrigger("begin");
    }
    public void StopMusic()
    {
        MusicManagerMusic.Instance.auso.Stop();
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene("EndMenu");
        MusicManagerMusic.Instance.auso.Stop();
        Destroy(GameManager.Instance);
    }
}
