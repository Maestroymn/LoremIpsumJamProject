﻿using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

namespace Behaviours
{
    public class BaseBossBehaviour : MonoBehaviour
    {
        [SerializeField] private HealthManager healthManager;
        [SerializeField] private List<string> bossEvent;
        [SerializeField] private Animator animator;
        [SerializeField] private DrumCharacterBehaviour drummer;
        [SerializeField] private GuitaristCharacterBehaviour guitarist;
        [HideInInspector] public int damageTaken;
        private static readonly int Die = Animator.StringToHash("Die");
        public event Action OnBossDead;

        public void Initialized()
        {
            healthManager.percentageReached += BossSpell;
            healthManager.OnDead += BossDead;
        }

        private void BossSpell(int currentEvent)
        {
            animator.SetTrigger(bossEvent[currentEvent]);
            //guitarist.DamageGuitarist();
        }

        public void DamageBoss()
        {
            healthManager.SetHealth(damageTaken,true);
        }

        public void BossDead()
        {
            animator.SetTrigger(Die);
            OnBossDead?.Invoke();
        }
        
        public void KillPlayer()
        {
            animator.SetTrigger(bossEvent[bossEvent.Count-1]);
        }
    }
}
