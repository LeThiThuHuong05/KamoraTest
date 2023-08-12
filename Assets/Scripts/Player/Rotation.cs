using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour, IRotatable
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform mainCamera;

    private float rotationSpeed = 3.0f;
    private float moveSpeed = 5.0f;
    private float cameraRotation = 0.0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
        Cursor.visible = false; // Hide the cursor
    }
    private void Update()
    {
        OnRotate();
    }

    public void OnRotate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical) * moveSpeed * Time.deltaTime;
        player.Translate(movement);

        // Rotate the camera horizontally
        float mouseX = Input.GetAxis("Mouse X");
        cameraRotation += mouseX * rotationSpeed;

        // Rotate the player horizontally
        player.rotation = Quaternion.Euler(0f, cameraRotation, 0f);

        // Rotate the camera vertically
        float mouseY = Input.GetAxis("Mouse Y");
        mainCamera.Rotate(Vector3.left, mouseY * rotationSpeed);
    }
}
