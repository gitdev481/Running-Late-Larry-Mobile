using UnityEngine;
using System.Collections;

public class WinPanel : MonoBehaviour {

	public AudioSource winSound;

	void Start () {
		winSound.Play ();
	}
}