using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Cinemachine;
using UnityEditor;

public class CameraController : MonoBehaviour
{
    public enum CameraMode
    {
        Main,
        Inventory,
        Status
    }

    [Header("Settings")]
    public float mouseSensitivity = 3f;
    public float rotationSmoothTime = 0.1f;
    public float minPitch = -40f;
    public float maxPitch = 80f;

    [Header("References")]
    public InputActionReference lookInput; // InputAction asset���� Look �׼� ����

    private Vector2 currentRotation;        // (pitch, yaw)
    private Vector2 currentVelocity;        // smoothing velocity

    [Header("Mode")]
    public CameraMode Mode;

    private void OnEnable()
    {
        lookInput.action.Enable();
    }

    private void OnDisable()
    {
        lookInput.action.Disable();
    }

    void Update()
    {
        if (IsLookingAllowed())
        {

            Vector2 LookDelta = lookInput.action.ReadValue<Vector2>();

            // ��ǥ ȸ�� �� ������Ʈ (Yaw: �¿�, Pitch: ����)
            Vector2 TargetRotation = currentRotation + new Vector2(-LookDelta.y, LookDelta.x) * mouseSensitivity;

        // Pitch ���� ����
        TargetRotation.x = Mathf.Clamp(TargetRotation.x, minPitch, maxPitch);

        // �ε巯�� ȸ�� (Lerp ����)
        currentRotation = Vector2.SmoothDamp(currentRotation, TargetRotation, ref currentVelocity, rotationSmoothTime);

        // ���� ȸ�� ����
        transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, 0f);
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

    public void ChangeCameraMode(CameraMode mode)
    {
        if (mode == CameraMode.Main)
        {
            Mode = CameraMode.Inventory;
            // �κ��丮 ī�޶�� ��ȯ�ϴ� ���� �߰�
            Debug.Log("Switched to Inventory Camera");
        }
        
    }
}