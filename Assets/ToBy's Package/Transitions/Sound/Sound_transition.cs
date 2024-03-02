using UnityEngine;

public class Sound_transition : Singleton<Sound_transition>
{
    Animator Sound_anim;

    void Start()
    {
        Sound_anim = GetComponentInChildren<Animator>();
    }
    public void soundTransitions()
    {
        Sound_anim.SetTrigger("FadeOut");
    }
}
