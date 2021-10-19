using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
    public class DoubleWall : MonoBehaviour
    {
        [SerializeField] private Transform lower;
        [SerializeField] private Transform upper;

        private const float Space = 4;
        private static float _oldGap = Space;
        private static float _oldShift = 0;
        
        private void Start()
        {
            var gap = Next(1.1f, Space-2.5f);

            var upperBound = Mathf.Min(Space - gap, _oldShift + _oldGap + gap);
            var lowerBound = Mathf.Max(-Space + gap, _oldShift - _oldGap - gap);
            
            var shift = Next(lowerBound, upperBound);
            
            upper.Translate(Vector3.up * (shift + gap));
            lower.Translate(Vector3.up * (shift - gap));

            upper.gameObject.SetActive(WithProbability(0.1f));
            lower.gameObject.SetActive(WithProbability(0.1f));

            _oldGap = gap;
            _oldShift = shift;
        }

        private static bool WithProbability(float probability)
        {
            return Random.value >= probability;
        }
        
        private static float Next(float a, float b)
        {
            return (Random.value * (b - a)) + a;
        }
    }
}