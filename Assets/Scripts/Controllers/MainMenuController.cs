using System;
using UnityEngine;

namespace Controllers
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private SkylineScroller _skylineScroller;

        private void Awake()
        {
            _skylineScroller.Initialize();
        }
    }
}
