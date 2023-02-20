using Model;
using TMPro;
using UnityEngine;

namespace UI.GridLayout
{
    public class CellController : MonoBehaviour
    {
        [SerializeField] private TMP_Text idText;
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private TMP_Text scoreText;
        
        public void SetCellText(LeaderboardEntry leaderboardEntry, int i)
        {
            idText.text = i + ".";
            nameText.text = leaderboardEntry.Name.Length > 9 ? leaderboardEntry.Name[..9] : leaderboardEntry.Name;
            scoreText.text = leaderboardEntry.Score;
        }
    }
}