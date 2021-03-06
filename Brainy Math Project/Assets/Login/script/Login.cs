﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Login : MonoBehaviour {

	public static string username = "";
	public static string password = "";

	string userUrl = "lrgs.ftsm.ukm.my/users/a150737/game/login.php";

	public GameObject window;
	public Text messageField;
	private bool msg = false;

	public void Start (){
		username = "";
		password = "";
	}

	public void Show(string message){
		if (msg == true) {
			messageField.text = message;
			window.SetActive (true);
		}
	}

	public void Hide(){
		window.SetActive (false);
	}
		
	public void getUsername (string getname){
		username = getname;
	}

	public void getPassword (string getpass){
		password= getpass;
	}
		
	public void Mula (){
		if (username == "" && password == "") {
			msg = true;
			Show ("Please Insert Username");
		} else {
		StartCoroutine ("login");
		}
	}
		

		IEnumerator login(){

			WWWForm form = new WWWForm ();
			form.AddField ("usernamePost", username);
			form.AddField ("passwordPost", password);
			WWW	www = new WWW (userUrl, form);

			yield return www;
			
			string x = www.text;

		if (x == "X") {
			msg = true;
			Show ("Wrong username and password!");

		}
		else if(x == "OK"){
			setPref(username);
			Debug.Log (www.text);
			SceneManager.LoadScene ("MainMenu");
		}

		else if(x =="No this username"){
			msg = true;

			Show ("Username not registered, please register first!");
		}

		}

	public void setPref(string id)
	{
		GameObject thePlayer = GameObject.Find("prefManager");
		prefmanager playerScript = thePlayer.GetComponent<prefmanager>();
		playerScript.userID = id;
		Debug.Log ("save_user" + playerScript.userID);

	}

	}	