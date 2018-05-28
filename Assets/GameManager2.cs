using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


public class GameManager2 : MonoBehaviour {
    public static GameManager2 Instance { set; get; }

    public GameObject mainMenu;
    public GameObject serverMenu;
    public GameObject connectMenu;

    public GameObject serverPrefab;
    public GameObject clientPrefab;

    public InputField nameInput;



	// Use this for initialization
    private void Start () {

        Instance = this;
        serverMenu.SetActive(false);
        connectMenu.SetActive(false);
        DontDestroyOnLoad(gameObject);
	}
	
	
    public void ConnectButton(){

        mainMenu.SetActive(false);
        connectMenu.SetActive(true);
    }

    public void HostButton(){

        try{
            Server s = Instantiate(serverPrefab).GetComponent<Server>();
            s.Init();

            Client c = Instantiate(clientPrefab).GetComponent<Client>();
            c.clientName = nameInput.text;
            c.ishost = true;
            if (c.clientName == "")
                c.clientName = "Host";
            c.ConnectToServer("127.0.0.1", 6323);
        }
        catch(Exception e){
            Debug.Log(e.Message);
        }
        mainMenu.SetActive(false);
        serverMenu.SetActive(true);

    }

    public void ConnectToServerButton(){

        string hostAddress = GameObject.Find("HostInput").GetComponent<InputField>().text;

        if (hostAddress == ""){
            hostAddress = "127.0.0.1";
        }

        try{
            Client c = Instantiate(clientPrefab).GetComponent<Client>();
            c.clientName = nameInput.text;
            if (c.clientName == "")
                c.clientName = "Client";
            c.ConnectToServer(hostAddress, 6323);
            connectMenu.SetActive(false);

        }
        catch(Exception e){
            Debug.Log(e.Message);
        }

    }

    public void BackButton(){
        mainMenu.SetActive(true);
        serverMenu.SetActive(false);
        connectMenu.SetActive(false);

        Server server = FindObjectOfType<Server>();
        if (server != null)
            Destroy(server.gameObject);

        Client client = FindObjectOfType<Client>();
        if (client != null)
            Destroy(client.gameObject);
        
    }


    public void StartGame(){
        SceneManager.LoadScene("final 1.2");
    }

}
