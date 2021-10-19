using System.Linq;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "Functions/DoubleBounce", fileName = "DoubleBounceFunction", order = 0)]
    public class DoubleBounceFunction : Function
    {
        public override float Calculate(float x) => 
            Enumerable
                .Range(1, 10)
                .Select(n => Mathf.Sin((2 * n - 1) * x) / (2 * n - 1))
                .Sum();
    }
}