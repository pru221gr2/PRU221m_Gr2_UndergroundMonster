using System.Linq;
using UnityEngine;

public class ScoreUi : MonoBehaviour
{
    public ScoreRowUi scoreRow;

    private void Start()
    {
        var scoreData = FileManager.Instance.ReadPlayerScore();

        for (int i = 0; i < scoreData.Count; i++)
        {
            var row = Instantiate(scoreRow, transform).GetComponent<ScoreRowUi>();
            row.rank.text = string.Format("{0}", (i + 1));
            row.player.text = CorrectionData(scoreData.ElementAtOrDefault(i).Key, "Unkown") ;
            row.score.text = CorrectionData(scoreData.ElementAtOrDefault(i).Value, "0") ;
        }
    }

    private string CorrectionData(string input, string defaultData)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return defaultData;
        }

        return input;
    }
}

