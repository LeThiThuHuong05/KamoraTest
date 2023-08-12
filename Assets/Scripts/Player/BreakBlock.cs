using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBlock : MonoBehaviour
{
    public static BreakBlock Instance;

    [SerializeField] private Camera mainCamera;
    private bool breaking = false;
    private Block currentBlock; // targeted block want to break
    private float breakStartTime;

    public event EventHandler<OnSelectedBlockChangedEventArgs> OnSelectBlockChanged;

    public class OnSelectedBlockChangedEventArgs : EventArgs
    {
        public Block selectedBlock;
    }

    private void Awake()
    {
        if (Instance != null) {
            Debug.LogError("There is more than one BreakBlock instance");
        }
        Instance = this;
    }

    private void Update()
    {
        // Raycast to detect the block the player is choose
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit)) {
            Block block = hit.transform.GetComponent<Block>();
            // Set selected block UI
            SetSelectedBlock(block);
            // Check if the player pressed the mouse button
            if (Input.GetMouseButtonDown(0)) {
                StartBreaking(block);
            }
        }
        // Check if the player released the mouse button
        if (Input.GetMouseButtonUp(0)) {
            StopBreaking();
        }

        // Break the block if the breaking time threshold is reached
        if (breaking && currentBlock != null && Time.time - breakStartTime >= currentBlock.BreakTime) {
            OnBreakBlock(currentBlock);
        }
    }

    private void StartBreaking(Block block)
    {
        breaking = true;
        currentBlock = block;
        breakStartTime = Time.time;
    }

    private void StopBreaking()
    {
        breaking = false;
        currentBlock = null;
    }

    private void OnBreakBlock(Block block)
    {
        Destroy(block.gameObject);
    }

    private void SetSelectedBlock(Block selectedBlock)
    {
        OnSelectBlockChanged?.Invoke(this, new OnSelectedBlockChangedEventArgs {
            selectedBlock = selectedBlock
        });
    }
}

