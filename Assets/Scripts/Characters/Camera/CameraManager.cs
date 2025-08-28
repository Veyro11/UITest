using UnityEngine;
using Cinemachine;

public class CameraManager : SingletonMono<CameraManager>
{
    public CinemachineVirtualCamera mainCamera;
    public CinemachineVirtualCamera inventoryCamera;
    public CinemachineVirtualCamera statusCamera;
    public enum CameraMode
    {
        Main,
        Inventory,
        Status
    }
    private CameraMode currentMode = CameraMode.Main;
    private void Start()
    {
        SetCameraMode(CameraMode.Main);
    }
    public void SetCameraMode(CameraMode mode)
    {
        currentMode = mode;
        mainCamera.gameObject.SetActive(mode == CameraMode.Main);
        inventoryCamera.gameObject.SetActive(mode == CameraMode.Inventory);
        statusCamera.gameObject.SetActive(mode == CameraMode.Status);
    }
    public CameraMode GetCurrentCameraMode()
    {
        return currentMode;
    }
}