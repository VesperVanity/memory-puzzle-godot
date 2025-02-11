using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Card : Area2D
{	
	private Main main;
	private Card card;
	private Button button;
	public Label card_label;
	public List<Area2D> cards = new List<Area2D>();

	public bool is_revealed = false;

	public override void _Ready()
	{
		card_label = GetNode<Label>("card_label");
		button = GetNode<Button>("card_button");
		main = GetNode<Main>("../../../../main");
		card_label.Visible = false;
	
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

	private void _on_card_button_toggled(bool toggled_on)
	{
		if(toggled_on)
		{
			is_revealed = true;
		}
		else if(toggled_on == false)
		{
			is_revealed = false;
		}
	}

	private void _on_input_event(Node viewport, InputEvent @event, int shape_idx)
	{
		if(@event.IsActionPressed("click"))
		{
			if(is_revealed)
			{
				is_revealed = false;
			}
			else if(is_revealed == false)
			{
				is_revealed = true;
			}
			main.card_clicked_counter++;
			
		}
	}

	public void hide_all_cards()
	{
		is_revealed = false;
	}

}
