using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get { return instance; }
    }

    public LevelManager levelManager;
    public CameraScript onlyCamera;
    public InventorySystem inventory;
    public GameObject trashbag;
    public GameObject blackScreen;
    public MusicManagerMusic music;
    public Goal goal;

    public int cantBasuras;

    public bool basuraIsComplete;
    public bool objetosIsComplete;
    public int IsCorrectScene;

    public void SumarBasura()
    {
        cantBasuras += 1;
    }

    public void RestarBasura()
    {
        cantBasuras -= 1;

        if(cantBasuras <= 0)
        {
            CheckWin();
            trashbag.GetComponent<Animator>().SetBool("Full", true);
            basuraIsComplete = true;
        }
        else
        {
            trashbag.GetComponent<Animator>().SetTrigger("Move");
        }
    }
    public void CorrectScene(int i)
    {
        IsCorrectScene = i;
        CheckWin();
    }
    public void CheckWin()
    {
        if(objetosIsComplete && basuraIsComplete && IsCorrectScene == 0)
        {
            //Activar animacion del arbol 
                goal.StatementComplete();
            IsCorrectScene = 1;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            cantBasuras = 0;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(IsCorrectScene == 0)
        {
            CheckWin() ;
        }
    }
}
