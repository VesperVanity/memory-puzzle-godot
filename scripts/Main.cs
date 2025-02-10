using Godot;
using System;

public partial class Main : Node2D
{
	private Area2D mouse_area;
	private Card card;

	private bool is_mouse_hovering = false;
	private int card_clicked_counter = 0;
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
				card.is_revealed = true;
				
			}
			
		}

		
		
		
		
		
	}

	private void _on_mouse_area_area_shape_entered(Rid area_rid, Area2D area, int area_shape_index, int local_shape_index)
	{
		
		if(area is Card)
		{
			is_mouse_hovering = true;
			card = (Card)area;
		}
	}

	private void _on_mouse_area_area_shape_exited(Rid area_rid, Area2D area, int area_shape_index, int local_shape_index)
	{
		if(area is Card)
		{
			is_mouse_hovering = false;
		}
	}
}
