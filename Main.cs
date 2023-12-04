using Godot;
using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

public partial class Main : Node2D
{
	private BetMængde betMængde;

	private Label Balance;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		betMængde = GetNode<BetMængde>("Bet_Amount"); // Henter værdien fra betmængde noden
		Balance = GetNode<Label>("Balance"); // Gør så vi kan 
		base._Ready();
		cardPrefab = ResourceLoader.Load("res://cards.tscn") as PackedScene;
		InstantiateCards();
		floorPrefab = ResourceLoader.Load("res://floor.tscn") as PackedScene;
		//SletFloor();
	}
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

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_spin_pressed()
	{
		GD.Print("!!!!SPIIINNNN!!!!!");
		
		GD.Print("Din balance er: "+Balance.Text); // GD.Print værdien fra balance
		GD.Print("Din betmængde er: "+betMængde.Text); // GD.Print værdien fra Betmængde

		GD.Print(betMængde.checkBet()); // GD.Print værdien fra checkBet

		if (int.Parse(Balance.Text) >= int.Parse(betMængde.Text)) // Hvis balance er større eller lig med betmængde
		{
			GD.Print("Du har nok penge til at spille"); // GD.Print at du har nok penge til at spille
		}
		else if (int.Parse(Balance.Text) < int.Parse(betMængde.Text)) // Hvis balance er mindre end betmængde
		{
			GD.Print("Du har ikke nok penge til at spille"); // GD.Print at du ikke har nok penge til at spille
		}
		RemoveFloor();
		MakeFloor();
		DeleteCards();
		InstantiateCards();
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
	private void DeleteCards()
	{
		
		//GD.Print("Lav nye kort");
		foreach (Node node in GetChildren())
		{
			if (node is cards)
			{
				node.QueueFree();
			}
		}
		
	}
	private PackedScene floorPrefab;
	private void RemoveFloor()
	{
		foreach (Node node in GetChildren())
		{
			if (node is StaticBody2D)
			{
				node.QueueFree();
			}
		}
	}
	private void MakeFloor()
	{
		StaticBody2D gulv = floorPrefab.Instantiate() as StaticBody2D;
		AddChild(gulv);
	}
}
