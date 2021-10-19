using System.Linq;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "Functions/Bounce", fileName = "BounceFunction", order = 0)]
    public class BounceFunction : Function
    {
        public override float Calculate(float x) => 
            Enumerable
                .Range(1, 20)
                .Select(n => Mathf.Sin(n * x) / n)
                .Sum();
    }
}