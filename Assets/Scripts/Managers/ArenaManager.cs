using System.Collections.Generic;
using Controllers;
using UnityEngine;

namespace Managers
{
    public class ArenaManager : MonoBehaviour
    {
        [SerializeField] private List<ArenaController> _arenas;

        public void StartArena1()
        {
            _arenas[0].Initialize();
        }
        public void StartArena2()
        {
            _arenas[1].Initialize();
        }
        public void StartArena3()
        {
            _arenas[2].Initialize();
        }
    }
}
