using System;
using UnityEngine;

namespace Controllers
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private SkylineScroller _skylineScroller;

        public void Initialize()
        {
            _skylineScroller.Initialize();
        }
    }
}
