using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenuRestart : MonoBehaviour
{
    // Start is called before the first frame update
    void Restart()
    {
        Destroy(GameManager.Instance.gameObject);
        Destroy(MusicManagerMusic.Instance.gameObject);
        Destroy(InventorySystem.Instance.gameObject);
        SceneManager.LoadScene("MainMenu");
    }
}
