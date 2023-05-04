using static DeckService.Models.DeckService;

namespace DeckService.Models;

public class Deck
{
	List<Card> Cards { get; }
	string Name { get; }

	public Deck(string name)
	{
		Name = name;
		Cards = new List<Card>();
		string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
		string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

		foreach (string suit in suits)
		{
			foreach (string rank in ranks)
			{
				Cards.Add(new Card { Suit = suit, Rank = rank });
			}
		}
	}

	public void Shuffle(Shuffle shuffle)
	{
		switch (shuffle)
		{
			case DeckService.Shuffle.Random:
			{
				var random = new Random();
				for (int i = 0; i < Cards.Count; i++)
				{
					int j = random.Next(i + 1);
					(Cards[i], Cards[j]) = (Cards[j], Cards[i]); // bubble-sort
				}

				break;
			}
			case DeckService.Shuffle.ByHalf:
			{

				ShuffleByHalf(Cards);
				break;
			}

			default:
				throw new ArgumentOutOfRangeException();
		}
	}

	public List<Card> GetCards()
	{
		return Cards;
	}

	void ShuffleByHalf(List<Card> cards)
	{
		if (cards.Count == 1)
			return;
		var rand = new Random();
		int halfIndex = cards.Count / 2;

		List<Card> leftHalf = cards.GetRange(0, halfIndex);
		List<Card> rightHalf = cards.GetRange(halfIndex, cards.Count - halfIndex);

		ShuffleByHalf(leftHalf);
		ShuffleByHalf(rightHalf);

		int leftIndex = 0;
		int rightIndex = 0;

		for (int i = 0; i < cards.Count; i++)
		{
			if (leftIndex < leftHalf.Count && rightIndex < rightHalf.Count)
			{
				if (rand.Next(2) == 0)
				{
					cards[i] = leftHalf[leftIndex];
					leftIndex++;
				}
				else
				{
					cards[i] = rightHalf[rightIndex];
					rightIndex++;
				}
			}
			else if (leftIndex < leftHalf.Count)
			{
				cards[i] = leftHalf[leftIndex];
				leftIndex++;
			}
			else if (rightIndex < rightHalf.Count)
			{
				cards[i] = rightHalf[rightIndex];
				rightIndex++;
			}
		}
	}
}
