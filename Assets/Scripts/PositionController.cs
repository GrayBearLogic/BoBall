using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class PositionController : MonoBehaviour
{
    [SerializeField] private new Camera camera;
    private Rect area;

    private Vector2 touchStart;
    private Vector2 positionStart;

    private void Awake()
    {
        area = new Rect(0,0, Screen.width * 0.7f, Screen.height);
    }

    private void Update()
    {
        #if UNITY_EDITOR
        if ((Input.GetMouseButton(0) || Input.GetMouseButtonDown(0)) && area.Contains(Input.mousePosition))
        {
            Vector2 pos = camera.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetMouseButtonDown(0))
            {
                touchStart = pos;
                positionStart = transform.position;
            }
            else if (Input.GetMouseButton(0))
            {
                transform.position = positionStart + (pos - touchStart);
            }
        }
        #elif PLATFORM_ANDROID || UNITY_ANDROID
        if (Input.touchCount > 0 && area.Contains(Input.touches[0].position)) // there is a touch in this frame
        {
            var touch = Input.touches[0];
            Vector2 pos = camera.ScreenToWorldPoint(touch.position);
            
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStart = pos;
                    positionStart = transform.position;
                    break;
                case TouchPhase.Moved:
                    transform.position = positionStart + (pos - touchStart);
                    break;
            }
        }
        #endif
    }
}