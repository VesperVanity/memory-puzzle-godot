using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Card : Area2D
{
	
	public Label card_label;
	private List<Area2D> cards = new List<Area2D>();

	private bool is_mouse_hovering = false;

	private int card_clicked_counter = 0;
	public override void _Ready()
	{
		card_label = GetNode<Label>("card_label");
		card_label.Visible = false;
		
	}

	//All the logic and counters here simply do not work
	//Because each has their own counter while I use the counter
	//As a singular entity to manipulate, meaning we need
	//A new way of figuring it out
	public override void _Process(double delta)
	{
		
		if(is_mouse_hovering)
		{
			if(Input.IsMouseButtonPressed(MouseButton.Left))
			{
				card_label.Visible = true;
				card_clicked_counter++;
				GD.Print(card_clicked_counter);
				cards.Add(this);
			}
		}

		if(card_clicked_counter == 2)
		{
			foreach(Area2D card in cards)
			{
				card_label.Visible = false;
			}
			card_clicked_counter = 0;
		}
	}

	private void _on_mouse_entered()
	{
		is_mouse_hovering = true;
	}

	private void _on_mouse_exited()
	{
		is_mouse_hovering = false;
	}
	

}
