// multistring console.writeline

Console.Clear();
PeriodicTable();
static void PeriodicTable()
{
    string[][][] elements = {
                // Otros No Metales
                 new string[][]{
                    new string[] { "H", "Hidrógeno", "1.008", "1"},
                    new string[] {"C", "Carbono", "12.011", "6"},
                    new string[] {"N", "Nitrógeno", "14.007", "7"},
                    new string[] {"O", "Oxígeno", "15.999", "8"},
                    new string[] {"F", "Flúor", "18.998", "9"},
                    new string[] {"P", "Fósforo", "30.794", "15"},
                    new string[] {"S", "Azufre", "32.06", "16"},
                    new string[] {"Cl", "Cloro", "35.45", "17"},
                    new string[] {"Se", "Selenio", "78.971", "34"},
                    new string[] {"Br", "Bromo", "79.904", "35"},
                    new string[] {"I", "Yodo", "126.90", "53"},
                },

                // Gases Nobles
                new string[][]{
                    new string[] { "He", "Helium", "4.0026", "18"},
                    new string[] { "Ne", "Neón", "20.180", "10"},
                    new string[] { "Ar", "Argón", "39.948", "18"},
                    new string[] { "Kr", "Kriptón", "83.798", "36"},
                    new string[] { "Xe", "Xenón", "132.29", "54"},
                    new string[] { "Rn", "Radón", "222", "86"},
                },

                // Alcalinos
                new string[][]
                {
                    new string[] { "Li", "Litio", "6.94", "3"},
                    new string[] { "Na", "Sodio", "22.990", "11"},
                    new string[] { "K", "Potasio", "39.098", "19"},
                    new string[] { "Rb", "Rubidio", "85.468", "37"},
                    new string[] { "Cs", "Cesio", "132.91", "55"},
                    new string[] { "Fr", "Francio", "223", "87"},
                },

                // Alcalinotérreos
                new string[][]
                {
                    new string[] { "Be", "Berilio", "9.0122", "4"},
                    new string[] { "Mg", "Magnesio", "24.305", "12"},
                    new string[] { "Ca", "Calcio", "40.078", "20"},
                    new string[] { "Sr", "Estroncio", "87.62", "38"},
                    new string[] { "Ba", "Bario", "137.33", "56"},
                    new string[] { "Ra", "Radio", "226", "88"},
                },

                // Lantánidos
                new string[][]
                {
                    new string[] { "La", "Lantano", "138.91", "57"},
                    new string[] { "Ce", "Cerio", "140.12", "58"},
                    new string[] { "Pr", "Praseosimio", "140.91", "59"},
                    new string[] { "Nd", "Neodimio", "144.24", "60"},
                    new string[] { "Pm", "Prometio", "145", "61"},
                    new string[] { "Sm", "Samario", "150.36", "62"},
                    new string[] { "Eu", "Europio", "151.96", "63"},
                    new string[] { "Gd", "Gadolinio", "157.25", "64"},
                    new string[] { "Tb", "Terbio", "158.93", "65"},
                    new string[] { "Dy", "Disprosio", "162.50", "66"},
                    new string[] { "Ho", "Holmio", "164.93", "67"},
                    new string[] { "Er", "Erbio", "167.26", "68"},
                    new string[] { "Tm", "Tulio", "168.93", "69"},
                    new string[] { "Yb", "Iterbio", "173.05", "70"},
                    new string[] { "Lu", "Lutecio", "174.97", "71"},
                },

                // Actínido
                new string[][]
                {
                    new string[] { "Ac", "Actinio", "227", "89"},
                    new string[] { "Th", "Torio", "232.04", "90"},
                    new string[] { "Pa", "Protactinio", "231.04", "91"},
                    new string[] { "U", "Uranio", "238.03", "92"},
                    new string[] { "Np", "Neptunio", "237", "93"},
                    new string[] { "Pu", "Plutonio", "244", "94"},
                    new string[] { "Am", "Americio", "243", "95"},
                    new string[] { "Cm", "Curio", "247", "96"},
                    new string[] { "Bk", "Berkelio", "247", "97"},
                    new string[] { "Cf", "Californio", "251", "98"},
                    new string[] { "Es", "Einstenio", "252", "99"},
                    new string[] { "Fm", "Fermio", "257", "100"},
                    new string[] { "Md", "Mendelevio", "258", "101"},
                    new string[] { "No", "Nobelio", "259", "102"},
                    new string[] { "Lr", "Lawrencio", "103", "266"},
                },

                // Metal de transición
                new string[][]
                {
                    new string[] { "Ti", "Titanio", "27.867", "22"},
                    new string[] { "V", "Vanadio", "50.942", "23"},
                    new string[] { "Cr", "Cromo", "51.996", "24"},
                    new string[] { "Mn", "Manganeso", "54.938", "25"},
                    new string[] { "Fe", "Hierro", "55.845", "93"},
                    new string[] { "Co", "Cobalto", "58.933", "27"},
                    new string[] { "Ni", "Níquel", "58.693", "28"},
                    new string[] { "Cu", "Cobre", "63.546", "29"},
                    new string[] { "Zn", "Zinc", "65.38", "30"},
                    new string[] { "Zr", "Circonio", "91.224", "40"},
                    new string[] { "Nb", "Niobio", "92.906", "41"},
                    new string[] { "Mo", "Molibdeno", "95.95", "42"},
                    new string[] { "Tc", "Tecnecio", "98", "43"},
                    new string[] { "Ru", "Rutenio", "101.07", "44"},
                    new string[] { "Rh", "Rodio", "102.91", "45"},
                    new string[] { "Pd", "Paladio", "106.42", "46"},
                    new string[] { "Ag", "Plata", "107.87", "47"},
                    new string[] { "Cd", "Cadmio", "112.41", "48"},
                    new string[] { "Hf", "Hafnio", "178.49", "72"},
                    new string[] { "Ta", "Tántalo", "180.95", "73"},
                    new string[] { "W", "Wolframio", "183.84", "74"},
                    new string[] { "Re", "Renio", "186.21", "75"},
                    new string[] { "Os", "Osmio", "190.23", "76"},
                    new string[] { "Ir", "Iridio", "192.22", "77"},
                    new string[] { "Pt", "Platino", "195.08", "78"},
                    new string[] { "Au", "Oro", "196.67", "79"},
                    new string[] { "Hg", "Mercurio", "200.59", "80"},
                    new string[] { "Rf", "Rutherfordio", "267", "104"},
                    new string[] { "Db", "Dubnio", "268", "105"},
                    new string[] { "Sg", "Seaborgio", "269", "106"},
                    new string[] { "Bh", "Bohrio", "270", "107"},
                    new string[] { "Hs", "Hasio", "277", "108"},
                },

                // Metal del bloque p
                new string[][]
                {
                    new string[] { "Al", "Aluminio", "26.982", "13"},
                    new string[] { "Ga", "Galio", "69.723", "31"},
                    new string[] { "In", "Indio", "114.82", "49"},
                    new string[] { "Tl", "Talio", "204.38", "81"},
                    new string[] { "Sn", "Estaño", "118.71", "50"},
                    new string[] { "Pb", "Plomo", "207.2", "82"},
                    new string[] { "Bi", "Bismuto", "208.98", "83"},
                    new string[] { "Po", "Polonio", "209", "84"},
                    new string[] { "Bk", "Berkelio", "247", "97"},
                    new string[] { "Cf", "Californio", "251", "98"},
                    new string[] { "Es", "Einstenio", "252", "99"},
                    new string[] { "Fm", "Fermio", "257", "100"},
                    new string[] { "Md", "Mendelevio", "258", "101"},
                    new string[] { "No", "Nobelio", "259", "102"},
                    new string[] { "Lr", "Lawrencio", "103", "266"},
                },

                // Semimetal
                new string[][]
                {
                    new string[] { "B", "Boro", "10.81", "5"},
                    new string[] { "Si", "Silicio", "28.085", "14"},
                    new string[] { "Ge", "Germanio", "72.630", "32"},
                    new string[] { "As", "Arsénico", "74.922", "33"},
                    new string[] { "Sb", "Antimonio", "121.76", "51"},
                    new string[] { "Te", "Telurio", "127.60", "52"},
                    new string[] { "At", "Ástato", "210", "85"},
                },

                // Sin nombre
                new string[][]
                {
                    new string[] { "Mt", "Meitnerio", "278", "109"},
                    new string[] { "Ds", "Darmstatio", "281", "110"},
                    new string[] { "Rg", "Roentgenio", "281", "111"},
                    new string[] { "Cn", "Copernicio", "285", "112"},
                    new string[] { "Nh", "Nihonio", "286", "113"},
                    new string[] { "Fl", "Flerovio", "289", "114"},
                    new string[] { "Mc", "Moscovio", "290", "115"},
                    new string[] { "Lv", "Livermorio", "293", "116"},
                    new string[] { "Ts", "Teneso", "294", "117"},
                    new string[] { "Og", "Oganesón", "294", "118"},
                },
            };


    Console.ResetColor();
    Console.WriteLine(@$"
 __________________________________________________________________________ 
|   1   2   3   4   5   6   7   8   9   10  11  12  13  14  15  16  17  18 |
|                                                                          |
|1  H                                                                   He |
|                                                                          |
|2  Li  Be                                          B   C   N   O   F   Ne |
|                                                                          |
|3  Na  Mg                                          Al  Si  P   S   Cl  Ar |
|                                                                          |
|4  K   Ca  Sc  Ti  V   Cr  Mn  Fe  Co  Ni  Cu  Zn  Ga  Ge  As  Se  Br  Kr |
|                                                                          |
|5  Rb  Sr  Y   Zr  Nb  Mo  Tc  Ru  Rh  Pd  Ag  Cd  In  Sn  Sb  Te  I   Xe |
|                                                                          |
|6  Cs  Ba  *   Hf  Ta  W   Re  Os  Ir  Pt  Au  Hg  Tl  Pb  Bi  Po  At  Rn |
|                                                                          |
|7  Fr  Ra  **  Rf  Db  Sg  Bh  Hs  Mt  Ds  Rg  Cn  Nh  Fl  Mc  Lv  Ts  Og |
|__________________________________________________________________________|
|                                                                          |
|                                                                          |
| Lantanoidi*   La  Ce  Pr  Nd  Pm  Sm  Eu  Gd  Tb  Dy  Ho  Er  Tm  Yb  Lu |
|                                                                          |
|  Aktinoidi**  Ac  Th  Pa  U   Np  Pu  Am  Cm  Bk  Cf  Es  Fm  Md  No  Lr |
|__________________________________________________________________________|
");
    foreach (string[][] group in elements)
    {
        // get the name of the element, and print it but change the background color depending on the group
        foreach (string[] element in group)
        {
            // if the element is in the first group, print it in red
            if (group == elements[0])
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine(element[0]);
            }
            else if (group == elements[1])
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(element[0]);
            }
            else if (group == elements[2])
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine(element[0]);
            }
            else if (group == elements[3])
            {
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine(element[0]);
            }
            else if (group == elements[4])
            {
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.WriteLine(element[0]);
            }
            else if (group == elements[5])
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(element[0]);
            }
            else if (group == elements[6])
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine(element[0]);
            }
            else if (group == elements[7])
            {
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.WriteLine(element[0]);
            }
            else if (group == elements[8])
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine(element[0]);
            }
            else if (group == elements[9])
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(element[0]);
            }
            // cantidad de elementos en la tabla
        }

    }
    // cantidad de elementos en el array de arrays
    Console.ResetColor();
    Console.Write("Ingrese el simbolo del elemento: ");
    string elementName = Console.ReadLine();
    foreach (string[][] group in elements)
    {
        foreach (string[] element in group)
        {
            if (element[0] == elementName)
            {
                Console.WriteLine(@$"
    __________________________________________________________________________
    |                                                                          |
    |   Nombre: {element[1]}  |  Numero atomico: {element[3]}  |  Masa atomica: {element[2]}  |
    |__________________________________________________________________________|
");
            }
            else
            {
                Console.WriteLine("Elemento no encontrado");
            }
        }
    }
}
