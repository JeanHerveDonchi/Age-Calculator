
using System;

/*Code snippet to calculate user age and display
    things left
    -while and do while loops in case of any invalid data
    -Catch exceptions and handle
    -Testing and Debbuging
    -Rearrange user input to ask year, month and day separately
    -Check if counter can be displayed on console.
*/

//Get the user's birthdate as input
Console.Write("Enter your birthdate (yyyy-MM-dd): ");
if (DateTime.TryParse(Console.ReadLine(), out DateTime birthDate))
{
    bool checker = true;
    // Check if the birthdate is valid
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

        //Show time until next anniversary
        while (checker == true)
        {
            TimeSpan timeUntilAnniversaryTemp = nextAnniversary - DateTime.Now;

            //Console.Clear();
            Console.WriteLine(
                $"You have: " +
                $"{timeUntilAnniversaryTemp.Days} days, " +
                $"{timeUntilAnniversaryTemp.Hours} hours, " +
                $"{timeUntilAnniversaryTemp.Minutes} minutes, " +
                $"{timeUntilAnniversaryTemp.Seconds} seconds " +
                $"Until your next anniversary"
                );
            Thread.Sleep(1000);
            checker = false;
        }

        //generate random number of remaining years to leave, and Use helper method to generate Random date of death
        Random random = new Random();
        int yearsRemaining = random.Next(90);
        if (yearsRemaining > 0)
        {
            int lifeExpectancy = age + yearsRemaining;
            DateTime dateOfDeath = GenerateRandomDate(lifeExpectancy);
            int ageOfDeath = dateOfDeath.Year - DateTime.Now.Year;
            DisplayDeathInfo(dateOfDeath, ageOfDeath, age);
        }
        else
        {
            int monthsRemaining = random.Next(12);
            if (monthsRemaining > 0)
            {
                DateTime dateOfDeath = DateTime.Now.AddMonths(monthsRemaining);
                int ageOfDeath = dateOfDeath.Year - DateTime.Now.Year;
                DisplayDeathInfo(dateOfDeath, ageOfDeath, age);
            }
            else
            {
                int daysRemaining = random.Next(31);
                if (daysRemaining > 0)
                {
                    DateTime dateOfDeath = DateTime.Now.AddDays(daysRemaining);
                    int ageOfDeath = dateOfDeath.Year - DateTime.Now.Year;
                    DisplayDeathInfo(dateOfDeath, ageOfDeath, age);
                }
                else
                {
                    int hoursRemaining = random.Next(23);
                    if (hoursRemaining > 0)
                    {
                        DateTime dateOfDeath = DateTime.Now.AddHours(hoursRemaining);
                        int ageOfDeath = dateOfDeath.Year - DateTime.Now.Year;
                        DisplayDeathInfo(dateOfDeath, ageOfDeath, age);
                    }
                    else
                    {
                        int minutesRemaining = random.Next(60);
                        if (minutesRemaining > 0)
                        {
                            DateTime dateOfDeath = DateTime.Now.AddMinutes(minutesRemaining);
                            int ageOfDeath = dateOfDeath.Year - DateTime.Now.Year;
                            DisplayDeathInfo(dateOfDeath, ageOfDeath, age);
                        }
                        else
                        {
                            int secondsRemaining = random.Next(40, 60);
                            DateTime dateOfDeath = DateTime.Now.AddSeconds(secondsRemaining);
                            int ageOfDeath = dateOfDeath.Year - DateTime.Now.Year;
                            DisplayDeathInfo(dateOfDeath, ageOfDeath, age);
                        }
                    }
                }
            }
        }
    }
}
else
{
    Console.WriteLine("Invalid date format. Please enter the date in yyyy-MM-dd format.");
}

static DateTime GenerateRandomDate(int years)
{
    Random random = new Random();
    DateTime startDate = DateTime.Now;
    DateTime endDate = startDate.AddYears(years);
    TimeSpan timeSpan = endDate - startDate;
    TimeSpan newSpan = new TimeSpan(0, random.Next(0, (int)timeSpan.TotalMinutes), 0);
    DateTime newDate = startDate + newSpan;
    return newDate;
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

static void DisplayDeathInfo(DateTime dateOfDeath, int ageOfDeath, int currentAge)
{
    bool checker = true;
    Console.WriteLine($"You will die at the age of: {ageOfDeath} \n\r" +
                                    $"Date of death: {dateOfDeath}"
                                    );
    while (checker == true)
    {
        TimeSpan timeUntilDeath = dateOfDeath - DateTime.Now;
        //Console.Clear();
        int years = ageOfDeath - currentAge;

        int year = timeUntilDeath.Days/365;
        int months = (timeUntilDeath.Days/30) - (year * 12);
        int days = timeUntilDeath.Days - (year * 365);
        int hours = timeUntilDeath.Hours;
        int minutes = timeUntilDeath.Minutes;
        int seconds = dateOfDeath.Second;

        Console.WriteLine(
            $"You have " +
            $"{years} years, " +
            $"{months} months, " +
            $"{days} days, " +
            $"{hours} hours, " +
            $"{minutes} minutes, " +
            $"{seconds} seconds " +
            $"Left to Die !!!");
        Thread.Sleep(1000);
        checker = false;
    }

}
