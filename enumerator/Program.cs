using System;

namespace enumerator
{

    public class Program
	{
		static void Main(string[] args)
		{
            Console.WriteLine("Choose any of the enum: 'Pln', 'Usd', 'Eur' \n note: write this as it is listed!");
            string response = Console.ReadLine() ?? "";
           
            if (!Enum.TryParse(response, true, out CurrencyEnum cE))
            {
                Console.WriteLine("Invalid Currency");
                return;
            }
            switch (cE) 
			{
			   case CurrencyEnum.Pln:
                    Console.WriteLine("Polish zloty!");
                    break;
               case CurrencyEnum.Usd:
                    Console.WriteLine("American Dollars!");
                    break;
                default:
                    Console.WriteLine("European euros.");
               break;
            }

            Console.WriteLine();

            ActionEnum guest = ActionEnum.List;
            ActionEnum user = ActionEnum.List | ActionEnum.Details;
            ActionEnum editor = ActionEnum.List | ActionEnum.Add | ActionEnum.Edit;

            TestActions("Guest", guest);
            TestActions("User", user);
            TestActions("Editor", editor);

            
            (int Age, string Name, char sex) Statistics = Calculate();
            Console.WriteLine($"{Statistics.Name}\n{Statistics.Age}\n{Statistics.sex}");
            Console.ReadKey();

         }
         
        static (int Age, string Name, char Sex) Calculate()
        {
            Console.WriteLine("Enter your name?");
            string name = Console.ReadLine() ?? "Unknown";

            Console.WriteLine("Enter your age:");
            int age;
            if (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Invalid age");
                age = 0;
            }
           

            Console.WriteLine("State your sex : (M), (F), (O)");
            string sex = Console.ReadLine() ?? "";
            sex = sex.ToUpper();
            char gender;

            if (sex.StartsWith('M'))
            {
                gender = 'M';
            }else if (sex.StartsWith('F'))
            {
                gender = 'F';
            }else if (sex.StartsWith('O'))
            {
                gender = 'O';
            }
            else
            {
                gender = 'X';
                //X depicts unknown
            }

            return (age, name, gender);
        }

        static void TestActions(string role, ActionEnum actions)
        {
            Console.WriteLine($"{role} permission: {actions}");

            if (actions.HasFlag(ActionEnum.List))
                Console.WriteLine(" == You can view list");

            if (actions.HasFlag(ActionEnum.Details))
                Console.WriteLine(" == You can view details");

            if (actions.HasFlag(ActionEnum.Add))
                Console.WriteLine(" == You can add");

            if (actions.HasFlag(ActionEnum.Edit))
                Console.WriteLine(" == You can edit");

            if (actions.HasFlag(ActionEnum.Delete))
                Console.WriteLine(" == You can delete");

            if (actions.HasFlag(ActionEnum.Publish))
                Console.WriteLine(" == You can publish");

            Console.WriteLine();
        }


    }
    //Enums are declared at the end of the namespace if all classes are in the same place. 
    enum CurrencyEnum { Pln, Usd, Eur };

    [Flags]
    enum ActionEnum
    {
        None = 0b_0000_0000,
        List = 0b_0000_0001,
        Details = 0b_0000_0010,
        Add = 0b_0000_0100,
        Edit = 0b_0000_1000,
        Delete = 0b_0001_0000,
        Publish = 0b_0010_0000,
            Yolo = 11
    }
}

