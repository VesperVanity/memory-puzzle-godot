using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Main : Node2D
{
	
	private Card card_1;
	private Card card_2;
	private Area2D mouse_area;
	public int card_clicked_counter = 0;

	private bool is_card_1 = false;
	private bool is_card_2 = false;
	public override void _Ready()
	{	
		mouse_area = GetNode<Area2D>("mouse_area");
	}

	
	public override void _Process(double delta)
	{
		mouse_area.Position = GetLocalMousePosition();
		if(card_clicked_counter == 2)
		{
			if(card_1 != null && card_2 != null)
			{
				if(card_1.card_label.Text == card_2.card_label.Text)
				{
					card_1.is_permanent_revealed = true;
					card_2.is_permanent_revealed = true;
					is_card_1 = false;
					is_card_2 = false;
					card_1 = null;
					card_2 = null;
				}
				else
				{
					card_1.is_revealed = false;
					card_2.is_revealed = false;
					is_card_1 = false;
					is_card_2 = false;
					card_1 = null;
					card_2 = null;
				}
				card_clicked_counter = 0;
				GD.Print("Works");
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
			else if(is_card_1 && is_card_2 == false)
			{
				card_1 = null;
				is_card_1 = false;
			}
		}
	}

}
