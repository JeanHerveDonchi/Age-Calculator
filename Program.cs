
using System;
using NodaTime;
using NodaTime.Text;

/*Code snippet to calculate user age and display
    things left
    -while and do while loops in case of any invalid data
    -Catch exceptions and handle
    -Testing and Debbuging
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
        while (checker)
        {
            TimeSpan timeUntilAnniversaryTemp = nextAnniversary - DateTime.Now;

            //Console.Clear(); (to redisplay Counter)
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

        //////////////////////////////////////////////////////////////////////////////////////////////
        //Still brainstorming on this logic to make the app more scarier.. may add some other logics..
        bool mood = false;
        if (mood)
        {
            yearsRemaining = 0;
        }


        if (yearsRemaining > 0)
        {
            int lifeExpectancy = age + yearsRemaining;
            DateTime dateOfDeath = GenerateRandomDate(lifeExpectancy);
            int ageOfDeath = dateOfDeath.Year - birthDate.Year;
            DisplayDeathInfo(dateOfDeath, ageOfDeath);
        }
        else
        {
            int monthsRemaining = random.Next(12);
            if (monthsRemaining > 0)
            {
                DateTime dateOfDeath = DateTime.Now.AddMonths(monthsRemaining);
                DisplayDeathInfo(dateOfDeath, age);
            }
            else
            {
                int daysRemaining = random.Next(31);
                if (daysRemaining > 0)
                {
                    DateTime dateOfDeath = DateTime.Now.AddDays(daysRemaining);
                    DisplayDeathInfo(dateOfDeath, age);
                }
                else
                {
                    int hoursRemaining = random.Next(23);
                    if (hoursRemaining > 0)
                    {
                        DateTime dateOfDeath = DateTime.Now.AddHours(hoursRemaining);
                        DisplayDeathInfo(dateOfDeath, age);
                    }
                    else
                    {
                        int minutesRemaining = random.Next(60);
                        if (minutesRemaining > 0)
                        {
                            DateTime dateOfDeath = DateTime.Now.AddMinutes(minutesRemaining);
                            DisplayDeathInfo(dateOfDeath, age);
                        }
                        else
                        {
                            int secondsRemaining = random.Next(40, 60);
                            DateTime dateOfDeath = DateTime.Now.AddSeconds(secondsRemaining);
                            DisplayDeathInfo(dateOfDeath, age);
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

static void DisplayDeathInfo(DateTime dateOfDeath, int ageOfDeath)
{
    bool checker = true;
    Console.WriteLine($"You will die at the age of: {ageOfDeath} \n\r" +
                                    $"Date of death: {dateOfDeath}"
                                    );
        DateTime actualDateN = DateTime.Now;
        LocalDateTime actualDate = LocalDateTime.FromDateTime(actualDateN);
        LocalDateTime deathDate = LocalDateTime.FromDateTime(dateOfDeath);

        int[] timeDifference = CompareDates(actualDate, deathDate);
        int years = timeDifference[0];
        int months = timeDifference[1];
        int days = timeDifference[2];
        int hours = timeDifference[3];
        int minutes = timeDifference[4];
        int seconds = timeDifference[5];
    while (checker)
    {
        // //Console.Clear(); (to redisplay Counter)
        Console.WriteLine(
            $"You have " +
            $"{years} years, " +
            $"{months} months, " +
            $"{days} days, " +
            $"{hours} hours, " +
            $"{minutes} minutes, " +
            $"{seconds} seconds " +
            $"Left to Die !!!");
        Console.ReadKey();  
        checker = false;
    }
}


static int[] CompareDates(LocalDateTime startDate, LocalDateTime endDate)
{
    // Calculate the period between two dates
    Period period = Period.Between(startDate, endDate);

    // Extract years and months from the period
    int years = period.Years;
    int months = period.Months;
    int days = period.Days; 
    int hours = Convert.ToInt32(period.Hours); // Approximate value of remaining days;
    int minutes = Convert.ToInt32(period.Minutes);
    int seconds = Convert.ToInt32(period.Seconds);

    return new int[] {years,months,days,hours,minutes,seconds};
}


