using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public bool destroyOnLoad;

    public static T instance;

    private void Awake()
    {
        registerSingleton();
    }

    /*
    private void Awake()
    {
        base.registerSingleton();

        // my Code
    }
    */

    protected void registerSingleton()
    {
        if (instance == null)
        {
            instance = this as T;

            if(destroyOnLoad)
                DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
}
