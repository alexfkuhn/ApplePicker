using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public Text highScore;
    public Text yourScore;
    public Text beatHighScore;

    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        // high score controls
        highScore.text = "HIGH SCORE: ";
        int h_score = 0;
        if(PlayerPrefs.HasKey("HighScore")){
            h_score = PlayerPrefs.GetInt("HighScore");
            highScore.text += h_score.ToString();
        }

        // your score controls
        yourScore.text = "YOUR SCORE: ";
        int y_score;
        y_score = Basket.scoreNum;
        yourScore.text += y_score.ToString();

        // Beat high score?
        if (y_score == h_score){
            beatHighScore.text = "YOU SET THE HIGH SCORE";
        }
    }

    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        
    }

}
