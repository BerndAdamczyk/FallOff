using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class BallPlayerController : MonoBehaviour
{
    [SerializeField]
    private float m_MoveSpeed;
    [SerializeField]
    private float m_JumpMultiplier;
    private float m_XForce;
    private float m_ZForce;

    private bool Grounded = false;
    public float GroundedRadius = 0.5f;
    public LayerMask GroundLayers;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        GroundedCheck();
    }
    public void OnMove(InputAction.CallbackContext callback)
    {
        switch (callback.phase)
        {
            case InputActionPhase.Disabled:
                break;
            case InputActionPhase.Waiting:
                break;
            case InputActionPhase.Started:
                break;
            case InputActionPhase.Performed:
                m_XForce = callback.ReadValue<Vector2>().x;
                m_ZForce = callback.ReadValue<Vector2>().y;
                break;
            case InputActionPhase.Canceled:
                m_XForce = 0f;
                m_ZForce = 0f;
                break;
            default:
                break;
        }

    }
    public void OnJump(InputAction.CallbackContext callback)
    {
        switch (callback.phase)
        {
            case InputActionPhase.Disabled:
                break;
            case InputActionPhase.Waiting:
                break;
            case InputActionPhase.Started:
                break;
            case InputActionPhase.Performed:
                Jump();
                break;
            case InputActionPhase.Canceled:
                break;
            default:
                break;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.AddForce(new Vector3(m_XForce, 0, m_ZForce) * m_MoveSpeed);
    }
    private void Jump()
    {
        if(Grounded)
            rb.AddForce(new Vector3(0, 1, 0) * m_JumpMultiplier, ForceMode.Impulse);
    }
    private void GroundedCheck()
    {
        Grounded = Physics.CheckSphere(transform.position, GroundedRadius, GroundLayers,
            QueryTriggerInteraction.Ignore);

    }
}
