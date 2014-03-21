using UnityEngine;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public abstract class SocketController : Controller {
	public int port;
	
	private TcpListener listener;
	
	void Awake() {
		listener = new TcpListener(IPAddress.Any, port);
		listener.Start();
		
		Thread t = new Thread(new ThreadStart(ReceiveCommands));
		t.Start();
	}
	
	private void ReceiveCommands() {
		while(true) {
			Socket socket = listener.AcceptSocket();
			
			Stream stream = new NetworkStream(socket);
			StreamReader reader = new StreamReader(stream);
			
			string command = reader.ReadLine();
			ExecuteCommand(command);

			reader.Close();
			stream.Close();
			socket.Close();
		}
	}
	
	protected abstract void ExecuteCommand (string command);
	
}
