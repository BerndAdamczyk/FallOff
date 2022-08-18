using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject PlayerOnePrefab;
    [SerializeField]
    private GameObject PlayerTwoPrefab;

    void Start()
    {
        // Create two players both using the same keyboard and mouse.
        PlayerInput.Instantiate(PlayerOnePrefab, controlScheme: "KeyboardMouse", pairWithDevices: new InputDevice[] { Keyboard.current, Mouse.current });
        PlayerInput.Instantiate(PlayerTwoPrefab, controlScheme: "KeyboardMouse", pairWithDevices: new InputDevice[] { Keyboard.current, Mouse.current });
    }

}
