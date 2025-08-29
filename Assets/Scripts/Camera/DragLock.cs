using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Cinemachine;
using UnityEngine;
class Draglock : MonoBehaviour
{
    private CinemachineFreeLook freeLookCamera;
    public CameraController.CameraMode Mode = CameraController.CameraMode.Inventory;
    void Awake()
    {
        freeLookCamera = GetComponent<CinemachineFreeLook>();
        if (freeLookCamera == null)
        {
            Debug.LogError("CinemachineFreeLook component not found on this GameObject.");
        }
    }
    void Update()
    {
        if (IsLookingAllowed())
        {
            freeLookCamera.m_XAxis.m_InputAxisName = "Mouse X";
            freeLookCamera.m_YAxis.m_InputAxisName = "Mouse Y";
        }
        else
        {
            freeLookCamera.m_XAxis.m_InputAxisName = "";
            freeLookCamera.m_YAxis.m_InputAxisName = "";
        }
    }

    bool IsLookingAllowed()
    {
        // 마우스 오른쪽 버튼이 눌렸는지
        bool rightMouseDown = Mouse.current.leftButton.isPressed;

        // UI 클릭 중인지
        bool overUI = EventSystem.current != null &&
                      EventSystem.current.IsPointerOverGameObject();

        return rightMouseDown && !overUI;
    }
}