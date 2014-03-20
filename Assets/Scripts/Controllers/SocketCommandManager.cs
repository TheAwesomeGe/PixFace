using UnityEngine;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class SocketCommandManager : CommandManager {
	public int port;
	
	private TcpListener listener;
	
	void Start() {
		listener = new TcpListener(IPAddress.Any, port);
		listener.Start();
		
		Thread t = new Thread(new ThreadStart(ReceiveCommands));
		t.Start();
	}
	
	protected void ReceiveCommands() {
		while(true) {
			Socket socket = listener.AcceptSocket();
			
			Stream stream = new NetworkStream(socket);
			
			StreamReader reader = new StreamReader(stream);
			
			string command = reader.ReadLine();
			
			ParseCommand(command);
			
			stream.Close();
			
			socket.Close ();
		}
	}
	
	private void ParseCommand(string command) {
	}
	
}
