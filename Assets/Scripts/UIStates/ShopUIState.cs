using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ShopUIState : AbstractState<UIManager>

{
	[SerializeField] 
	private GameObject shopCanvas;

	[SerializeField]
	private PlayerData playerData;
	
	public override void Enter(IAgent pAgent)
	{
		base.Enter(pAgent);
		shopCanvas.SetActive(true);
		shopCanvas.GetComponent<CanvasGroup>().DOFade(1, 0.5f);
	}

	public override void Exit(IAgent pAgent)
	{
		shopCanvas.SetActive(false);
		shopCanvas.GetComponent<CanvasGroup>().DOFade(0, 0.5f);
		base.Exit(pAgent);
	}
}
