namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;

    public interface IUIView
    {
        void Show(int location, UIView.UIViewDelegate callback);
    }
}