using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardController : MonoBehaviour
{
    public Text name1;
    public Text score1;
    public Text name2;
    public Text score2;
    public Text name3;
    public Text score3;

    string[] names = new string[3];
    int[] scores;

    void InitializeScores(string level)
    {
        scores = new int[3];

        if (PlayerPrefs.HasKey(level + "score0"))
        {
            for (int i = 0; i < 3; i++)
            {
                scores[i] = PlayerPrefs.GetInt(level + "score" + i);
                names[i] = PlayerPrefs.GetString(level + "name" + i);
            }

            score1.text = scores[0].ToString();
            score2.text = scores[1].ToString();
            score3.text = scores[2].ToString();
            name1.text = names[0];
            name2.text = names[1];
            name3.text = names[2];
        }
        else
        {
            int score = 30;

            for (int i = 0; i < 3; i++)
            {
                scores[i] = score;
                score = score - 10;
            }

            names[0] = name1.text;
            names[1] = name2.text;
            names[2] = name3.text;
        }
    }

    public bool IsHighScore(string level, int score)
    {
        if (scores == null)
        {
            InitializeScores(level);
        }

        if (score > scores[scores.Length - 1])
        {
            return true;
        }
        return false;
    }

    public void AddScore(string level, string name, int score)
    {
        for (int i = scores.Length - 1; i >= 0; i--)
        {
            if (i > 0 && scores[i - 1] < score)
            {
                names[i] = names[i - 1];
                scores[i] = scores[i - 1];
            }
            else
            {
                names[i] = name;
                scores[i] = score;
                break;
            }
        }

        if (scores[0] != -1)
        {
            name1.text = names[0];
            score1.text = scores[0].ToString();
        }

        if (scores[1] != -1)
        {
            name2.text = names[1];
            score2.text = scores[1].ToString();
        }

        if (scores[2] != -1)
        {
            name3.text = names[2];
            score3.text = scores[2].ToString();
        }

        SaveLeaderboard(level);
    }

    void SaveLeaderboard(string level)
    {
        for (int i = 0; i < 3; i++)
        {
            if (scores[i] != -1)
            {
                PlayerPrefs.SetInt(level + "score" + i, scores[i]);
                PlayerPrefs.SetString(level + "name" + i, names[i]);
            }
        }

        PlayerPrefs.Save();
    }
}
