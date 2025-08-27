using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            // ���� ������ �����ǵ���
            if (instance == null)
            {
                var singletonGO = new GameObject($"{typeof(T)}");
                instance = singletonGO.AddComponent<T>(); // Awake() ����
            }
            return instance;
        }
    }

    protected virtual void Awake() // ���� �÷� ���Ҵٸ� �ٷ� ���� �� ��
    {
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject); // �� ��ȯ���� ����
        }
        else if (instance != this)
        {
            // ����� �� �ϳ��� �ߺ� ������ ���� ��������, Ȥ�� �𸣴ϱ�
            Debug.LogWarning($"�ߺ��� {typeof(T).Name} �̱����� �߰ߵǾ� �ı��˴ϴ�.");
            Destroy(gameObject); // �ߺ� ����
        }
    }

    public virtual void Release() // ��õ ���� ���, �� ��ȯ �� �ش� �Ŵ����� �ı��� ���� �����״ϱ�
    {
        if (instance == null) return;
        if (instance.gameObject) Destroy(instance.gameObject);

        instance = null;
    }
    protected virtual void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
}
