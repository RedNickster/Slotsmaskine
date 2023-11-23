using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Main : Node2D
{
	// Called when the node enters the scene tree for the first time.

	private int[] talArray; //opretter et array af typen int

	private void LavTalArray()
	{
		talArray = new int[9];

		for (int i = 0; i < 9; i++)
		{
			talArray[i] = GD.RandRange(0, 2);
		}

	}

	public override void _Ready()
	{
		base._Ready();
		cardPrefab = ResourceLoader.Load("res://cards.tscn") as PackedScene;
		InstantiateCards();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	private PackedScene cardPrefab;

	private void InstantiateCards()
	{
		LavTalArray();

		GD.Print(String.Join(", ", talArray));
		for (int i = 0; i < talArray.Length; i++)
		{
			cards symboler = cardPrefab.Instantiate() as cards;
			AddChild(symboler);

			symboler.ChangeSprite(talArray[i]);

			if (i < 3)
			{
				symboler.Position = new Vector2(100 + (i + 1) * 100, 100);
			}
			else if (i > 2 && i < 6)
			{
				symboler.Position = new Vector2(100 + (i - 2) * 100, 200);
			}
			else
			{
				symboler.Position = new Vector2(100 + (i - 5) * 100, 300);
			}

		}
		CheckConnects(talArray);
	}



	private void CheckConnects(int[] array)
	{
		int gridSize = 3;

		for (int row = 0; row < gridSize; row++)
		{
			for (int col = 0; col < gridSize - 2; col++)
			{
				int index = row * gridSize + col;

				if (array[index] == array[index + 1] && array[index + 1] == array[index + 2])
				{
					GD.Print($"Der er et connect med 3 ens symboler fra venstre i række {row}");
				}
				else if (array[index] == array[index + 1])
				{
					GD.Print($"Der er et connect med 2 ens symboler fra venstre i række {row}");
				}
			}
		}
	}
}
