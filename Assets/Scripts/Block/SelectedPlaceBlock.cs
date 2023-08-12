using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedPlaceBlock : MonoBehaviour
{
    [SerializeField] private List<Sprite> blockSprites;
    [SerializeField] private Image blockImage;
    private void Start()
    {
        PlaceBlock.Instance.OnSelectBlockPlaceChanged += Player_OnSelectBlockPlaceChanged;
    }
    // change UI current block when user choose block to place
    private void Player_OnSelectBlockPlaceChanged(object sender, BlockType blockType)
    {
        blockImage.sprite = blockSprites[(int)blockType];
    }
    private void OnDestroy()
    {
        PlaceBlock.Instance.OnSelectBlockPlaceChanged -= Player_OnSelectBlockPlaceChanged;
    }
}
