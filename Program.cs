
using System;

/*Code snippet to calculate user age and display
    things left
    -while and do while loops in case of any invalid data
    -Catch exceptions and handle
    -Testing and Debbuging
    -Rearrange user input to ask year, month and day separately
    -Check if counter can be displayed on console.
*/

        // Get the user's birthdate as input
        Console.Write("Enter your birthdate (yyyy-MM-dd): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime birthDate))
        {
            // Check if the birthdate is in the future
            if (birthDate > DateTime.Now)
            {
                Console.WriteLine("Invalid birthdate. Please enter a valid date in the past.");
            }
            else
            {
                // Calculate the age
                int age = CalculateAge(birthDate);
                Console.WriteLine($"Your age is: {age} years");

                // Calculate and display the countdown to the next anniversary
                DateTime nextAnniversary = birthDate.AddYears(age + 1);
                TimeSpan timeUntilAnniversary = nextAnniversary - DateTime.Now;
                if (timeUntilAnniversary.Days == 365)
                {
                    Console.WriteLine("Congratulations its your birthday");
                }
                Thread.Sleep(2000);
                
                Console.WriteLine("Press enter to know when is your next birthday");
                Console.ReadLine();

                while (true)
                {
                    TimeSpan timeUntilAnniversaryTemp = nextAnniversary - DateTime.Now;
                    Console.Clear();
                    Console.WriteLine($"Time until your next anniversary: {timeUntilAnniversaryTemp.Days} days, {timeUntilAnniversaryTemp.Hours} hours, {timeUntilAnniversaryTemp.Minutes} minutes, {timeUntilAnniversaryTemp.Seconds} seconds");
                    Thread.Sleep(1000);
                }     
            }
        }
        else
        {
            Console.WriteLine("Invalid date format. Please enter the date in yyyy-MM-dd format.");
        }

    static int CalculateAge(DateTime birthDate)
    {
        DateTime currentDate = DateTime.Now;
        int age = currentDate.Year - birthDate.Year;

        // Check if the birthdate hasn't occurred this year yet
        if (currentDate < birthDate.AddYears(age))
        {
            age--;
        }

        return age;
    }

