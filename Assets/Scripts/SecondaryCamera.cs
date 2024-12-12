using UnityEngine;
using Cinemachine;

public class SecondaryCamera : MonoBehaviour
{
    public CinemachineVirtualCamera defaultCamera;
    public CinemachineVirtualCamera secondaryCamera;
    public GameObject WireMiniGamePrefab;
    public GameObject BubbleMiniGamePrefab;
    public GameObject PauseMenu;
    public GameObject interactionHud;

    private GameObject activeOverlay;

    //Switches the Main Camera to the Secondary Camera
    public void MainCameraSwitch(GameObject prefab)
    {
        defaultCamera.Priority = 5;
        secondaryCamera.Priority = 10;

        //Instantiate the overlay prefab
        if(prefab != null && activeOverlay == null)
        {
            activeOverlay = Instantiate(prefab);
        }
    }

    public void ReturnToMainCamera()
    {
        defaultCamera.Priority = 10;
        secondaryCamera.Priority = 5;

        if(activeOverlay != null)
        {
            Destroy(activeOverlay);
            activeOverlay = null;
        }
    }

    public void StartBubbleMiniGame()
    {
        MainCameraSwitch(BubbleMiniGamePrefab);
    }
    public void StartWireMiniGame()
    {
        MainCameraSwitch(WireMiniGamePrefab);
    }

    public void StartPauseMenu()
    {
        MainCameraSwitch(PauseMenu);
    }

    public void StartInteractionHub()
    {
        MainCameraSwitch(interactionHud);
    }

    public void Exit()
    {
        ReturnToMainCamera();
    }
}
