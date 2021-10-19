using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
    public class IndependentWall: MonoBehaviour
    {
        [SerializeField] private Transform lower;
        [SerializeField] private Transform upper;

        private const float Space = 4f;
        
        private void Start()
        {
            var gap = Next(1.1f, 1.7f );

            var upperBound = Space - gap;
            var lowerBound = -Space + gap;
            
            var shift = WithProbability(0.5f) ? 
                Next(upperBound - 1, upperBound) : 
                Next(lowerBound,lowerBound + 1);
            
            upper.Translate(Vector3.up * (shift + gap));
            lower.Translate(Vector3.up * (shift - gap));

            //upper.gameObject.SetActive(WithProbability(0.1f));
            //lower.gameObject.SetActive(WithProbability(0.1f));
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