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
    public InputActionReference lookInput; // InputAction asset에서 Look 액션 참조

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

            // 목표 회전 값 업데이트 (Yaw: 좌우, Pitch: 상하)
            Vector2 TargetRotation = currentRotation + new Vector2(-LookDelta.y, LookDelta.x) * mouseSensitivity;

        // Pitch 범위 제한
        TargetRotation.x = Mathf.Clamp(TargetRotation.x, minPitch, maxPitch);

        // 부드러운 회전 (Lerp 느낌)
        currentRotation = Vector2.SmoothDamp(currentRotation, TargetRotation, ref currentVelocity, rotationSmoothTime);

        // 실제 회전 적용
        transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, 0f);
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

    public void ChangeCameraMode(CameraMode mode)
    {
        if (mode == CameraMode.Main)
        {
            Mode = CameraMode.Inventory;
            // 인벤토리 카메라로 전환하는 로직 추가
            Debug.Log("Switched to Inventory Camera");
        }
        
    }
}