using System;

namespace TrainStationManagementApp
{
    // This class is used for all the validation int the app
    public class Validator
    {
         // We use the class name to call static method
        public static int NumberValidator(string value)
        {
            int option = 0;
            if (int.TryParse(value, out int number))
            {
                option = number;
            }
            else
            {
                Console.Write("Wrong Input!: ");
                option = NumberValidator(Console.ReadLine());
                
            }

            return option;
        }
    }
}