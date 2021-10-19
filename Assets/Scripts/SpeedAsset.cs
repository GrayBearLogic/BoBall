using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Game
{
    
    [CreateAssetMenu(menuName = "Create SpeedAsset", fileName = "SpeedAsset", order = 0)]
    public class SpeedAsset : ScriptableObject
    {
        [SerializeField] private float value = 1;

        public float Value
        {
            get => value;
        }
    }
}