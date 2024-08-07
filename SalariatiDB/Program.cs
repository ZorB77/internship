// See https://aka.ms/new-console-template for more information
using SalariatiDB;



string option = "0";
Console.WriteLine("Bine ati venit la aplicatia salariala!");

while (option != "-1")
{
    int id = 0;
    Console.WriteLine("--------------------------------------");
    Console.WriteLine("Introduceti cifra pentru a alege optiunea dorita: \n1 - Afisare salariu angajat dupa id. \n2 - Actualizare salariu angajat dupa id. \n-1 - Oprire aplicatie");
    option = Console.ReadLine();
    switch (option)
    {
        case "1":
            // case 1 -> the second stored procedure in the problem -> get the salary of an employee by ID
            Console.WriteLine("Introduceti id-ul angajatului al carui salariu doriti sa-l AFISATI:");
            id = Convert.ToInt32(Console.ReadLine());
            OperatiiSalariale.AfisareSalariu(id);
            break;
        case "2":
            // case 2 -> the first stored procedure in the problem -> update the salary of an employee and it triggers an insert to a new table
            Console.WriteLine("Introduceti id-ul angajatului al carui salariu doriti sa-l ACTUALIZATI:");
            id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Introduceti noua valoare a salariului:");
            decimal salariu = Convert.ToDecimal(Console.ReadLine());
            OperatiiSalariale.ActualizareSalariu(id, salariu);
            break;
        case "-1":
            option = "-1";
            break;

            //finish switches
    }
}
