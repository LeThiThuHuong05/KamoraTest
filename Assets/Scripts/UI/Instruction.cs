using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruction : BaseUI
{
    [SerializeField] private GameObject content;
    private float timer = 0;
    private float showTime = 60f;

    public override void Hide()
    {
        content.SetActive(false);
        timer = 0;
    }
    public override void Show()
    {
        content.SetActive(true);
        timer = 0;
    }

    public override void Back()
    {

    }

    public override void Next()
    {

    }

    private void Update()
    {
        if (content.activeSelf) {
            timer += Time.deltaTime;
            if (timer > showTime) {
                Hide();
            }
        }
    }

    public void OnChangeStatus()
    {
        if (content.activeSelf) {
            Hide();
        } else {
            Show();
        }
    }

}
