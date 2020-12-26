using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Behaviours
{
    public class BaseBossBehaviour : MonoBehaviour
    {
        [SerializeField] private BossHealthManager healthManager;
        [SerializeField] private List<string> bossEvent;
        [SerializeField] private Animator animator;
        [SerializeField] private DrumCharacterBehaviour drummer;
        [SerializeField] private GuitaristCharacterBehaviour guitarist;
        public int damageTaken;
        

        public void Initialized()
        {
            healthManager.percentageReached += BossSpell;
        }

        private void BossSpell(int currentEvent)
        {
            animator.SetTrigger(bossEvent[currentEvent]);
        }

        public void DamageBoss()
        {
            healthManager.SetHealth(damageTaken);
        }

        public void Attack()
        {

        }
    
    }
}
