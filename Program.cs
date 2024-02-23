

using AddressBook_W_ADO;


internal class Program
{
    public static void Main(string[] args)
    {
        int choice;
        try
        {
            do
            {
                Console.WriteLine("Welcode Address Book");
                Console.WriteLine(" 1.Add NewContact\n 2.ShowDetailsALlContact\n 3.Edit Contact \n 4.Delete Contact \n 5.View Contact City \n 6.view contact State \n 7.Exit");
                Console.WriteLine("Enter you choice");
                choice = Convert.ToInt32(Console.ReadLine());
                AddEmployee AddEmpobj1 = new AddEmployee();

                switch (choice)
                {
                    case 1:
                        AddEmpobj1.AddDetails();
                        break;
                    case 2:
                        AddEmpobj1.ShowDetail();
                        break;
                    case 3:
                        AddEmpobj1.EditContact();
                        break;
                    case 4:
                        AddEmpobj1.Delete();
                        break;
                    case 5:
                        AddEmpobj1.FindDetailCityWise();
                        break;
                    case 6:
                        AddEmpobj1.FindDetailStateWies();
                        break;
                    case 7:
                        Console.WriteLine("EXIT");
                        break;
                    default:
                        Console.WriteLine("invalid choice");
                        break;
                }

            } while (choice != 7);
        }
        catch (Exception e)
        {
            Console.WriteLine("String Not allowed");

        }
    }
}