using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class LeaderBoardManager : MonoBehaviour
{

    private string path = "Assets/Resources/Leaderboard/score.txt";
    public int numScores = 5;
    List<score> scores = new List<score>();
    // Start is called before the first frame update
    void Start()
    {
        ReadScores();
        Debug.Log(GetDisplayStringForAllScores());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public string GetDisplayStringForAllScores()
    {
        return GetDisplayStringForScores(0);
    }

    public string GetDisplayStringForScores(int scoresToCount=0)
    {
        if(scoresToCount == 0)
        {
            scoresToCount = numScores;
        }

        scoresToCount = Mathf.Min(scoresToCount, numScores);
        SortAndTruncateScores();
        StringBuilder sb = new StringBuilder();

        int count = 0;

        foreach (score current in scores)
        {
            if (count > scoresToCount) { break; }
            sb.Append(current.GetDisplayFormatString());
            count++;
        }
        return sb.ToString();
    }

    private void ReadScores()
    {
        try
        {
            scores.Clear();
            StreamReader reader = new StreamReader(path);
            string line;// = reader.ReadLine();
            while ((line = reader.ReadLine()) != null)
            {
                string[] splits = line.Split(',');
                scores.Add(new score(int.Parse(splits[1]), splits[0]));
            }
            reader.Close();
        }
        catch (System.Exception e)
        {
            Debug.Log("File Read error:" + e.Message);
        }

    }

    public void WriteScores()
    {
        try
        {
            StreamWriter writer = new StreamWriter(path, false);
            SortAndTruncateScores();
            StringBuilder sb = new StringBuilder();
            foreach (score current in scores)
            {
                sb.Append(current.GetFileFormatString());
            }
            writer.Write(sb.ToString());
            writer.Close();
        }
        catch (System.Exception e)
        {
            Debug.Log("File Write Error: " + e.Message);
        }

    }

    void SortAndTruncateScores()
    {
        scores.Sort(delegate (score s1, score s2) { return s1.scoreVal.CompareTo(s2.scoreVal); });
        int toRemove = scores.Count - numScores;
        if (toRemove > 0)
        {
            scores.RemoveRange(numScores, toRemove);
        }
    }

    public void RecordScore(string name, int score)
    {
        scores.Add(new score(score, name));
    }

    public bool IsHighScore(int score)
    {
        SortAndTruncateScores();
        if (scores.Count < numScores) { return true; }
        return score < scores[scores.Count - 1].scoreVal;

    }
}
class score
{
    public float scoreVal;
    public string name;
    public score(float time, string name)
    {
        this.scoreVal = time;
        this.name = name;
    }
    private string SecondsToMinutesSeconds(float seconds)
    {
        int minutes =Mathf.FloorToInt(seconds / 60);
        seconds %= 60;
        return minutes.ToString("00") + "m:" + seconds.ToString("00")+"s";
    }

    public string GetDisplayFormatString()
    {
        return name + "| " + SecondsToMinutesSeconds(scoreVal) + "\n";
    }
    public string GetFileFormatString()
    {
        return name + "," + scoreVal + "\n";
    }

}
