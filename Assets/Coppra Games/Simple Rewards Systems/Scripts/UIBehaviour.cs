using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Collections.Generic;

namespace CoppraGames
{
	public class UIBehaviourOptions
	{
		public int index;
		public string itemId;
	}

	public class UIBehaviour : MonoBehaviour
	{
		[HideInInspector]
		public RectTransform rectTransform;
		/* local vars */
		protected UIBehaviourOptions _options;

		public virtual void SetData(UIBehaviourOptions options)
		{
			//		Debug.Log("ComponentBase > SetOptions");
			this._options = options;
		}

		public virtual void Refresh()
		{

		}

		private void Awake()
		{
			this.rectTransform = this.GetComponent<RectTransform>();
		}

		private UIBehaviourOptions _GetOptions()
		{
			return this._options;
		}

		public T Up<T>()
		{
			return this.GetComponentInParent<T>();
		}

		public T Down<T>()
		{
			return this.GetComponentInChildren<T>();
		}


		public string GetItemId()
		{
			return this._options.itemId;
		}

	}
}