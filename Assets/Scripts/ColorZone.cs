using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [Serializable] public enum ColorType : int {Red = 0, Green = 1, Blue = 2}
    
    public class ColorZone : MonoBehaviour
    {
        [SerializeField] private ColorType type;

        public ColorType Type
        {
            get => type;
        }
    }
}