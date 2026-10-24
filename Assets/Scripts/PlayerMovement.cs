using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private CharacterController controller;
    private float verticalSpeed;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Keyboard keyboard = Keyboard.current;

        float x = 0f;
        float y = 0f;
        float z = 0f;

        if (keyboard != null)
        {
            if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed)
                x -= 1f;

            if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed)
                x += 1f;

            if (keyboard.wKey.isPressed || keyboard.upArrowKey.isPressed)
                z += 1f;

            if (keyboard.sKey.isPressed || keyboard.downArrowKey.isPressed)
                z -= 1f;

            if (keyboard.spaceKey.isPressed)
                y += 1f;
        }

        Vector3 direction = new Vector3(x, y, z);
        direction = Vector3.ClampMagnitude(direction, 1f);

        if (controller.isGrounded && verticalSpeed < 0f)
            verticalSpeed = -2f;

        verticalSpeed += Physics.gravity.y * Time.deltaTime;

        Vector3 movement = direction * speed;
        movement.y = verticalSpeed;

        controller.Move(movement * Time.deltaTime);
    }
}