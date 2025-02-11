using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Card : Area2D
{	
	private Main main;
	private Card clicked_card;
	public Label card_label;
	private Area2D mouse_area;

	public bool is_revealed = false;
	private bool is_permanent_revealed = false;

	public override void _Ready()
	{
		card_label = GetNode<Label>("card_label");
		mouse_area = GetNode<Area2D>("mouse_area");
		main = GetNode<Main>("../../../../main");
		card_label.Visible = false;
	
	}

	//All the logic and counters here simply do not work
	//Because each has their own counter while I use the counter
	//As a singular entity to manipulate, meaning we need
	//A new way of figuring it out
	public override void _Process(double delta)
	{
		mouse_area.Position = GetLocalMousePosition();
		if(is_revealed)
		{
			card_label.Visible = true;
		}
		else if(is_revealed == false)
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
			if(main.card_clicked_counter == 2)
			{
				//Problem is they are separate entities all reporting the same thing
				//All numbers checking for all numbers means all cards will always
				//Count as being permanently revealed
				//Wrestling with that problem since 5 hours
				if(card_label.Text == clicked_card.card_label.Text)
				{
					is_permanent_revealed = true;
				}
				else
				{
					is_revealed = false;
					clicked_card.is_revealed = false;
				}
				main.card_clicked_counter = 0;
			}
			
		}
		
	}

	private void _on_mouse_area_area_entered(Area2D area)
	{
		if(area is Card)
		{
			clicked_card = (Card)area;
		}
	}

	private void _on_mouse_area_area_exited(Area2D area)
	{
		if(area is Card)
		{
			clicked_card = null;
		}
	}

	public void hide_all_cards()
	{
		is_revealed = false;
	}

}
