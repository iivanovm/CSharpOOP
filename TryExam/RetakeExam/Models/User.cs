using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models;


public class User : IUser
{
    private string firstName;
    private string lastName;
    private string drivingLicenseNumber;
    private const double increaserating = 0.5;
    private const double decreaserating = 2.0;


    public User(string firstName, string lastName, string drivingLicenceNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        DrivingLicenseNumber = drivingLicenceNumber;
    }

    public string FirstName
    {
        get => firstName;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.FirstNameNull);
            }
            firstName = value;
        }
    }


    public string LastName
    {
        get => lastName;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.LastNameNull);
            }
            lastName = value;
        }
    }

    public string DrivingLicenseNumber
    {
        get => drivingLicenseNumber;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.DrivingLicenseRequired);
            }
            drivingLicenseNumber = value;
        }
    }


    public double Rating {get; private set;}    

    public bool IsBlocked { get; private set; }

    public void DecreaseRating()
    {
        if (Rating - decreaserating < 0)
        {
            Rating = 0;
            IsBlocked = true;
        }
        else
        {
            Rating -= decreaserating;
        }
    }

    public void IncreaseRating()
    {
        if (Rating + increaserating > 10)
        {
            Rating = 10;
        }
        else
        {
            Rating += increaserating;
        }
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName} Driving license: {DrivingLicenseNumber} Rating: {Rating}";
    }
}
