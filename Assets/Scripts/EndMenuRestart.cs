using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenuRestart : MonoBehaviour
{
    // Start is called before the first frame update
    void Restart()
    {
        Destroy(GameManager.Instance);
        Destroy(MusicManagerMusic.Instance);
        Destroy(InventorySystem.Instance);
        SceneManager.LoadScene("MainMenu");
    }
}
