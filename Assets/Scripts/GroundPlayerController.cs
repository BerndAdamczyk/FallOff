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
    private float m_XAxisRotation = 0f;
    private float m_ZAxisRotation = 0f;
    private float m_YAxisRotation = 0f;
    private Vector3 m_StartRotation = Vector3.zero;
    private Vector3 m_EndRotation = Vector3.zero;
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
                m_XAxisRotation = callback.ReadValue<Vector2>().y * m_Multiplier;
                m_ZAxisRotation  = - callback.ReadValue<Vector2>().x * m_Multiplier;
                break;
            case InputActionPhase.Canceled:
                m_XAxisRotation = 0f;
                m_ZAxisRotation = 0f;
                break;
            default:
                break;
        }
        
    }
    public void Update()
    {
        m_EndRotation.x = Mathf.Clamp(m_EndRotation.x + m_XAxisRotation, -50f, 50f);
        m_EndRotation.z = Mathf.Clamp(m_EndRotation.z + m_ZAxisRotation, -50f, 50f);

        transform.rotation = Quaternion.Euler(m_EndRotation);

    }
}
