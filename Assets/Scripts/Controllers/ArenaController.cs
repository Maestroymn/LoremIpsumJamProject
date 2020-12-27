using System.Collections;
using System.Collections.Generic;
using Behaviours;
using UnityEngine;

namespace Controllers
{
    public class ArenaController : MonoBehaviour
    {
        [SerializeField] private List<DrumBubbleSpawner> _drumBubbleSpawners;
        [SerializeField] private List<DrumBubbleSpawner> _guitarBubbleSpawners;
        [SerializeField] private Animator BossEntryAnimator;
        [SerializeField] private GameObject EntryParent;

        public void Initialize()
        {
            StartCoroutine(WaitUntilEntryFinish());
        }
        
        public void StartArenaRoutine()
        {
            _drumBubbleSpawners.ForEach(x=>x.StartSpawning());
            _guitarBubbleSpawners.ForEach(y=>y.StartSpawning());
        }

        private IEnumerator WaitUntilEntryFinish()
        {
            yield return new WaitForSeconds(BossEntryAnimator.GetCurrentAnimatorStateInfo(0).length+BossEntryAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime);
            LeanTween.scale(EntryParent.GetComponent<RectTransform>(),Vector3.zero,.4f).setOnComplete(StartArenaRoutine);
        }
    }
}
