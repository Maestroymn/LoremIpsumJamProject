using Behaviours;
using Managers;
using UnityEngine;

namespace Controllers
{
    public class MapController : MonoBehaviour
    {
        [SerializeField] public MapBossHolderBehaviour _boss1, _boss2,_boss3;
        [SerializeField] private GameManager _gameManager;

        public void Initialize()
        {
            gameObject.SetActive(true);
            if(!_boss1.IsEntered)
            {
                _boss1.OnEnter += OnEnterArena;
            }
            if (!_boss2.IsEntered)
            {
                _boss2.OnEnter += OnEnterArena;
            }
            if (!_boss3.IsEntered)
            {
                _boss3.OnEnter += OnEnterArena;
            }
        }

        public void OnEnterArena()
        {
            if (_boss1.IsEntered)
            {
                _boss1.OnEnter -= OnEnterArena;
                _boss1.gameObject.SetActive(false);
                _gameManager.StartArena(_boss1.ArenaType);
            }
            else  if (_boss2.IsEntered)
            {
                _boss2.OnEnter -= OnEnterArena;
                _gameManager.StartArena(_boss2.ArenaType);
            }
            else  if (_boss3.IsEntered)
            {
                _boss3.OnEnter -= OnEnterArena;
                _gameManager.StartArena(_boss3.ArenaType);
            }
        }
    }
}
