using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoveArrowScript : MonoBehaviour
{

    public LevelManager.SceneNames SceneToMoveTo;
    private LevelManager levelManager;
    private void Start()
    {
        levelManager = GameManager.Instance.levelManager;
    }
    public void GoToScene()
    {
        print("is executing");
        GameManager.Instance.blackScreen.GetComponent<Animator>().SetTrigger("Moving");
        Invoke(nameof(MovingToNextScene), 2f);
    }
    public void MovingToNextScene()
    {
        GameManager.Instance.inventory.MoveInventoryPositionTo(levelManager.GetCameraNewPosition(SceneToMoveTo.GetHashCode()));
        GameManager.Instance.onlyCamera.MoveCameraPositionTo(levelManager.GetCameraNewPosition(SceneToMoveTo.GetHashCode()));
    }
}
