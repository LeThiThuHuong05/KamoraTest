using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private MeshRenderer blockMaterials;
    [SerializeField] private List<Material> listMaterials;
    private BlockType blockType;
    private float breakTime;

    public BlockType BlockType { get { return blockType; } set { blockType = value; } }
    public float BreakTime { get { return breakTime; } set { breakTime = value; } }

    public void Init(int blockIndex)
    {
        BlockType type = GetBlockType(blockIndex);
        InitByType(type);
    }

    public void InitByType(BlockType type)
    {
        blockType = type;
        breakTime = (int)blockType + 1;
        blockMaterials.material = listMaterials[(int)blockType];
    }

    // Check block type by layer sort
    private BlockType GetBlockType(int blockIndex)
    {
        BlockType type;
        switch (blockIndex) {
            case 3:
                type = BlockType.Grass;
                break;
            case 2:
                type = BlockType.Dirt;
                break;
            default:
                type = BlockType.Stone;
                break;
        }
        return type;
    }
}
