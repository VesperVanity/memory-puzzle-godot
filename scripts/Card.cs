using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Card : Area2D
{	
	private Main main;
	private Card card_1;
	private Card card_2;
	public Label card_label;
	private Area2D mouse_area;

	public bool is_revealed = false;
	private bool is_permanent_revealed = false;

	private bool is_card_1 = false;
	private bool is_card_2 = false;

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
			GD.Print(main.card_clicked_counter);
			if(main.card_clicked_counter == 2)
			{
				//Problem is they are separate entities all reporting the same thing
				//All numbers checking for all numbers means all cards will always
				//Count as being permanently revealed
				//Wrestling with that problem since 5 hours
				if(card_1 != null && card_2 != null)
				{
					if(card_1.card_label.Text == card_2.card_label.Text)
					{
						card_1.is_permanent_revealed = true;
						card_2.is_permanent_revealed = true;
					}
					else
					{
						card_1.is_revealed = false;
						card_2.is_revealed = false;

					}
				}
				card_1 = null;
				card_2 = null;
				
				main.card_clicked_counter = 0;
			}
			
		}
		
	}

	private void _on_mouse_area_area_entered(Area2D area)
	{
		if(area is Card)
		{
			if(is_card_1 == false)
			{
				card_1 = (Card)area;
				is_card_1 = true;
			}
			else if(is_card_1)
			{
				card_2 = (Card)area;
				is_card_2 = true;
			}
		}
	}

	private void _on_mouse_area_area_exited(Area2D area)
	{
		if(area is Card)
		{
			if(is_card_2)
			{
				card_2 = null;
				is_card_2 = false;
			}
			else if(is_card_1)
			{
				card_1 = null;
				is_card_1 = false;
			}
		}
	}

	public void hide_all_cards()
	{
		is_revealed = false;
	}

}
