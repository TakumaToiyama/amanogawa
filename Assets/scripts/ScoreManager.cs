using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text tMP_Text;
    private int score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tMP_Text.text = "Score: " + score;
    }

    public void addScore() {
        score++;
        updateScoreText();
    }

    private void updateScoreText() {

    }

    // Update is called once per frame
    void Update()
    {
        tMP_Text.text = "Score: " + score;
    }
}
