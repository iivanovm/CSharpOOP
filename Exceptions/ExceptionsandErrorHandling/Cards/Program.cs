using System;
using System.ComponentModel.Design;
using System.Threading.Tasks.Dataflow;

public class StartUp
{
    public static void Main()
    {
        List<Cards> cards = new List<Cards>();
        Cards card1 = new Cards();

        string[] inputCard = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
        foreach (string card in inputCard)
        {
            try
            {
                string[] ca = card.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                cards.Add(card1.CreateCard(ca[0], ca[1]));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                continue;
            }
        }
        Console.WriteLine(string.Join(" ",cards));
    }


}

public class Cards
{
    private string face;
    private string card;

    public string Faces
    {
        get
        {
            return face;
        }
        set
        {
            if (value == "3" || value == "2" || value == "4" || value == "5" || value == "6" || value == "7"
                || value == "8" || value == "9" || value == "10" || value == "J" || value == "Q" || value == "K" || value == "A")
            {
                face = value;
            }
            else
            {
                throw new Exception("Invalid card!");
            }
        }
    }
    public string Card
    {
        get { return card; }
        set
        {
            if (value == "S" || value == "H" || value == "D" || value == "C")
            {
                card = value;
                switch (card)
                {
                    case "S":
                        card = "\u2660";
                        break;
                    case "H":
                        card = "\u2665";
                        break;
                    case "D":
                        card = "\u2666";
                        break;
                    case "C":
                        card = "\u2663";
                        break;
                }
            }
            else
            {
                throw new Exception("Invalid card!");
            }
        }
    }
    public Cards(string faces, string card)
    {
        Faces = faces;
        Card = card;
    }

    public Cards CreateCard(string face, string card)
    {
        Cards current = new Cards(face, card);
        return current;
    }
    public Cards()
    {

    }


    public override string ToString()
    {
        return $"[{Faces}{Card}]";
    }
}