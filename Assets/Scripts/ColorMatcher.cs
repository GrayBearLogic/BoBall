using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class ColorMatcher : MonoBehaviour
    {
        [SerializeField] private ColorType selectedColorType;
        [SerializeField] private Color red;
        [SerializeField] private Color blue;
        [SerializeField] private Color green;
        [SerializeField] private SpriteRenderer view;
        
        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.TryGetComponent(out ColorZone zone))
            {
                if (zone.Type != selectedColorType)
                {
                    EndGame();
                }
            }
        }

        private void Start()
        {
            SetBlue();
        }

        private void EndGame()
        {
            print("stop");
            Application.Quit();
        }

        public void SetRed()
        {
            selectedColorType = ColorType.Red;
            view.color = red;
        }
        public void SetBlue()
        {
            selectedColorType = ColorType.Blue;
            view.color = blue;
        }
        public void SetGreen()
        {
            selectedColorType = ColorType.Green;
            view.color = green;
        }
        
    }
}