using System;
using UnityEngine;

namespace Behaviours
{
    public enum Arena
    {
        Arena1,
        Arena2,
        Arena3
    }
    public class MapBossHolderBehaviour : MonoBehaviour
    {
        public Arena ArenaType;
        public event Action OnEnter;
        public bool IsEntered;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out DrumCharacterBehaviour drummer) || other.TryGetComponent(out GuitaristCharacterBehaviour guitarist))
            {
                IsEntered = true;
                OnEnter?.Invoke();
            }
        }
    }
}
