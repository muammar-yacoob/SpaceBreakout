using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlay : MonoBehaviour
{

    [SerializeField] uint _maxLives = 3;
    [SerializeField] BallController ballPrefab;
    [SerializeField] PlayerController playerPrefab;
    [SerializeField] TextMeshProUGUI getReadyLabel;
    [SerializeField] [Tooltip("1 to Win, 2 to lose")] bool debugGame;

    uint _score = 0;
    uint _bricksCount;

    static uint _livesRemaining;
    public uint LivesRemaining => _livesRemaining;

    public static event Action<uint> OnBrickHit = delegate { };
    public static event Action<uint> OnDamage = delegate { };


    static GamePlay _instance;
    private BallController ball;
    private PlayerController player;

    public static GamePlay Instance => _instance;
    public uint Score => _score;


    private void Awake()
    {
        #region singleton
        if (_instance != null)
            Destroy(this.gameObject);

        _instance = this;
        #endregion

        ResetGameValues();
        InstantiatePrefabs();
        StartCoroutine(StartGame(3));
    }

    private void ResetGameValues()
    {
        _score = 0;
        _livesRemaining = _maxLives;
        _bricksCount = (uint)FindObjectsOfType<BrickController>().Length;
    }

    private void InstantiatePrefabs()
    {
        if (ballPrefab == null)
            Debug.LogError("Ball Prefab is Missing");
        else
            ball = Instantiate(ballPrefab, Vector2.zero, Quaternion.identity);

        if (playerPrefab == null)
            Debug.LogError("Player Prefab is Missing");
        else
            player = Instantiate(playerPrefab, Vector2.up * -4, Quaternion.identity);
    }

    private IEnumerator StartGame(int startDelay)
    {
        getReadyLabel.enabled = true;
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        ball.transform.position = Vector2.zero;

        int elapsed = startDelay;

        while (elapsed > 0)
        {
            getReadyLabel.text = $"Get Ready {elapsed}";
            elapsed--;
            yield return new WaitForSeconds(1f);
        }

        getReadyLabel.enabled = false;
        ball.Kick();
    }

    public void BrickHit(uint scoreValue)
    {
        _score += scoreValue;
        if (_score >= _bricksCount)
            Win();

        OnBrickHit(_score);
    }

    private void Win() => SceneManager.LoadScene("Win");

    public void DealDamage(uint damageAmount)
    {
        _livesRemaining -= damageAmount;

        if (_livesRemaining <= 0)
            Lose();
        else
        {
            OnDamage(_livesRemaining);
            StartCoroutine(StartGame(3));
        }
    }

    private static void Lose() => SceneManager.LoadScene("Lose");

    private void Update() => GameDebugger();

    private void GameDebugger()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Win();
        if (Input.GetKeyDown(KeyCode.Alpha2))
            Lose();
    }
}