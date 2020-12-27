using System.Collections;
using System.Collections.Generic;
using Controllers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Behaviours
{
    public class GuitarBubbleSpawner : MonoBehaviour
    {
        [SerializeField] private GuitaristCharacterBehaviour _guitaristCharacter;
        [SerializeField] private List<GuitarBubbleBehaviour> _bubblePrefabs;
        [SerializeField] private BubbleController _bubbleController;
        public float minSpawnThreshold,maxSpawnThreshold;
        
        public void StartSpawning()
        {
            StartCoroutine(Spawner());
        }

        private IEnumerator Spawner()
        {
            while (_guitaristCharacter.CharacterSituation == CharacterSituation.OnArena)
            {
                GuitarBubbleBehaviour bubble = Instantiate(_bubblePrefabs[Random.Range(0, _bubblePrefabs.Count)],transform.position,Quaternion.identity);
                bubble.guitarist = _guitaristCharacter;
                _bubbleController.bubbles.Add(bubble.gameObject);
                yield return new WaitForSeconds(Random.Range(minSpawnThreshold,maxSpawnThreshold));
            }
        }
    }
}
