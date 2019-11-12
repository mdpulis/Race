﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

namespace EAE.Race.Scoring
{
    public class LeaderBoardManager : MonoBehaviour
    {

        private string path = "Assets/Resources/Leaderboard/score.txt";      
        Dictionary<string,float>scores;
        private string currentLevel;
        
        // Start is called before the first frame update
        void Start()
        {
            DontDestroyOnLoad(this);
            scores = new Dictionary<string, float>();            
            ReadScores();            
        }

        // Update is called once per frame
        void Update()
        {

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
                    scores.Add(splits[1], float.Parse(splits[0]));                    
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
                StringBuilder sb = new StringBuilder();
                foreach(KeyValuePair<string,float> pair in scores)
                {
                    sb.Append(pair.Key + "," + pair.Value);
                }
                writer.Write(sb.ToString());
                writer.Close();
            }
            catch (System.Exception e)
            {
                Debug.Log("File Write Error: " + e.Message);
            }

        }
        public void setCurrentLevelID(string levelName)
        {
            currentLevel = levelName;
        }
        public void RecordScore(float score)
        {
            if(scores.ContainsKey(currentLevel))
            {
                if(scores[currentLevel]<score)
                {
                    scores[currentLevel] = score;
                }
            }
            scores.Add(currentLevel,score);
        }

        public float getHighScoreForLevel(string levelName)
        {
            if (scores.ContainsKey(levelName))
            {
               return scores[levelName];
            }

            return float.MaxValue;
        }

        public string getHighScoreStringForLevel(string levelName)
        {
            if(scores.ContainsKey(levelName))
            {
                return Util.SecondsToMinutesSeconds(scores[levelName]);
            }

            return "No Level Data Found";
        }

    }


}
