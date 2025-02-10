using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Card : Area2D
{
	private Card card;
	private Button button;
	private Area2D mouse_area;
	public Label card_label;
	public List<Area2D> cards = new List<Area2D>();

	public bool is_revealed = false;
	private bool is_mouse_hovering = false;

	public override void _Ready()
	{
		card_label = GetNode<Label>("card_label");
		button = GetNode<Button>("card_button");
		mouse_area = GetNode<Area2D>("mouse_area");
		card_label.Visible = false;
		cards.Add(this);
	}

	//All the logic and counters here simply do not work
	//Because each has their own counter while I use the counter
	//As a singular entity to manipulate, meaning we need
	//A new way of figuring it out
	public override void _Process(double delta)
	{
		mouse_area.Position = GetLocalMousePosition();
		if(is_mouse_hovering)
		{
			if(Input.IsMouseButtonPressed(MouseButton.Left))
			{
				if(card_label.Text == card.card_label.Text)
				{
					is_revealed = true;
					card.is_revealed = true;
				}
			}
		}
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

	private void _on_mouse_area_area_entered(Area2D area)
	{
		if(area is Card)
		{
			card = (Card)area;
		}
	}

	private void _on_mouse_area_area_exited(Area2D area)
	{
		if(area is Card)
		{
			card = null;
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

	
	public void hide_all_cards()
	{
		is_revealed = false;
	}

}
