using UnityEngine;

public class SingletonMono<T> : MonoBehaviour
    where T : SingletonMono<T>
{
    private static T s_instance;
    private static bool s_isQuitting;

    public static T Instance
    {
        get
        {
            if (s_isQuitting)
                return null;

            if (s_instance == null)
            {
                s_instance = FindFirstObjectByType<T>();

                if (s_instance == null)
                {
                    GameObject obj = new GameObject(typeof(T).Name);
                    s_instance = obj.AddComponent<T>();
                }
            }

            return s_instance;
        }
    }

    protected virtual void Awake()
    {
        if (s_instance != null && s_instance != this)
        {
            Destroy(gameObject);
            return;
        }

        s_instance = (T)this;
    }

    protected virtual void OnApplicationQuit()
    {
        s_isQuitting = true;
    }

    protected virtual void OnDestroy()
    {
        if (s_instance == this)
            s_instance = null;
    }
}