using UnityEngine;

namespace Behaviours
{
    public class MainMenuSoundBarBehaviour : MonoBehaviour
    {
        [SerializeField] private float _maxXValue,_minXValue;
        private LTDescr _descr;
        private float _lerpedX,_currentX;
        private bool _changing;
        
        public void ChangeBarScale()
        {
            if(!_changing)
            {
                _changing = true;
                _currentX = Random.Range(_minXValue, _maxXValue);
                float percentage = _currentX / _maxXValue;
                _lerpedX = Mathf.Lerp(_minXValue, _maxXValue, percentage);
                _descr = LeanTween.scaleX(gameObject, _lerpedX, 0.1f).setOnComplete(() => { _changing = false; });
            }
        }

        public void SongPlay()
        {
            
        }
    }
}
