
public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Spuštění hry
            Game game = new Game();
            game.Run();  // Zde voláme hlavní metodu pro spuštění hry
        }
        catch (Exception ex)  // Zachytí jakoukoli chybu, která nastane
        {
            // Vypíše detailní chybovou zprávu
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}