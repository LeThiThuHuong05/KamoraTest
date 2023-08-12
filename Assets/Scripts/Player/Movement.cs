using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour, IMoveable
{
    [SerializeField] private CharacterController characterController;

    [SerializeField] private float moveSpeed = 5f;

    private void Update()
    {
        OnMove();
    }

    public void OnMove() {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = (this.transform.right * horizontal + this.transform.forward * vertical) * moveSpeed * Time.deltaTime;
        characterController.Move(movement);
    }
}
