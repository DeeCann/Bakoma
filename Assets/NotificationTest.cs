using UnityEngine;
using System.Collections;

public class NotificationTest : MonoBehaviour {

	void Start(){
		LocalNotification.SendRepeatingNotification(3, 5, 604800, "SuperBakusie 2", "Wróć do krainy Bakusia i zmierz się z nowymi zagadkami!", new Color32(0xff, 0x44, 0x44, 255));
		}

}
