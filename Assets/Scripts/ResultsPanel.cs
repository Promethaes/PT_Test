using UnityEngine;
using System.Collections.Generic;
namespace PtTest
{

    public class ResultsPanel : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] PlayerController _player;
        [SerializeField] TMPro.TextMeshProUGUI _shots;        
        [SerializeField] TMPro.TextMeshProUGUI _hits;
        [SerializeField] TMPro.TextMeshProUGUI _misses;


        private void OnEnable()
        {
            _shots.text = _player.GetTotalShots().ToString();
            _hits.text = _player.GetHitPercent().ToString("0.00");
            _misses.text = _player.GetMissPercent().ToString("0.00");
        }
    }
}
