using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    [SerializeField] private Transform content;
    [SerializeField] private GameObject chunkPrefab;

    [Header("When [isSquareMap] = True: Map will have 1 row with total chucks = [mapSize]. \n" +
        "When [isSquareMap] = False: Map will have [mapSize] rows and each row have [mapSize] chucks.")]
    [SerializeField] private bool isSquareMap = true;
    [SerializeField] private int mapSize = 3;
    private const int DISTANCE = 4;

    private void Start()
    {
        GenerateWorld();
    }

    private void GenerateWorld()
    {
        if (isSquareMap) {
            for (int x = 0; x < mapSize; x++) {
                for (int z = 0; z < mapSize; z++) {
                    Vector3 chunkPosition = new Vector3(x * DISTANCE, 0, z * DISTANCE);
                    GameObject newChunk = Instantiate(chunkPrefab, chunkPosition, Quaternion.identity, content);
                    newChunk.GetComponent<Chunk>().GenerateChunk();
                }
            }
        } else {
        for (int i = 0; i < mapSize; i++) {
            Vector3 chunkPos = new Vector3(i * DISTANCE, 0, 0);
            GameObject newChunk = Instantiate(chunkPrefab, chunkPos, Quaternion.identity, content);
            newChunk.GetComponent<Chunk>().GenerateChunk();
        }
        }
    }
}
