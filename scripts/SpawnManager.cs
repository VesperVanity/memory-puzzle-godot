using Godot;
using System;

public partial class SpawnManager : Node2D
{
	
	private PackedScene card_scene;
	private Area2D card_instance;
	private Control gui_container;
	private Node2D spawn_start_position;
	private int card_amount = 0;
	private bool is_map_spawned = false;
	private bool is_map_ready_to_spawn = false;
	public override void _Ready()
	{
		card_scene = ResourceLoader.Load<PackedScene>("res://scenes/card.tscn");
		gui_container = GetNode<Control>("../GUI/gui_container");
		spawn_start_position = GetNode<Node2D>("spawn_start_position");
	}

	
	public override void _Process(double delta)
	{
		if(is_map_spawned == false && is_map_ready_to_spawn)
		{
			spawn_map();
			is_map_spawned = true;
		}
	}

	private Vector2 spawn_position_y_offset = new Vector2(0.0f, 120.0f);
	private Vector2 spawn_position_x_reset = new Vector2(120.0f, 0.0f);
	private void spawn_map()
	{
		for(int i = 0; i < card_amount; ++i)
		{
			spawn_card();
			card_instance.Position += new Vector2(120.0f, 0) * i;
			if(i >= 10 && i < 20)
			{
				card_instance.Position += spawn_position_y_offset;
				card_instance.Position -= spawn_position_x_reset * 10;
			}
			if(i >= 20 && i < 30)
			{
				card_instance.Position += spawn_position_y_offset * 2;
				card_instance.Position -= spawn_position_x_reset * 20;
			}
			if(i >= 30 && i < 40)
			{
				card_instance.Position += spawn_position_y_offset * 3;
				card_instance.Position -= spawn_position_x_reset * 30;
			}
			if(i >= 40 && i < 50)
			{
				card_instance.Position += spawn_position_y_offset * 4;
				card_instance.Position -= spawn_position_x_reset * 40;
			}
			if(i >= 50 && i < 60)
			{
				card_instance.Position += spawn_position_y_offset * 5;
				card_instance.Position -= spawn_position_x_reset * 50;
			}
			if(i >= 60 && i < 70)
			{
				card_instance.Position += spawn_position_y_offset * 6;
				card_instance.Position -= spawn_position_x_reset * 60;
			}
			if(i >= 70 && i < 80)
			{
				card_instance.Position += spawn_position_y_offset * 7;
				card_instance.Position -= spawn_position_x_reset * 70;
			}
			if(i >= 80)
			{
				card_instance.Position += spawn_position_y_offset * 8;
				card_instance.Position -= spawn_position_x_reset * 80;
			}
			
			
		}
	}

	private void spawn_card()
	{
		card_instance = card_scene.Instantiate<Area2D>();
		spawn_start_position.AddChild(card_instance);
	}

	private void _on_size_small_button_pressed()
	{
		card_amount = 40;
		is_map_ready_to_spawn = true;
		gui_container.Visible = false;
	}

	private void _on_size_medium_button_pressed()
	{
		card_amount = 60;
		is_map_ready_to_spawn = true;
		gui_container.Visible = false;
	}

	private void _on_size_large_button_pressed()
	{
		card_amount = 80;
		is_map_ready_to_spawn = true;
		gui_container.Visible = false;
	}

}
