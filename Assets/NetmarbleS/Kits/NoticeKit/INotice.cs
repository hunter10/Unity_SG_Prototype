namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;

    public interface INotice
    {
        string VERSION { get; }
        int INTRO { get; }
        int INGAME { get; }
        void SetViewConfiguration(string configuration);
    }
}