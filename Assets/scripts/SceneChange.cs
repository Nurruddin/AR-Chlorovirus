using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour
{
    public GameObject loadingPanel;
    public Slider slider;
    public void ChangeScene(int index){
        StartCoroutine(Loading_Coroutine(index));
    }

    public IEnumerator Loading_Coroutine(int index){
        loadingPanel.SetActive(true);
        slider.value = 0;

        AsyncOperation aOp = SceneManager.LoadSceneAsync(index);
        aOp.allowSceneActivation = false;
        float progress = 0f;
        while (!aOp.isDone)
        {
            progress = Mathf.MoveTowards(progress,aOp.progress, Time.deltaTime);
            slider.value = progress;
            if (progress >= 0.9f)
            {
                slider.value = 1;
                aOp.allowSceneActivation = true;
            }
            yield return null;
        }



    }
}
