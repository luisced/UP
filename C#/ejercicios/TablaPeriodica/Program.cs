PeriodicTable();
static void PeriodicTable()
{
    string[][][] elements = {
                // first group
                 new string[][]{
                    new string[] { "H", "Hydrogen", "1.008", "1"},
                },
                // second group
                new string[][]{
                    new string[] { "He", "Helium", "4.0026", "18"},
                    new string[] { "Li", "Lithium", "6.94", "1"},
                    new string[] { "Be", "Beryllium", "9.0122", "2"},
                },
            };
    // all elements
    foreach (string[][] group in elements)
    {
        foreach (string[] element in group)
        {
            Console.WriteLine($"{element[0]} {element[1]} {element[2]} {element[3]}");
        }
    }

}