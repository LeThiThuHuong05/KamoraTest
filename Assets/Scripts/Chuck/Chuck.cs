using UnityEngine;

public class Chunk : MonoBehaviour
{
    private const int CHUCK_SIZE = 4;
    private Block[,,] blocks = new Block[4, 4, 4];
    [SerializeField] private Transform content;
    [SerializeField] private Transform blockPrefab; // Reference to the prefab containing the block models

    public void GenerateChunk()
    {
        for (int x = 0; x < CHUCK_SIZE; x++) {
            for (int y = 0; y < CHUCK_SIZE; y++) {
                for (int z = 0; z < CHUCK_SIZE; z++) {
                    Vector3 blockPos = new Vector3(x, y, z);
                    GameObject newBlock = Instantiate(blockPrefab.gameObject, transform.position + blockPos, Quaternion.identity, content);
                    Block block = newBlock.GetComponent<Block>();
                    block.Init(y);
                    blocks[x, y, z] = block;
                }
            }
        }
    }
}
