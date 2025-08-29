using UnityEngine;

public class uiTransition : MonoBehaviour
{
    // to set transition function to one-parametered funciton
    private CanvasGroup fromGroup;

    private void Awake()
    {
        fromGroup = GetComponent<CanvasGroup>();
    }
    public void TransitionTo(CanvasGroup To)
    {
               uiManager.Instance.Transition(fromGroup, To);
    }
}