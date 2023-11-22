namespace CheetahToolbox;

using System;
using System.Linq;
using CheetahApp;

public class CheetahToolbox() : ConsoleApp(new(), new())
{
	private ConsoleApp? _app;

	public override void Start()
	{
		_app = new ConsoleApp(new(), new());
		_app.Start();
	}

	public override void Update()
	{
	}

	public override void Close()
	{
		_app?.Close();
	}
}