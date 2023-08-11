namespace crush
{
    class Program
    {
        static void Main(string[] args)
        {
            string frase = "Hola, Luis me podrías ayudar con mi tarea? 😁";
            Console.WriteLine(frase);
            if (MePideAyuda(frase))
            {
                InvitarCafe();
            }
            else
            {
                LloraEnCS();
            }
        }

        static bool MePideAyuda(string frase)
        {
            if (frase.Contains("ayuda"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void InvitarCafe()
        {
            Console.WriteLine("Si pero sí me permites invitarte un café ☕");
            Console.Write(@"
KKKKKKKKKKKKKKKKK00000000000000000000000000000KKKKKKK0OOOOOOOOOOOO0OOkOO00000K0OOOOOOOO0Okkkkkkkkxl;,,;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;,,,,,,,,,,,,,,
KKKKKKKKKKKKKKKK000000000000000000000000000000KKKKKKK0OOOOOOOOOOOO0OOOOO0000KK0OOOOOOOO0Okkkkkkkkxl;,,;;;;;;;;;;;;;;,;;;;;;;;;;;;;;;;;;,;;,,;;,,,,,,,,
KKKKKKKKKKKKKKKK000000000000000000000000000000000KKKK0OOOOOOOOOOOO0OOOOO0000KK0OOOOOOOO0OOkkkkkkkxl;;;;;;;;;;;;;,,,,,,,;;;;;;,,,,;,,,,,,;;;;;;;;,,,,,,
KKKKKKKKKKKKKKKK000000000000000000000000000000000KKKK0OOOOOOOOOOOO0OOOOO00000K0OOOOOOOO0OOkkkkkkkxl;;;;;;;;;;;;;;,;;;;;;;,,,;,,,;;;,,,,,,,,,;;;;,,,,,,
KKKKKKKKKKKKKKK000000000000000000000000000000000KKKKK0OkOOOOOOOOOO0OOkOO0000000OOOOOOOO0OOkkkkkkkxl:;;;;;;;;;;;;;;;;;;;,,,,,,,,;;;;;;;,,;;,,,,,;;;,,,;
KKKKKKKKKKKKK0000000000000000000000000000000000KKKKKK0OkOOOOOOOOOO0OOOOO0000000OOOOOOOOOOkkkkkkkkxl:;;;;;;;;;;;;;;;;;;;;;;;;;;,;;,,;;;;;;;,,,,;;;;;;;;
KKKKKKKKK000000000000000000000000000000000000000KKKKK0OkOOOOOOOOOO0OOkOO0000000OOOOOOOOOOkkkkkkkkdl:;;;;;;;;;;;;;;;;;;;;;;;;,,,,,,,,;;;;;;;;;;;;;;;;;;
KKKKKKKK000000000000000000000000000000000000000000KKK0OOOOOOOOOOOO0OOkOO0000000OOOOOOO00Okkkkkkkkdl:;;;;;;;;;,,,,,,;;;;;;;;;,,,,,,,,;;;;;;;;;;;;;;;;;;
KKKKKKKKK00000000000000000000000000000000000000000KKK0OkOOOOOOOOOO0OOkOOO000000OOOOOOO0OOkkkkkkkxdc;;;;,;;;;;;;;,,;;;;;;;;;;,,,,,,,,,;;;;;;;;;;;;;;;;;
KKKKKKKKK000000000000000000000000000000000000000000KK0OkOOOOOOOOOO0OOkOOO000000OOOOOOOOOOkkkkkkkxoc;;;,,,;,,,;;;;;;;;;;;;;;;,,,,,,,,;;;;;;,;;;;;;;;;;;
KKKKKKKK0000000000000000000000000000000000000000000000OOOOOOOOOOOOOOOOOOO000000OOOOOOOOOOkkkkkkxdoc:;;;,,,,,,,;;;;;;;;;;;;;;,,,,;;;;;;;;,,,;;;;;;;;;;;
KKKKKKKK000000000000000000000000000000000000000000000OOOOOOkkkkkkOOOkkkOOOOOOOOkkkkkkkkOkkkkxxxddoc::;;;,,,,,,,;;;;,,,;,,;,,,,,;;;;;;;;;;;;;;;;;;;;;;;
KKKKKKKK00000000000000000000000000000000000000000000Okkkkkxxddddddddddddxxxxdddooooooodddooooollllcc:;;;;;;;;;;;;;,,,,,,,,,,,,,;;;;;;;;;;;;;;;;;;;;;;;
KKKKKKKK000000000000000000000000000000000000000OOOkxxdddooollllllllllllllllllllllllllllllllcccccccc:::;;;;;;;;;;;;;,,,;;;,,,,,;;;;;;;;;;;;;;;;;;;;;;;;
KKKKKKK000000000000000000000000000000000000OOkxxdoollllcccccccccccccccccccccccccccccccccccccccccc:::::::::::::::;;;;;,,,,,,,,,;;;;;;;;;;,,,,;;;;;;;;;;
KKKKKKK000000000000000000000000000000000Okxdollcccccc::::::::::::::::ccccccccccccccccccccccc:::::::::::::;:::::;;;;;;;;;,,,,,,,,;;;;;;;;,,,,,;;;;;;;;;
KKKKKKKKKKKK000000000000000000000000OOkxdolcc:::::::::;;;;;;;;;;;;:::::ccc:::::::cccccccccc::::::::::::;;;;;;;;;;;;;;;;;;;,,,,,,;;;;;;;;;,,,;;;;;;;;;;
KKKKKK0000000000000000000000000000Okdlcc:::::;;;;;;;;;;;;;;;;;;;;;;;;:::::::::::::::::::::::::::::::::;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
KKKKKKK0000000000000000000000000Oxoc:;;::::;;;;,,,;;;,,,,,,,,,,,,,,,;;;;;;::;;;;;;;;:::::::::::::::::::::;;;;:;;;;;::::::;;;;;;;;::::::::::;;;;;;;;;::
KKKKKKKK000000000000000000000Okdlc;;;;;;;;;,,,,,,,,,,,,,,,,''''''',,,,,;;;;;;;;;;;;;;:::::::::::::::::::::::::::;;;;;;;::::;;;;;;:::cllllllllccccccccc
KKKKKKK00000000000000000000Oxoc:;;;;:;;;;,,,,,,,,,,,,'''',''''''''''',,,,,,,;;;;;;;;;;;::::::::::::::::::::::::::;;;;;;;;;;;;;;;;;;::clooododdddoooooo
KKKKKKK000000000000000000Oxl:;,,;;;;;;;;,,,,,,,,''''''''''''''...''''',,,,,,,,;;;;;;;;;;:::::::::::::::::::::::::::;;;;;;;;;;;;;;;;;;::loodddddddddddd
KKKKKK00000000000000000Oxl:,,,,,;;,,,,,,,,,,,,''''''''''...........'''''''',,,,,;;;;;;;;;;;;;;;;;;::::::::::::::::::::;;;;;,,,;;;;;;;;;:codddddddddddd
KKKKKKK000000000000000Odc;,,,,,,,,,,,,,,,,,''''''''''''...........''''''''''',,,,,;;;;;;;;;;;;;;;;;;;;;;;;;;::::::::::::;;;,,,;;;::::;;;:loddddddddddd
KKKKKKK0000000000000Oxl:,,,,,','''''''''''''''''''.....................'''''''',,,,,,,,,,,,,;;;;;;;;;;;;;;;;;;;;::::;::;;;;,,;;;;:::::;;:clodddddddddd
KKKKKKKKK000000000Oxo:;,,,,'''''''''''''''''''''..................'...'''''''''''',,'''''',,,,;;;;;,,,;;;;;;;;;;;;;;;;:;;;;,;;;;;;:::;;;;clooddddddddd
KKKKKKKKKK000000Okoc;,,,,'''''''''''''''''''''....................'...'..''''''''''''''''''',,,,,,,,,,,,,;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;::looddddddddd
KKKKKKKK0000000Oxl;,,,'''''''.............................................''''''''''''''''''''',,,,,,,,,,,;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;::cloddddddddd
KKKKKKK0000000Odc;,,,'''''''..............................................''''''''''''''''...''''''''',,,,;;;;::;;;;;;;;,,;;;;;;;;;;;;;;:::coodddddddd
KKKKKKK00000Okdc;,,,''''''''...................................''''''.....'''''''''''''''''....'''''''',,,;;::cc::;;;;;;;;;;;;;;;;,;;;;;;::clodddxxxxx
KKKKKKK0000Oxl:;,,,''''''''...................................'''''''''''''''''''''''''''''''.......'''',,;:cclllc::;;;;;;;;;;,,,,,,,;;;;;;:cloddxxxxx
KKKKKKK000kdc;,,,,,,,'''''''''''''...'''''''''................'''''''''''.''''''''''''''''''''.......''',,;:coodollc:;:::;;,'.',;;,'',;;;;;::looddxxxx
KKKKKKK00koc;,,,,,,,,,'''''''''''''''''''''''''...............'''''''''''.''''''''''''''''','''''....'''',;cldxxddol:::;,;c,...,::;'.,;::;;;:cloddxxxx
KKKKKK0Oxo:;,,,,,,,,,,,''''''''''''''''''''''''................'''''''''...'...............''',,,'''''''',:coxkkkxdlc:;'.;l;...,;:;'.';:::;;::clodxxxx
KKKKK0kdc;;,,,,,,,,,,,,''''''''''''''''''''''''..................'''''........................',,,,,,''',;:ldkOOOkdlc:,...'.....,;,'.':cc:;;;:clodxxxx
KKKK0ko:;,,,,,,,,,,,,,,''''''''''''''''''''''''..................'''....''........'::'...'''...'',,,,,,,,;coxkOOOkxoc:'.........','..,:cc:;;;::lodxxxx
KK0Oxl;,,,,,,,,,,,,,,,,,,,,,,,,,,''''''''''''''................'''''..''''.... . .,c;....,;,'....',,,,,,;:cdxOO00Oxol:'.........''..';ccc:;;;:clodxxxx
K0Oxc;,',,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,''''''''''''..........'''''''',,,'...    ........',;,'....',;;;;;:ldkO000Okxoc;'.......'''',;ccc::::::clodxxxk
0Odc;,'',,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,'''''''''''.......''''',,,,,,,,'...         ..',;;,'.....',;;::coxkO0000Okxoc;,''',,,;;::ccc:::::::cclodxxxx
Odc;,'',,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,''''''''''''''''''',,,,,;;;;;,'.....     ...,;;,''.....',,;::ldkOOO000OOkxolc::::ccccccccc:::::::cloddxxxx
o:,,'',,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,''',,,,,,,,,,'''''',,,,,;;;;:;;,,'.........,,,,''''....'',,;coxOOOOOO0OOOkxdddoooooooollcccc:::ccclddxxxxx
:,'''',,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,''',,,,,,,,,,,,,''''''',,,;;;;;;;;;,'''.''',,,,,,,;,,''''',;:oxkOOOOOOOO00OOOkkkkkkkkxxddoollcccccloddxxxkk
,''''',,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,;;;;;;;;;;;;;;;;;;;;;;;;;,,,,,:coxkkkOOOOOOO0000000000000OOOkxxddoolllooddxxkkk
''''',,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,;;;;;;;;;;;;;;;;;;;;;;;;;:cldxkkkkkkOOOOO000000000KKKK000OOkkxxddoooddxxxkkk
'',,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,;;:ccodxkkkkkkkkkkOOOOOOO000000KKKK0000OOkkxddoddxxxxkkk
,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,''',,,,,,,,;:cldxkkkkkkkkkxxkkkkkkkkkkOO000KKK00000OOkkxdddxxxxkkkk
,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,''',,,,,;:clodxkkkOOkkkkxxdddddddxxxxkO000000000OOOOkxddddxxxkkkkk
,,,,;;;;,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,;;;:cclodxxkkkkkkkkkkxddooooodddxkkO00000000OOOOkxdddxxxkkkkkkk
,,,;;;;;;;,,,,',,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,;;:cllooddddxxxkkkkkkkkkkkxxxdoooooodxkO0000000OOOkkxxdddxxkkkkkkkkk
,,;;;;;:;;;;,,,'''''''',,,,,,,,,,,,,,,''',,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,;;;;::ccoddxxxxxkkkkkxkkkkkkkkkkOOkkxxdooodxkOOOOOOOOOkkkxxddxxkkkkkkkkkkk
;;;;:::::::;;,,''''''''''',,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,'''',,,,,,,,;;;;:::::cccloodddxxxxkkkxxxxxxxkkkkkOOOOkkkxolodxkkkkkkkkkkkxxxddxxkkkkkkkkkkkk
;;::::::::::;;,,,,''''''''',,,,,,,,,,,,,,,,,,,,,,,,,,,,,,',,,,,,,,,,;;;::cccccccccclloooddxxxxxxxxxxxxxxkkkkkkkkxxolllodxxxxxkkkxxxxxxxxxkkkkkkkkkkkkk
;;;:::::::::::;;,,,'''''''',,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,;;::ccllllccc::cccccccllooddddxxxxxxxxxxkkkkxxddolccloodddxxxxxxxxkkkkkkkkkkkkkkkkkkk
,;;;;;:::ccccc::;,,''''''''''''',,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,;;:cloooooolllcccccccccccllllooodddddxxxxxxxdddoollllllodddxxxxkkkkkkkkkkkkkkkkkkkkkkkk
,,;;;:::cccccccc:;,,'''''''''''',,,,,,,,,,,,,,,,,,,,,,,,,,,,;;;:cloodddddoooollooolllllllllllllooooddddddooooollllooooddxxxkkkkkkkkkkkkkkkkkkkkkkkkkkk
,;;;:::ccllllllcc:;;,,,'''''''',,,,,,,,,,,,'',,,,'',,,,,,,,;;;:cloddddddddoooooooooooooooooollllllloooooooooooooddddxxxxxkkkkkkkOOOOOkkkkkkkkkkkkkkkkk
;;:::ccllllllllllccc:;;,,,'''''''',,,,,,,,,,,,'''',,,,,,,,;;;:clddxxddddddddddddoooooooooooooooooooooooooooooddddddxxxkkkkkkkkOOOOOOOkkkkkkkkkkkkkkkkk
::ccclllllllllllllllcc::;;,,,,'''''''''',,,,,,,,,,,,,;;;;;;:cloddxxxdddddddddddddddooooooooooooooooooooooooddddddxxxxkkkkkkkOOOOOOOOOkkkkkkkkkkkkkkkkk
ccclllllllllllllllllllllcc:;;,,,,,,,,,,,,,,,,,,,,;;;;:::::cloddxxxxxxxxxxxxxxxxdddddddooooooooooooooooooodddddddxxxxkkkkkkkOOOOOOOOOOkkkkkkkkkkkkkkkkk
clllllloooooolllllllllllllcc::;;;;;;;;;,,,,,;;;;::ccclllooodddxxxxxxxxxxxxxxxxxxxxddddddooooooooooooooddddddddxxxxxkkkkkkkOOOOOOOOOOOkkkkkkkkkkkkkkkkk
lllloooooooooollllllllllllllccccccccc::::::::cccllooooddddddxxxxxxxxxxxxxxxxxxxxxxxxdddddooooooooodddddddddxxxxxxxkkkkkkkOOOOOOOOOOOkkkkkkkkkkkkkkkkkk
ooooooooooooooooollllloollllllllllllllllllllllooooddddddddxxxxxxxxxxxxxxxxxxxxxxxxxxxxdddddddddddddddddddxxxxxxxkkkkkkkkOOOOOOOOOOOOOkkkkkkkkkkkkkkkkk
ooooooooooooooooooooooollooooooooooooooooooooooodddddddddxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxdddddddddddxxxxxxxxxkkkkkkkkOOOOOOOOO0000OOOOOkkkkkkkkkkkkkkk
ddddddddddddoooooooooooooooooooooooooooooooooooodddddddddxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxkkkkkkkkkkkOOOOOOOO000000000OOOOkkkkkkkkkkkkkk
ddddddddddddddddooooooooooooooooooooooooooooooooddddddddxxxxxxxxxxxxxxxxxxxxxxxxxxkkkkxxxxxxxxxxxxxkkkkkkkkkkkkkOOOOOOOO0000000000000OOOOOkkkkkkkkkkkk
oooodddddddddddddddddddddddddddddoooooooooooooodddddddddxxxxxxxxxxxxxxxxxxxxxxxxxxkkkkkkkkkkkkkkkkkkkkkkkkkOOOOOOOO000000000KKKKKKK0000OOOOkkkkOOkkkkO
:clloddddddddxxxxdddxxddxxxxxxxxxdddddddddddddddddddddddxxxxxxxxxxxxxxxxxxxxxxxxxxkkkkkkkkkkkkkkkkkkkOOOOOOOOOO00000000000KKKKKKKKKKKK000OOOOOOOOOOOOk
;;cllodddxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxddxxxxxxxxxxxxxxxxxxxxxxxxxxkkkkkkkkkkkkkkkkkOOOOOOOOOOOO0000000000KKKKKKKKKKKKKKKKKKK0000OOOOOOOOOO
;;:ccclooddxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxkkkkkkkkkkkkkkkkkkkkkkkOOOOOOOOOOOOO00000000000000000000KKKKKKKKKKKKKKKKKKKKKK000OOOOOOOO
;;:::ccclodddxxxxxxxxxxxxxxxxxxxxxxxkkkkkkxxxxxxxxxkkkkkkkkkkkkOOkkOOOOOOOOOOOOOOOOOOOOOOOOOOO0000000000000000000K00KKKKKKKKKKKKKKKKKKKKKKKKKK000OOOOO
;;;:;::cllooddxxxxxxxxxxxxxxxxxxxxkkkkkkkkkkkkkkkkkkkkkkkkOOOOOOOOOOOOOOOOOOOO000000000000000000000KKK0KKKK00000KKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKK00Okkk
,,,;;;:ccclloddxxxxxxxxxxxxxxxxxxxxkkkkkkkkkkkkkkkkkkkkkkOOOOOOOOOOOOOOOOO0000000000000000000000KKKKKKKKKKKKK00KKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKK00OOkx
,,,;;;::::cllooddxxxxxxxxxxxxxxxxxxxkkkkkkkkkkkkkkkkkkkkkOOOOOOOOOOOOO00OO00000000000000000KKKKKKKKKKKKKKKKKKKKKKKKKK00KKKKKKKKKKKKKKKKKKKKKKKKKKK00Ok
',,,;;;;;:cclloodddxxxxxxxxxxxxxxxxxxkkkkkkkkkkkkkkkkkkkkkOOOOOOOOOOOOOOOOO0000000000000000KKKKKKKKKKKKKKKKKKKKKKK0KKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKK0O
,,,,,,;;;;:cclloodddxxxxxxxxxxxxxxxxxxkkkkkkkkkkkkkkkkkkkkkkOOOOOOOOOOOOOOOO000000000000000KKKKKKKKKKKKKKKKKKKKKK000KKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKK0


            ");
        }
        static void LloraEnCS()
        {
            Console.WriteLine("Sad Puppy Face");
        }
    }
}