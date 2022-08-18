using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GroundPlayerController : MonoBehaviour
{
    PlayerInput m_PlayerInput;
    [SerializeField]
    private float m_Multiplier;

    private Vector3 RotationVector;
    private void Awake()
    {
        m_PlayerInput = GetComponent<PlayerInput>();
    }

    public void OnRotate(InputAction.CallbackContext callback)
    {
        switch (callback.phase)
        {
            case InputActionPhase.Disabled:
                break;
            case InputActionPhase.Waiting:
                break;
            case InputActionPhase.Started:
                //RotationVector = new Vector3(callback.ReadValue<Vector2>().x * m_Multiplier,
                //0,
                //callback.ReadValue<Vector2>().y * m_Multiplier);
                break;
            case InputActionPhase.Performed:
                RotationVector = new Vector3(callback.ReadValue<Vector2>().y * m_Multiplier,
                0,
                -callback.ReadValue<Vector2>().x * m_Multiplier);
                break;
            case InputActionPhase.Canceled:
                RotationVector = Vector3.zero;
                break;
            default:
                break;
        }
        
    }
    public void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + RotationVector);

        
    }
}
