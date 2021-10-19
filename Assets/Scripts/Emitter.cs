using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Random = System.Random;

namespace Game
{
    public class Emitter : MonoBehaviour
    {
        [SerializeField] private AssetLabelReference label;
        private Section[] prefabs;
        private Section next = null;
        private Section last = null;
        private Random rn;
        
        private void Awake()
        {
            rn = new Random();
            StartCoroutine(LoadSections());
            
        }

        private IEnumerator LoadSections()
        {
            var bag = new ConcurrentBag<Section>();
            
            var task = 
                Addressables.LoadAssetsAsync<GameObject>(label, o => bag.Add(o.GetComponent<Section>()));
            yield return new WaitUntil(() => task.IsDone);
            prefabs = bag.ToArray();
            next = ChooseNext();
        }
        
        private void Update()
        {
            if (prefabs is null) return;
            
            if (last is null || (transform.position.x - last.transform.position.x) > ((next.Width + last.Width) * 0.5f))
            {
                last = SpawnNext();
                next = ChooseNext();
            }
        }

        protected virtual Section ChooseNext()
        {
            return prefabs[rn.Next(prefabs.Length)];
        }

        private Section SpawnNext()
        {
            
            return Instantiate(next, transform.position, quaternion.identity, transform);
        }
    }
}