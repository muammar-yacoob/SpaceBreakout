using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class UIScore : MonoBehaviour
{
    TextMeshProUGUI uiText;

    private void OnEnable() => GamePlay.OnBrickHit += Handle_OnBrickHit;
    private void OnDisable() => GamePlay.OnBrickHit -= Handle_OnBrickHit;

    private void Start()
    {
        uiText = GetComponent<TextMeshProUGUI>();
        int score = 0;
        uiText.text = score.ToString("D3");
    }



    private void Handle_OnBrickHit(uint score)
    {
        uiText.text = score.ToString("D3");
    }
}
