using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.IO;
using System;

public class Client : MonoBehaviour
{

    public string clientName;

    public bool ishost;

    private bool socketReady;
    private TcpClient socket;
    private NetworkStream stream;
    private StreamWriter writer;
    private StreamReader reader;


    private List<GameClient> players = new List<GameClient>();

	private void Start()
	{
        DontDestroyOnLoad(gameObject);
	}




	public bool ConnectToServer(string host, int port){

        if (socketReady){
            return false;
        }
        try{
            socket = new TcpClient(host, port);
            stream = socket.GetStream();
            writer = new StreamWriter(stream);
            reader = new StreamReader(stream);

            socketReady = true;
        }
        catch (Exception e){
            Debug.Log("Socket error " + e.Message);
        }
        return socketReady;

    }

	private void Update()
	{
        if (socketReady){
            if(stream.DataAvailable){
                string data = reader.ReadLine();
                if (data != null)
                    OnInComingData(data);
            }
        }
	}




	private void OnInComingData(string data){
        // read messages from the server
        Debug.Log("Client: " + data);
        string[] aData = data.Split('|');

        switch (aData[0]){

            case "SWHO":
                for (int i = 1; i < aData.Length - 1; i++){
                    UserConnected(aData[i], false);
                }
                Send("CWHO|" + clientName + "|" + ((ishost)?1:0).ToString());
                break;
            case "SCNN":
                UserConnected(aData[1], false);
                break;
            case "SMOV":
                Controller.Instance.spawn(GameObject.Find(aData[1]),GameObject.Find(aData[2]),int.Parse(aData[3]));
                break;
			case "SCAS":
				Debug.Log (aData [1]);
				Debug.Log (float.Parse (aData [2]));
				//FortController.Instance.Accelerating (GameObject.Find (aData [1]), float.Parse (aData [2]));
				GameObject g = GameObject.Find (aData [1]);
				FortController f = g.GetComponent<FortController>();
				f.Accelerating (float.Parse (aData [2]));
				break;
			case "WLP":
				if (aData [1] == "white") {
					Controller.Instance.whiteWin++;
					Debug.Log (Controller.Instance.whiteWin);
					Debug.Log (Controller.Instance.blackWin);
				} else {
					Controller.Instance.blackWin++;
					Debug.Log (Controller.Instance.whiteWin);
					Debug.Log (Controller.Instance.blackWin);
				}
				break;
			case "WLM":
				if (aData [1] == "white") {
					Controller.Instance.whiteWin--;
					Debug.Log (Controller.Instance.whiteWin);
					Debug.Log (Controller.Instance.blackWin);
				} else {
					Controller.Instance.blackWin--;
					Debug.Log (Controller.Instance.whiteWin);
					Debug.Log (Controller.Instance.blackWin);
				}
				break;
        }	
    }



    private void UserConnected(string name, bool host){
        GameClient c = new GameClient();
        c.name = name;


        players.Add(c);

        if (players.Count == 2)
            GameManager2.Instance.StartGame();

    }






    private void CloseSocket(){
        if (!socketReady)
            return;

        writer.Close();
        reader.Close();
        socket.Close();
        socketReady = false;
    }

	private void OnApplicationQuit()
	{
        CloseSocket();
	}

	private void OnDisable()
	{
        CloseSocket();
	}

	public void Send(string data){
        if (!socketReady)
            return;
        writer.WriteLine(data);
        writer.Flush();
    }



}


public class GameClient{

    public string name;
    public bool isHost;


}