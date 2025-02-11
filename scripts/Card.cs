using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Card : Area2D
{	
	private Main main;
	public Label card_label;

	private Area2D first_card;
	private Area2D second_card;

	public bool is_revealed = false;
	public bool is_permanent_revealed = false;

	public string card_name = " ";

	public override void _Ready()
	{
		card_label = GetNode<Label>("card_label");
		main = GetNode<Main>("../../../../main");
		card_label.Visible = false;
		//main.Connect("Checkpair", Callable.From())
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
		else if(is_revealed == false && is_permanent_revealed == false)
		{
			card_label.Visible = false;
		}

		if(is_permanent_revealed)
		{
			card_label.Visible = true;
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
			//Problem is they are separate entities all reporting the same thing
			//All numbers checking for all numbers means all cards will always
			//Count as being permanently revealed
			//Wrestling with that problem since 5 hours
		}
		
	}

	private void check_pair()
	{
		
	}

	public void hide_all_cards()
	{
		is_revealed = false;
	}

}
