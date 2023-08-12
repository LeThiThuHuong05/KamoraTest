using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedBlockVisual : MonoBehaviour
{
    [SerializeField] private Block block;
    [SerializeField] private GameObject visualGameObject;
    private void Start()
    {
        BreakBlock.Instance.OnSelectBlockChanged += Player_OnSelectBlockChanged;
    }

    private void Player_OnSelectBlockChanged(object sender, BreakBlock.OnSelectedBlockChangedEventArgs e)
    {
        if (e.selectedBlock == block) {
            Show();
        } else {
            Hide();
        }
    }

    private void Show() { visualGameObject.SetActive(true); }

    private void Hide() { visualGameObject.SetActive(false); }

    private void OnDestroy()
    {
        BreakBlock.Instance.OnSelectBlockChanged -= Player_OnSelectBlockChanged;
    }
}
