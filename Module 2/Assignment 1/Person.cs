using System;

namespace Assignment_1
{
    internal class Person
    {
        public string FirstName {  get; }
        public string LastName { get; }
        public string Email {  get; }
        public DateTime DateOfBirth {  get; }

        public bool Adult { 
            get 
            {
                return DateTime.Now.Year - DateOfBirth.Year > 18;
            } 
        }

        public string SunSign
        {
            get
            {
                int day = DateOfBirth.Day;
                int month = DateOfBirth.Month;

                switch (month)
                {
                    case 1:
                        return day <= 19 ? "Capricorn" : "Aquarius";
                    case 2:
                        return day <= 18 ? "Aquarius" : "Pisces";
                    case 3:
                        return day <= 20 ? "Pisces" : "Aries";
                    case 4:
                        return day <= 19 ? "Aries" : "Taurus";
                    case 5:
                        return day <= 20 ? "Taurus" : "Gemini";
                    case 6:
                        return day <= 21 ? "Gemini" : "Cancer";
                    case 7:
                        return day <= 22 ? "Cancer" : "Leo";
                    case 8:
                        return day <= 22 ? "Leo" : "Virgo";
                    case 9:
                        return day <= 22 ? "Virgo" : "Libra";
                    case 10:
                        return day <= 23 ? "Libra" : "Scorpio";
                    case 11:
                        return day <= 21 ? "Scorpio" : "Sagittarius";
                    case 12:
                        return day <= 21 ? "Sagittarius" : "Capricorn";
                    default:
                        return "Unknown";
                }

            }
        }

        public string ChineseSign
        {
            get
            {
                string[] chineseZodiac = { "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig" };
                return chineseZodiac[DateOfBirth.Year % 12];
            }
        }

        public bool Birthday
        {
            get
            {
                return DateTime.Now.Month == DateOfBirth.Month && DateTime.Now.Day == DateOfBirth.Day;
            }
        }

        public Person(string firstName, string lastName, string email, DateTime dob)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DateOfBirth = dob;
        }

        public string ScreenName
        {
            get
            { 
                return FirstName[0] + LastName + DateOfBirth.Month + DateOfBirth.Day + (DateOfBirth.Year % 100); ;
            }
        }

        public Person(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
        public Person(string firstName, string lastName, DateTime dob)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dob;
        }

        
    }
}
