using FileContent.CustomAttribute;
using System;
using System.Collections.Generic;
using FileContent.Interface;

namespace FileContent.Implementation
{
    [Description("Class that holds user data.")]
    public class Docs : IDocs
    {
        [Description("This is the id of user.")]
        public string? ID { get; set; }

        [Description("This properties is the Name of user.")]
        public string? Name { get; set; }

        [Description("This properties is the Address of user")]
        public string? Address { get; set; }

        [Description("This properties is the gender of user")]
        public string? Gender { get; set; }

        [Description("This properties is the country where the user comes from")]
        public string? Religion { get; set; }

        [Description("This is a default constructor.")]
        public Docs()
        {

        }

        [
            Description
            (
           description: "This contructor sets the properties and the value entered in the parameter of the contructor",
           input: "This constructor takens in user information [Id, Name, Address, Gender, Religion and returns",
            output: "User information accordingly as a string."
            )

        ]
        public Docs(string iD, string name, string address, string gender, string religion)
        {
            ID = iD;
            Name = name;
            Address = address;
            Gender = gender;
            Religion = religion;
        }

        [Description("This list holds information about users.")]
        public List<Docs> users = new List<Docs>();

        [Description("This method adds the new user to the list and also display the user on the console.")]
        public void DisplayUser()
        {
            users.Add(new Docs("1", "Kelechi Amos", "Nsukka Enugu state, Nigeria", "Male", "Christainity"));

            foreach (var user in users)
            {
                Console.WriteLine($"{user.ID} | {user.Name} | {user.Gender} | {user.Address} | {user.Religion}");
            }
        }
    }
}
