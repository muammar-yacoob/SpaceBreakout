using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoading : MonoBehaviour
{
    [SerializeField] RectTransform loadingRect;
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI percentageText;

    Animator anim;
    const string START = "Start";

    private void Awake()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        loadingRect.gameObject.SetActive(false);
        anim = loadingRect.GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        UIButtonStart.OnLoadLevel += Handle_LoadLevel;
    }



    private void OnDisable()
    {
        UIButtonStart.OnLoadLevel -= Handle_LoadLevel;
    }

    private void Handle_LoadLevel(int index)
    {
        loadingRect.gameObject.SetActive(true);
        if (anim != null)
            anim.SetTrigger(START);

        float delay = 3f;// anim.GetCurrentAnimatorStateInfo(0).length;
        StartCoroutine(LoadLevel(index, delay));
    }

    IEnumerator LoadLevel(int index, float delay)
    {
        float progress = 0;
        percentageText.text = progress.ToString("P");//.ToString("%");
        slider.value = 0;

        #region Scene Loader
        /*        yield return new WaitForSeconds(delay);
                AsyncOperation operation = SceneManager.LoadSceneAsync(index);

                float progress = 0;
                while (!operation.isDone)
                {

                    progress = Mathf.Clamp01(operation.progress / 0.9f);
                    Debug.Log(progress);
                    percentageText.text = progress.ToString("P0");
                    slider.value = progress;

                }*/
        #endregion

        #region fake scene loader

        while (progress < 1)
        {
            progress += 0.01f;
            progress = Mathf.Clamp01(progress);
            percentageText.text = progress.ToString("P0");
            slider.value = progress;
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(index);
        #endregion
    }


}
