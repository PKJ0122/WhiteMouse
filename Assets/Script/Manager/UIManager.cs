using System;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    bool _uiUp;
    public bool UiUp
    {
        get => _uiUp;
        set
        {
            _uiUp = value;
            OnUiUpChange?.Invoke(value);
        }
    }

    public Action<bool> OnUiUpChange;

    Dictionary<Type, UIBase> _uis = new Dictionary<Type, UIBase>();
    Stack<UIBase> _ui = new Stack<UIBase>();


    public void Register(UIBase ui)
    {
        if (!_uis.TryAdd(ui.GetType(), ui))
        {
            Debug.LogError($"{ui.gameObject.name}�� �ߺ����� ��ϵǰ� �ֽ��ϴ�.");
        }
    }

    public T Get<T>()
        where T : UIBase
    {
        return (T)_uis[typeof(T)];
    }

    public void PushUI(UIBase ui)
    {
        _ui.Push(ui);
        ui.SortingOrder = _ui.Count;
        UiUp = _ui.Count != 0;
    }

    public void PopUI(UIBase ui)
    {
        if (_ui.Peek() != ui)
        {
            Debug.LogWarning("�ش� UI�� �ֻ���� �ƴմϴ�.");
            return;
        }
        _ui.Pop();
        UiUp = _ui.Count != 0;
    }
}
