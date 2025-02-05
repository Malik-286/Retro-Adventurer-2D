﻿using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace hardartcore.CasualGUI
{
    public class Dialog : MonoBehaviour
    {
        public float AnimDuration = 0.2f;
        public GameObject DialogContent;

        public void ShowDialog()
        {
            DialogContent.SetActive(false);
            gameObject.SetActive(true);
            DialogContent.transform.localScale = Vector3.zero;
            DialogContent.SetActive(true);
            DialogContent.transform.DOScale(Vector3.one, AnimDuration);
        }

        public void HideDialog()
        {
            DialogContent.transform.DOScale(Vector3.zero, AnimDuration).OnComplete(() => gameObject.SetActive(false));
        }
    }
}
