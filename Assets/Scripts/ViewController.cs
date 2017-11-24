﻿using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class ViewController : MonoBehaviour {

    private RectTransform cachedRectTransform;
    public RectTransform CachedRectTransform
    {
        get
        {
            if (cachedRectTransform == null)
            {
                cachedRectTransform = GetComponent<RectTransform>();
            }
            return cachedRectTransform;
        }
    }
}

