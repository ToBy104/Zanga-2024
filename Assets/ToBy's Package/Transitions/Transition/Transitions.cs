using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transitions : Singleton<Transitions>
{
    Animator transition_anim;

    void Start() => transition_anim = GetComponentInChildren<Animator>();

    public void LoadScene(int Sceneindex) => StartCoroutine(_LoadScene(Sceneindex));
    IEnumerator _LoadScene(int _Sceneindex)
    {
        transition_anim.Play("_in");
        if(Sound_transition.instance != null)
            Sound_transition.instance.soundTransitions();

        yield return new WaitForSeconds(1);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(_Sceneindex);

        yield return new WaitUntil(() => asyncOperation.isDone);
        transition_anim.Play("_out");
    }

    
}
