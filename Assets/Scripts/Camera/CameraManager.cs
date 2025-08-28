using UnityEngine;
using Cinemachine;
using System.Collections;
public class CameraManager : SingletonMono<CameraManager>
{
    public enum CameraMode
    {
        Main,
        Inventory,
        Status
    }

    public GameObject MainCameraRig;
    public GameObject StatusCameraRig;
    public GameObject InventoryCameraRig;

    Quaternion startRot;
    Quaternion targetRot;
    float t = 0f;
    float duration = 1f;
    private CameraMode currentMode = CameraMode.Main;

    private void Start()
    {
        SetCameraMode(CameraMode.Main);
    }
    
    public CameraMode GetCurrentCameraMode()
    {
        return currentMode;
    }

    public void SetCameraMode(CameraMode Mode)
    {
        if (currentMode == Mode) return;
        if (Mode == CameraMode.Main)
        {
            MainCameraRig.GetComponentInChildren<CinemachineVirtualCamera>().Priority = 10;
            StatusCameraRig.GetComponentInChildren<CinemachineVirtualCamera>().Priority = 0;
            InventoryCameraRig.GetComponentInChildren<CinemachineVirtualCamera>().Priority = 0;
            startRot = MainCameraRig.transform.rotation;
            targetRot = Quaternion.Euler(10f, 160f, 0f);
            currentMode = CameraMode.Main;
            StartCoroutine(SmoothRotate(MainCameraRig.transform));
        }
        else if (Mode == CameraMode.Inventory)
        {
            MainCameraRig.GetComponentInChildren<CinemachineVirtualCamera>().Priority = 0;
            StatusCameraRig.GetComponentInChildren<CinemachineVirtualCamera>().Priority = 0;
            InventoryCameraRig.GetComponentInChildren<CinemachineVirtualCamera>().Priority = 10;
            startRot = InventoryCameraRig.transform.rotation;
            currentMode = CameraMode.Inventory;
            targetRot = Quaternion.Euler(10f, 180f, 0f);
            StartCoroutine(SmoothRotate(InventoryCameraRig.transform));
        }
        else if (Mode == CameraMode.Status)
        {
            MainCameraRig.GetComponentInChildren<CinemachineVirtualCamera>().Priority = 0;
            StatusCameraRig.GetComponentInChildren<CinemachineVirtualCamera>().Priority = 10;
            InventoryCameraRig.GetComponentInChildren<CinemachineVirtualCamera>().Priority = 0;
            startRot = StatusCameraRig.transform.rotation;
            currentMode = CameraMode.Status;
            targetRot = Quaternion.Euler(10f, 200f, 0f);
            StartCoroutine(SmoothRotate(StatusCameraRig.transform));
        }
    }
    IEnumerator SmoothRotate(Transform currentParent)
    {
        while (t < 1f)
        {
            t += Time.deltaTime / duration;
            currentParent.rotation = Quaternion.Slerp(startRot, targetRot, t);
            yield return null;
        }
        currentParent.rotation = targetRot;
    }
}