using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArrowScript : MonoBehaviour
{
    public Animator anim;

    public LevelManager.SceneNames SceneToMoveTo;
    private LevelManager levelManager;
    private void Start()
    {
        anim = GetComponent<Animator>();
        levelManager = GameManager.Instance.levelManager;
    }
    public void GoToScene()
    {
        print("is executing");
        anim.SetTrigger("Moving");
    }
    public void MovingToNextScene()
    {
        GameManager.Instance.onlyCamera.MoveCameraPositionTo(levelManager.GetCameraNewPosition(SceneToMoveTo.GetHashCode()));
    }

    #region OnTouchArrow


    private bool isClicking;

    private void OnMouseOver()
    {
        if (!isClicking)
        {
            this.GetComponent<SpriteRenderer>().color = Color.yellow;
        }

    }
    private void OnMouseDown()
    {
        if (!isClicking)
        {
            isClicking = true;
            this.GetComponent<SpriteRenderer>().color = Color.red;
            GoToScene();

        }

    }
    private void OnMouseUp()
    {
        this.GetComponent<SpriteRenderer>().color = Color.white;
        isClicking = false;

    }
    private void OnMouseExit()
    {
        if (!isClicking)
            this.GetComponent<SpriteRenderer>().color = Color.white;

    }
    #endregion
}
