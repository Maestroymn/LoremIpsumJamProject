using System.Collections;
using System.Collections.Generic;
using Behaviours;
using UnityEngine;

namespace Controllers
{
    public class ArenaController : MonoBehaviour
    {
        [SerializeField] private List<DrumBubbleSpawner> _drumBubbleSpawners;
        [SerializeField] private List<GuitarBubbleSpawner> _guitarBubbleSpawners;
        [SerializeField] private Animator BossEntryAnimator;
        [SerializeField] private GameObject EntryParent;
        [SerializeField] private GuitaristCharacterBehaviour _guitaristCharacter;
        [SerializeField] private DrumCharacterBehaviour _drumCharacterBehaviour;
        public bool OpenRow1G, OpenRow2G, OpenRow3G,OpenRow1D, OpenRow2D, OpenRow3D;
        public void Initialize()
        {
            StartCoroutine(WaitUntilEntryFinish());
        }
        
        public void StartArenaRoutine()
        {
            _guitaristCharacter.Initialize();
            _drumCharacterBehaviour.Initialize();
            if (OpenRow1D)
            {
                _drumBubbleSpawners[0].StartSpawning();
            }
            if (OpenRow2D)
            {
                _drumBubbleSpawners[1].StartSpawning();
            }
            if (OpenRow3D)
            {
                _drumBubbleSpawners[2].StartSpawning();
            }
            if (OpenRow1G)
            {
                _guitarBubbleSpawners[0].StartSpawning();
            }
            if (OpenRow2G)
            {
                _guitarBubbleSpawners[1].StartSpawning();
            }
            if (OpenRow3G)
            {
                _guitarBubbleSpawners[2].StartSpawning();
            }
        }

        private IEnumerator WaitUntilEntryFinish()
        {
            yield return new WaitForSeconds(BossEntryAnimator.GetCurrentAnimatorStateInfo(0).length+BossEntryAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime);
            LeanTween.scale(EntryParent.GetComponent<RectTransform>(),Vector3.zero,.4f).setOnComplete(StartArenaRoutine);
        }
    }
}
