using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    protected Action OnActionBack;

    public void SetCallback(Action _callback)
    {
        OnActionBack = null;
        OnActionBack += _callback;
    }

    public abstract void Show();
    public abstract void Hide();
    public abstract void Back();
    public abstract void Next();

    public virtual void Show<T>(T argument)
    {

    }

    public virtual void Hide<T>(T argument)
    {

    }


}
