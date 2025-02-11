using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Main : Node2D
{
	[Signal] public delegate void CheckPairEventHandler();
	public int card_clicked_counter = 0;
	public override void _Ready()
	{	
		
	}

	
	public override void _Process(double delta)
	{
		if(card_clicked_counter == 2)
		{
			EmitSignal("CheckPair");
		}
	}



}
