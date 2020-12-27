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
            _arenas[0].gameObject.SetActive(true);
            _arenas[0].OpenRow1D = true;
            _arenas[0].OpenRow1G = true;
            _arenas[0].Initialize();
        }
        public void StartArena2()
        {
            _arenas[1].gameObject.SetActive(true);
            _arenas[1].OpenRow1D = true;
            _arenas[1].OpenRow1G = true;
            _arenas[1].OpenRow2D = true;
            _arenas[1].OpenRow2G = true;
            _arenas[1].Initialize();
        }
        public void StartArena3()
        {
            _arenas[2].gameObject.SetActive(true);
            _arenas[2].OpenRow1D = true;
            _arenas[2].OpenRow1G = true;
            _arenas[2].OpenRow2D = true;
            _arenas[2].OpenRow2G = true;
            _arenas[2].OpenRow3D = true;
            _arenas[2].OpenRow3G = true;
            _arenas[2].Initialize();
        }
    }
}
