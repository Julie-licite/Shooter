using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{

    [SerializeField] private GameObject loadingScreen;

    [SerializeField]private string sceneToLoadName;

    public void LoadScene()
    {
        StartCoroutine(Load());
    
    }

    private IEnumerator Load()
    {
        var LoadingScreenInstance = Instantiate(loadingScreen);
        var loadingAnimator = LoadingScreenInstance.GetComponent<Animator>();
        var animationTime = loadingAnimator.GetCurrentAnimatorStateInfo(0).length;
        DontDestroyOnLoad(LoadingScreenInstance);
        var loading = SceneManager.LoadSceneAsync(sceneToLoadName);
        loading.allowSceneActivation = false;
        while (loading.progress < 0.9f)
        {
            yield return new WaitForSeconds(animationTime);
        }

        
        loadingAnimator.SetTrigger("LoadingEnd");
        loading.allowSceneActivation = true;
    }
}
