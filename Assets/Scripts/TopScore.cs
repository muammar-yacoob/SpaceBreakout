using UnityEngine;
using UnityEngine.UI;

public class TopScore : MonoBehaviour
{
    [SerializeField] Text Label;

    private void Awake()
    {
        var n = GamePlay.Instance.Score;
        Label.text += n.ToString();
    }
}