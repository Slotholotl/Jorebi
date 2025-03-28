using UnityEngine;
using TMPro;

public class KeepScore : MonoBehaviour
{
    private TMP_Text scoreField;
    private int score = 0;

    void Start()
    {
        // Haal het TextMeshPro tekstveld op
        scoreField = GetComponent<TMP_Text>();

        // Zet de score op 0 bij de start van het spel
        score = 0;
        scoreField.text = score.ToString();
    }

    // Methode om de score te verhogen
    public void AddScore(int add)
    {
        score += add;
        scoreField.text = score.ToString(); // Werk de score in het textveld bij
    }
}
