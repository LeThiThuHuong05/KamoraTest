using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlaceBlock : MonoBehaviour
{
    public static PlaceBlock Instance;

    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform content;
    [SerializeField] private Transform blockPrefab;
    private BlockType curBlockType;

    public event EventHandler<BlockType> OnSelectBlockPlaceChanged;

    private void Awake()
    {
        if (Instance != null) {
            Debug.LogError("There is more than one PlaceBlock instance");
        }
        Instance = this;
    }
    void Start()
    {
        OnChangePlaceBlockType(BlockType.Grass);
    }

    void Update()
    {
        // Select type block want to place
        if (Input.GetKeyDown(KeyCode.Alpha1)) { // number 1
            OnChangePlaceBlockType(BlockType.Grass);
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) { // number 2
            OnChangePlaceBlockType(BlockType.Dirt);
        } else if (Input.GetKeyDown(KeyCode.Alpha3)) { // number 3
            OnChangePlaceBlockType(BlockType.Stone);
        }

        // Place block 
        if (Input.GetMouseButtonDown(1)) { // right mouse
            OnPlaceBlock();
        }
    }

    private void OnPlaceBlock()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit)) {
            Vector3 blockPos = hit.point + hit.normal * 0.5f;
            blockPos.x = Mathf.Round(blockPos.x);
            blockPos.y = Mathf.Round(blockPos.y);
            blockPos.z = Mathf.Round(blockPos.z);
            // Gen Block
            GameObject newBlock = Instantiate(blockPrefab.gameObject, blockPos, Quaternion.identity, content);
            Block block = newBlock.GetComponent<Block>();
            block.InitByType(curBlockType);
        }
    }

    private void OnChangePlaceBlockType(BlockType blockType)
    {
        curBlockType = blockType;
        OnSelectBlockPlaceChanged?.Invoke(this, curBlockType);
    }
}
