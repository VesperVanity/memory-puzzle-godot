using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
public partial class SpawnManager : Node2D
{
	private Card card;
	private PackedScene card_scene;
	private Area2D card_instance;
	private Control gui_container;
	private Node2D spawn_start_position;
	private RandomNumberGenerator rng = new RandomNumberGenerator();
	private List<int> taken_random_numbers = new List<int>();
	private List<Area2D> cards = new List<Area2D>();
	private int card_amount = 0;
	private int random_card_label_number = 0;
	private int one_pair_counter = 0;
	private int card_counter = 0;
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

	private void randomize_card_positions()
	{
		if(card_counter == card_amount)
		{
			for(int i = 0; i < card_amount; ++i)
			{
				//Randomize the positions of the cards
				int random_card_number;
				int random_swap_card_number;
				random_card_number = rng.RandiRange(1, card_amount - 1);
				random_swap_card_number = rng.RandiRange(1, card_amount - 1);
				Area2D random_card = cards.ElementAt(random_card_number);
				Vector2 random_card_position = random_card.Position;
				Area2D random_swap_card = cards.ElementAt(random_swap_card_number);
				Vector2 random_swap_card_position = random_swap_card.Position;
				random_card.Position = random_swap_card_position;
				random_swap_card.Position = random_card_position;
			}
		}
	}

	private void create_pairs()
	{
		if(one_pair_counter == 0)
		{
			random_card_label_number = rng.RandiRange(1, card_amount / 2);
			while(taken_random_numbers.Contains(random_card_label_number))
			{
				random_card_label_number = rng.RandiRange(1, card_amount / 2);
			}
		}
		if(one_pair_counter < 2)
		{
			card.card_label.Text = random_card_label_number.ToString();
			one_pair_counter++;
		}
		if(one_pair_counter == 2)
		{
			//Maybe create an array which you read the random numbers into
			//And before creating another random number we iterate over the array
			//Of already taken numbers until we have the full range of card pairs
			taken_random_numbers.Add(random_card_label_number);
			one_pair_counter = 0;
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
		randomize_card_positions();
	}

	private void spawn_card()
	{
		card_instance = card_scene.Instantiate<Area2D>();
		card = (Card)card_instance;
		spawn_start_position.AddChild(card_instance);
		cards.Add(card_instance);
		card_counter++;
		create_pairs();
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
