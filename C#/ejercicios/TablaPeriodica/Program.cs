// multistring console.writeline

Console.Clear();
PeriodicTable();
static void PeriodicTable()
{
    string[][] elements = {
                // Otros No Metales
                
                    new string[] { "H", "Hidrógeno", "1.008", "1", "Otros No Metales"},
                    new string[] {"C", "Carbono", "12.011", "6", "Otros No Metales"},
                    new string[] {"N", "Nitrógeno", "14.007", "7", "Otros No Metales"},
                    new string[] {"O", "Oxígeno", "15.999", "8", "Otros No Metales"},
                    new string[] {"F", "Flúor", "18.998", "9", "Otros No Metales"},
                    new string[] {"P", "Fósforo", "30.794", "15", "Otros No Metales"},
                    new string[] {"S", "Azufre", "32.06", "16", "Otros No Metales"},
                    new string[] {"Cl", "Cloro", "35.45", "17", "Otros No Metales"},
                    new string[] {"Se", "Selenio", "78.971", "34", "Otros No Metales"},
                    new string[] {"Br", "Bromo", "79.904", "35", "Otros No Metales"},
                    new string[] {"I", "Yodo", "126.90", "53", "Otros No Metales"},


                // Gases Nobles
                    new string[] { "He", "Helium", "4.0026", "2", "Gases Nobles"},
                    new string[] { "Ne", "Neón", "20.180", "10", "Gases Nobles"},
                    new string[] { "Ar", "Argón", "39.948", "18", "Gases Nobles"},
                    new string[] { "Kr", "Kriptón", "83.798", "36", "Gases Nobles"},
                    new string[] { "Xe", "Xenón", "132.29", "54", "Gases Nobles"},
                    new string[] { "Rn", "Radón", "222", "86", "Gases Nobles"},


                // Alcalinos
               
                    new string[] { "Li", "Litio", "6.94", "3", "Alcalinos"},
                    new string[] { "Na", "Sodio", "22.990", "11", "Alcalinos"},
                    new string[] { "K", "Potasio", "39.098", "19", "Alcalinos"},
                    new string[] { "Rb", "Rubidio", "85.468", "37", "Alcalinos"},
                    new string[] { "Cs", "Cesio", "132.91", "55", "Alcalinos"},
                    new string[] { "Fr", "Francio", "223", "87", "Alcalinos"},


                // Alcalinotérreos
               
                    new string[] { "Be", "Berilio", "9.0122", "4", "Alcalinotérreos"},
                    new string[] { "Mg", "Magnesio", "24.305", "12", "Alcalinotérreos"},
                    new string[] { "Ca", "Calcio", "40.078", "20", "Alcalinotérreos"},
                    new string[] { "Sr", "Estroncio", "87.62", "38", "Alcalinotérreos"},
                    new string[] { "Ba", "Bario", "137.33", "56", "Alcalinotérreos"},
                    new string[] { "Ra", "Radio", "226", "88", "Alcalinotérreos"},


                // Lantánidos


                    new string[] { "La", "Lantano", "138.91", "57", "Lantánidos"},
                    new string[] { "Ce", "Cerio", "140.12", "58", "Lantánidos"},
                    new string[] { "Pr", "Praseosimio", "140.91", "59", "Lantánidos"},
                    new string[] { "Nd", "Neodimio", "144.24", "60", "Lantánidos"},
                    new string[] { "Pm", "Prometio", "145", "61", "Lantánidos"},
                    new string[] { "Sm", "Samario", "150.36", "62", "Lantánidos"},
                    new string[] { "Eu", "Europio", "151.96", "63", "Lantánidos"},
                    new string[] { "Gd", "Gadolinio", "157.25", "64", "Lantánidos"},
                    new string[] { "Tb", "Terbio", "158.93", "65", "Lantánidos"},
                    new string[] { "Dy", "Disprosio", "162.50", "66", "Lantánidos"},
                    new string[] { "Ho", "Holmio", "164.93", "67", "Lantánidos"},
                    new string[] { "Er", "Erbio", "167.26", "68", "Lantánidos"},
                    new string[] { "Tm", "Tulio", "168.93", "69", "Lantánidos"},
                    new string[] { "Yb", "Iterbio", "173.05", "70", "Lantánidos"},
                    new string[] { "Lu", "Lutecio", "174.97", "71", "Lantánidos"},


                // Actínido
               
                    new string[] { "Ac", "Actinio", "227", "89", "Actínidos"},
                    new string[] { "Th", "Torio", "232.04", "90", "Actínidos"},
                    new string[] { "Pa", "Protactinio", "231.04", "91", "Actínidos"},
                    new string[] { "U", "Uranio", "238.03", "92", "Actínidos"},
                    new string[] { "Np", "Neptunio", "237", "93", "Actínidos"},
                    new string[] { "Pu", "Plutonio", "244", "94", "Actínidos"},
                    new string[] { "Am", "Americio", "243", "95", "Actínidos"},
                    new string[] { "Cm", "Curio", "247", "96", "Actínidos"},
                    new string[] { "Bk", "Berkelio", "247", "97", "Actínidos"},
                    new string[] { "Cf", "Californio", "251", "98", "Actínidos"},
                    new string[] { "Es", "Einstenio", "252", "99", "Actínidos"},
                    new string[] { "Fm", "Fermio", "257", "100", "Actínidos"},
                    new string[] { "Md", "Mendelevio", "258", "101", "Actínidos"},
                    new string[] { "No", "Nobelio", "259", "102", "Actínidos"},
                    new string[] { "Lr", "Lawrencio", "103", "266", "Actínidos"},


                // Metal de transición
                    new string[] { "Sc", "Escandio", "44.956", "21", "Metales de Transición"},
                    new string[] { "Ti", "Titanio", "27.867", "22" ,"Metales de Transición"},
                    new string[] { "V", "Vanadio", "50.942", "23" ,"Metales de Transición"},
                    new string[] { "Cr", "Cromo", "51.996", "24" ,"Metales de Transición"},
                    new string[] { "Mn", "Manganeso", "54.938", "25" ,"Metales de Transición"},
                    new string[] { "Fe", "Hierro", "55.845", "26" ,"Metales de Transición"},
                    new string[] { "Co", "Cobalto", "58.933", "27" ,"Metales de Transición"},
                    new string[] { "Ni", "Níquel", "58.693", "28" ,"Metales de Transición"},
                    new string[] { "Cu", "Cobre", "63.546", "29" ,"Metales de Transición"},
                    new string[] { "Zn", "Zinc", "65.38", "30" ,"Metales de Transición"},
                    new string[] { "Y", "Itrio", "88.906", "39" ,"Metales de Transición"},
                    new string[] { "Zr", "Circonio", "91.224", "40" ,"Metales de Transición"},
                    new string[] { "Nb", "Niobio", "92.906", "41" ,"Metales de Transición"},
                    new string[] { "Mo", "Molibdeno", "95.95", "42" ,"Metales de Transición"},
                    new string[] { "Tc", "Tecnecio", "98", "43" ,"Metales de Transición"},
                    new string[] { "Ru", "Rutenio", "101.07", "44" ,"Metales de Transición"},
                    new string[] { "Rh", "Rodio", "102.91", "45" ,"Metales de Transición"},
                    new string[] { "Pd", "Paladio", "106.42", "46" ,"Metales de Transición"},
                    new string[] { "Ag", "Plata", "107.87", "47" ,"Metales de Transición"},
                    new string[] { "Cd", "Cadmio", "112.41", "48" ,"Metales de Transición"},
                    new string[] { "Hf", "Hafnio", "178.49", "72" ,"Metales de Transición"},
                    new string[] { "Ta", "Tántalo", "180.95", "73" ,"Metales de Transición"},
                    new string[] { "W", "Wolframio", "183.84", "74" ,"Metales de Transición"},
                    new string[] { "Re", "Renio", "186.21", "75" ,"Metales de Transición"},
                    new string[] { "Os", "Osmio", "190.23", "76" ,"Metales de Transición"},
                    new string[] { "Ir", "Iridio", "192.22", "77" ,"Metales de Transición"},
                    new string[] { "Pt", "Platino", "195.08", "78" ,"Metales de Transición"},
                    new string[] { "Au", "Oro", "196.67", "79" ,"Metales de Transición"},
                    new string[] { "Hg", "Mercurio", "200.59", "80" ,"Metales de Transición"},
                    new string[] { "Rf", "Rutherfordio", "267", "104" ,"Metales de Transición"},
                    new string[] { "Db", "Dubnio", "268", "105" ,"Metales de Transición"},
                    new string[] { "Sg", "Seaborgio", "269", "106" ,"Metales de Transición"},
                    new string[] { "Bh", "Bohrio", "270", "107" ,"Metales de Transición"},
                    new string[] { "Hs", "Hasio", "277", "108" ,"Metales de Transición"},


                // Metal del bloque p
               
                    new string[] { "Al", "Aluminio", "26.982", "13", "Metales del Bloque P"},
                    new string[] { "Ga", "Galio", "69.723", "31", "Metales del Bloque P"},
                    new string[] { "In", "Indio", "114.82", "49", "Metales del Bloque P"},
                    new string[] { "Tl", "Talio", "204.38", "81", "Metales del Bloque P"},
                    new string[] { "Sn", "Estaño", "118.71", "50", "Metales del Bloque P"},
                    new string[] { "Pb", "Plomo", "207.2", "82", "Metales del Bloque P"},
                    new string[] { "Bi", "Bismuto", "208.98", "83", "Metales del Bloque P"},
                    new string[] { "Po", "Polonio", "209", "84", "Metales del Bloque P"},
                    new string[] { "Lr", "Lawrencio", "103", "266", "Metales del Bloque P"},


                // Semimetal
               
                    new string[] { "B", "Boro", "10.81", "5", "Semimetales"},
                    new string[] { "Si", "Silicio", "28.085", "14", "Semimetales"},
                    new string[] { "Ge", "Germanio", "72.630", "32", "Semimetales"},
                    new string[] { "As", "Arsénico", "74.922", "33", "Semimetales"},
                    new string[] { "Sb", "Antimonio", "121.76", "51", "Semimetales"},
                    new string[] { "Te", "Telurio", "127.60", "52", "Semimetales"},
                    new string[] { "At", "Ástato", "210", "85", "Semimetales"},


                // Sin nombre
               
                    new string[] { "Mt", "Meitnerio", "278", "109", "Sin Categoría"},
                    new string[] { "Ds", "Darmstatio", "281", "110", "Sin Categoría"},
                    new string[] { "Rg", "Roentgenio", "281", "111", "Sin Categoría"},
                    new string[] { "Cn", "Copernicio", "285", "112", "Sin Categoría"},
                    new string[] { "Nh", "Nihonio", "286", "113", "Sin Categoría"},
                    new string[] { "Fl", "Flerovio", "289", "114", "Sin Categoría"},
                    new string[] { "Mc", "Moscovio", "290", "115", "Sin Categoría"},
                    new string[] { "Lv", "Livermorio", "293", "116", "Sin Categoría"},
                    new string[] { "Ts", "Teneso", "294", "117", "Sin Categoría"},
                    new string[] { "Og", "Oganesón", "294", "118", "Sin Categoría"},

            };

    Console.ResetColor();
    string[][] sortedElements = elements.OrderBy(x => int.Parse(x[3])).ToArray();
    Console.WriteLine($"      1   2   3   4   5   6   7   8   9   10  11  12  13  14  15  16  17  18 ");
    Console.WriteLine($"                                                                               ");
    Console.Write($"    1");
    for (int i = 0; i < 118; i++)
    {
        switch (i)
        {
            case 2:
                rows(2);
                break;
            case 10:
                rows(3);
                break;
            case 18:
                rows(4);
                break;
            case 36:
                rows(5);
                break;
            case 54:
                rows(6);
                break;
            case 86:
                rows(7);
                break;

        }

        switch (sortedElements[i][4])
        {

            case "Alcalinos":
                Console.ForegroundColor = ConsoleColor.Yellow;
                if (sortedElements[i][0].Length == 1)
                {
                    Console.Write($" {sortedElements[i][0]}  ");
                }
                else
                {
                    Console.Write($" {sortedElements[i][0]} ");
                }
                break;
            case "Alcalinotérreos":
                Console.ForegroundColor = ConsoleColor.Green;
                if (i >= 19 && i < 55)
                {
                    Console.Write($" {sortedElements[i][0]} ");
                }
                else if (sortedElements[i][0] == "Ba")
                {
                    Console.Write($" {sortedElements[i][0]}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"  *  ");
                }
                else if (sortedElements[i][0] == "Ra")
                {
                    Console.Write($" {sortedElements[i][0]}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"  ** ");
                }
                else
                {
                    Console.Write($" {sortedElements[i][0]}\t\t\t\t\t     ");
                }
                break;
            case "Metales de Transición":
                Console.ForegroundColor = ConsoleColor.Cyan;
                if (sortedElements[i][0].Length == 2)
                {
                    Console.Write($" {sortedElements[i][0]} ");

                }
                else
                {
                    Console.Write($" {sortedElements[i][0]}  ");
                }

                break;
            case "Metales del Bloque P":
                Console.ForegroundColor = ConsoleColor.DarkBlue;

                Console.Write($" {sortedElements[i][0]} ");
                break;
            case "Semimetales":
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                if (sortedElements[i][0].Length == 2)
                {
                    Console.Write($" {sortedElements[i][0]} ");
                }
                else
                {

                    Console.Write($" {sortedElements[i][0]} ");
                }
                break;
            case "Otros No Metales":
                Console.ForegroundColor = ConsoleColor.Red;
                if (i == 0)
                {
                    Console.Write(" " + $"{sortedElements[i][0]}                                                                 ");
                }
                else if (sortedElements[i][0].Length == 2)
                {
                    Console.Write($"  {sortedElements[i][0]}");
                }
                else
                {
                    Console.Write($"  {sortedElements[i][0]} ");
                }
                break;
            case "Gases Nobles":
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write($"  {sortedElements[i][0]}");
                break;
            case "Sin Categoría":
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write($" {sortedElements[i][0]} ");
                break;
            // si son lantanoides o actinoides muevelos hasta abajo de la tabla
            case "Lantanoides":
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($" {sortedElements[i][0]} ");
                break;
        }
    }
    // sort lantanoides and actinoides by atomic number
    Console.WriteLine("\n");
    for (int i = 56; i < 71; i++)
    {
        switch (i)
        {
            case 56:
                Console.Write($"\t\t*");
                break;
        }
        if (i % 2 == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        Console.Write($" {sortedElements[i][0]} ");
    }
    Console.ResetColor();
    for (int i = 88; i < 103; i++)
    {
        switch (i)
        {
            case 88:
                Console.Write($"\n\t\t**");
                break;
        }
        // alternate colors between each character of the symbol
        if (i % 2 == 0)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        Console.Write($" {sortedElements[i][0]} ");
    }

    Console.ResetColor();

    Console.Write("\n\nIngrese el simbolo del elemento: ");
    string elementName = Console.ReadLine();
    for (int i = 0; i < elements.Length; i++)
    {
        if (elements[i][0] == elementName)
        {
            // tabla de datos
            Console.WriteLine(@$"
        Nombre: {elements[i][1]}                                                
        Masa Atómico: {elements[i][2]}                                        
        Número de Atómico: {elements[i][3]}                                        
        Categoría: {elements[i][4]}                                             
    ");
            break;
        }

    }


}
static void rows(int number)
{
    Console.WriteLine("\n");
    Console.ResetColor();
    Console.Write($"    {number}");
}


