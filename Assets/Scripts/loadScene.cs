using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class loadScene : MonoBehaviour
{
    public Slider loadingBar;
    public Text progressTxt;
    private AsyncOperation op;
    public void Load(string name)
    {
        StartCoroutine(LoadAsync(name));
    }

    IEnumerator LoadAsync(string name)
    {
        op = SceneManager.LoadSceneAsync(name);

        loadingBar.gameObject.SetActive(true);

        while (!op.isDone)
        {
            float progress = Mathf.Clamp01(op.progress / .9f);
            loadingBar.value = progress;
            progressTxt.text = progress * 100f + "%";
            yield return null;
        }
    }
}
