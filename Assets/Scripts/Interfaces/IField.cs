using UnityEngine;
using System.Collections;

public interface IField {
	
	/*
	 * UI ACTIONS
	 **/
	void OnHoldAction();
	
	void OnPressAction();

	void OnUnpressAction();

	void OnClikAction();


	/*
	 * GAMEPLAY ACTIONS
	 **/ 
	void OnObjectEnterAction();

	void OnObjectExitAction();

}
