using Godot;
using System;
using System.Collections.Generic;

public partial class Main : Node2D
{
	private Area2D mouse_area;
	private Card first_card;
	private Card second_card;
	public List<Area2D> cards = new List<Area2D>();

	private bool is_mouse_hovering = false;
	private bool is_first_card_chosen = false;
	private bool is_first_card_clicked = false;
	private bool is_second_card_chosen = false;
	private bool is_second_card_clicked = false;

	
	public override void _Ready()
	{	
		mouse_area = GetNode<Area2D>("mouse_area");
	}

	
	public override void _Process(double delta)
	{
		mouse_area.Position = GetLocalMousePosition();

		if(is_mouse_hovering)
		{
			if(Input.IsMouseButtonPressed(MouseButton.Left))
			{
				if(is_first_card_clicked == false)
				{
					first_card.card_label.Visible = true;
					is_first_card_clicked = true;
				}
				else if(is_first_card_clicked)
				{
					second_card.card_label.Visible = true;
					is_second_card_clicked = true;
				}
				//Probably add a timer to delay turning the card to see if it matched
				if(first_card.card_label.Text == second_card.card_label.Text && is_second_card_clicked)
				{
					first_card.is_revealed = true;
					second_card.is_revealed = true;
				}
				else if(first_card.card_label.Text != second_card.card_label.Text && is_second_card_clicked)
				{
					first_card.is_revealed = false;
					second_card.is_revealed = false;
					is_first_card_chosen = false;
					is_first_card_clicked = false;
					is_second_card_clicked = false;
				}
				
			}
			
		}

	}

	private void _on_mouse_area_area_entered(Area2D area)
	{
		if(area is Card)
		{
			if(is_first_card_chosen == false)
			{
				first_card = (Card)area;
				is_first_card_chosen = true;
			}
			else if(is_first_card_chosen)
			{
				second_card = (Card)area;
			}
			is_mouse_hovering = true;
		}
	}

	private void _on_mouse_area_area_exited(Area2D area)
	{
		if(area is Card)
		{
			is_mouse_hovering = false;
		}
	}

	
}
