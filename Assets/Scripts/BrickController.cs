using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BrickController : MonoBehaviour
{
    [SerializeField] uint scoreValue = 1;
    [SerializeField] Color[] brickColors;

    [SerializeField] AudioSource SFXAudioSource;
    [SerializeField] AudioClip sfx;
    private Color material;

    GamePlay gamePlay;


    private void Start()
    {
        gamePlay = GamePlay.Instance;
        var rend = GetComponent<MeshRenderer>();
        rend.material.SetColor("_Color", GetColor());
    }

    Color GetColor()
    {
        if (brickColors.Length == 0)
            return Color.magenta;

        int index = Random.Range(0, brickColors.Length);
        return brickColors[index];
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.gameObject.GetComponent<BallController>();
        if (player == null)
            return;
        
            gamePlay.BrickHit(scoreValue);

            if (SFXAudioSource != null && sfx != null)
                SFXAudioSource.PlayOneShot(sfx);

            Destroy(gameObject);
    }
}