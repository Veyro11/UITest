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
        // ���콺 ������ ��ư�� ���ȴ���
        bool rightMouseDown = Mouse.current.leftButton.isPressed;

        // UI Ŭ�� ������
        bool overUI = EventSystem.current != null &&
                      EventSystem.current.IsPointerOverGameObject();

        return rightMouseDown && !overUI;
    }
}