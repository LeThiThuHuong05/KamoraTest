using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    [SerializeField] private Instruction instruction;

    private void Awake()
    {
        if (Instance != null) {
            Debug.LogError("There is more than one GameController instance");
        }
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        instruction.Show();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) { // "I" key
            instruction.OnChangeStatus();
        }
    }
}
