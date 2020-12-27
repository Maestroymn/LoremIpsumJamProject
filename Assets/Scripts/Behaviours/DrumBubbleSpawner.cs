﻿using System.Collections;
using System.Collections.Generic;
using Controllers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Behaviours
{
    public class DrumBubbleSpawner : MonoBehaviour
    {
        [SerializeField] private DrumCharacterBehaviour _drummer;
        [SerializeField] private List<DrumBubbleBehaviour> _bubblePrefabs;
        [SerializeField] private BubbleController _bubbleController;
        public float minSpawnThreshold,maxSpawnThreshold;
        
        public void StartSpawning()
        {
            StartCoroutine(Spawner());
        }

        private IEnumerator Spawner()
        {
            while (_drummer.CharacterSituation == CharacterSituation.OnArena)
            {
                DrumBubbleBehaviour bubble = Instantiate(_bubblePrefabs[Random.Range(0, _bubblePrefabs.Count)],transform.position,Quaternion.identity);
                bubble.drummer = _drummer;
                _bubbleController.bubbles.Add(bubble.gameObject);
                yield return new WaitForSeconds(Random.Range(minSpawnThreshold,maxSpawnThreshold));
            }
        }
    }
}
