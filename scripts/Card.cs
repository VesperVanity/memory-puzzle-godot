using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Card : Area2D
{
	
	public Label card_label;
	public List<Area2D> cards = new List<Area2D>();

	public bool is_revealed = false;

	public override void _Ready()
	{
		card_label = GetNode<Label>("card_label");
		card_label.Visible = false;
		cards.Add(this);
	}

	//All the logic and counters here simply do not work
	//Because each has their own counter while I use the counter
	//As a singular entity to manipulate, meaning we need
	//A new way of figuring it out
	public override void _Process(double delta)
	{
		if(is_revealed)
		{
			card_label.Visible = true;
		}
		else if(is_revealed == false)
		{
			card_label.Visible = false;
		}
		
	}

	
	public void hide_all_cards()
	{
		is_revealed = false;
	}

}
