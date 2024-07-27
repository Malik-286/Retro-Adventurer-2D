using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControllerUI : MonoBehaviour
{
    [SerializeField] int maxPage;
    [SerializeField] int currentPage;
    Vector3 targetPosition;
    [SerializeField] Vector3 pageStep;
    [SerializeField] RectTransform levelPagesReact;

    [SerializeField] float tweenTime;
    [SerializeField] LeanTweenType tweenType;

    void Awake()
    {
        ResetSwipeController();
    }

      void Start()
    {
        currentPage = 0;
    }

    void ResetSwipeController()
    {
        currentPage = 1;
        targetPosition = levelPagesReact.localPosition;
        Debug.Log("SwipeControllerUI Reset: currentPage = " + currentPage + ", targetPosition = " + targetPosition);
    }

    public void Next()
    {
        if (currentPage <= maxPage)
        {
            currentPage++;
            targetPosition += pageStep;
            Debug.Log("Next: Moving to page " + currentPage + ", targetPosition = " + targetPosition);
            MovePage();
        }
        else
        {
            Debug.Log("Next: Reached maxPage");
        }
    }

    public void Previous()
    {
        if (currentPage >= 1)
        {
            currentPage--;
            targetPosition -= pageStep;
            Debug.Log("Previous: Moving to page " + currentPage + ", targetPosition = " + targetPosition);
            MovePage();
        }
        else
        {
            Debug.Log("Previous: Reached minPage");
        }
    }

    void MovePage()
    {
        Debug.Log("MovePage: currentPage = " + currentPage + ", targetPosition = " + targetPosition);
        LeanTween.cancel(levelPagesReact.gameObject);
        LeanTween.moveLocal(levelPagesReact.gameObject, targetPosition, tweenTime).setEase(tweenType).setOnComplete(OnMoveComplete);
    }

    void OnMoveComplete()
    {
        Debug.Log("OnMoveComplete: currentPage = " + currentPage + ", targetPosition = " + targetPosition);
    }
}
