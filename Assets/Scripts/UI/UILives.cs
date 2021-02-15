using TMPro;
using UnityEngine;

public class UILives : MonoBehaviour
{
    TextMeshProUGUI uiText;
    private GamePlay gamePlay;

    private void OnEnable() => GamePlay.OnDamage += Handle_OnDamage;
    private void OnDisable() => GamePlay.OnDamage -= Handle_OnDamage;

    private void Start()
    {
        uiText = GetComponent<TextMeshProUGUI>();
        gamePlay = GamePlay.Instance;
        uint lives = gamePlay.LivesRemaining;
        uiText.text = lives.ToString("D0");
    }



    private void Handle_OnDamage(uint livesRemaining)
    {
        uiText.text = livesRemaining.ToString("D0");
    }
}
