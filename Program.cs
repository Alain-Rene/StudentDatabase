/*
Program that recognizes valid user inputs, allowing the user to learn more about students in a class
*/

//variable declaration
bool runProgram = true;

string[] names = new string[]
{
    "Justin Jones",
    "DeAngelo Robinson",
    "Martina Basquez",
    "Alain Rene",
    "David Goodwin",
    "Joey Molinski",
    "Wren Grasley",
    "Brady Hartman",
    "David Brameijer",
    "Afseen Salam",
    "Ethan Thomas"
};

string[] hometowns = new string[]
{
    "Westerville",
    "Detroit",
    "Edinburg",
    "Homestead",
    "Jersey City",
    "Toledo",
    "Richmond",
    "Saranac",
    "Grand Rapids",
    "India",
    "Bolivar"
};

string[] favoriteFoods = new string[]
{
    "Baja Blast",
    "Pizza",
    "Leftovers",
    "Chicken Wings",
    "Sushi",
    "Dill Pickles",
    "Pizza",
    "Chicken Wings",
    "Tacos",
    "Shawarma",
    "Grapes"
};


//Infinite loop for program
do{
    System.Console.WriteLine("Hello! Please type 1 if you would like to search for a student by number, or 2 if you would " +
    "like to search for a student by name! You may also type \"Students\" to see a list of all students");
    

    string userInput = Console.ReadLine();

    //If user inputs 1, they want to search for a student by number
    if(userInput == "1")
    {
        System.Console.WriteLine("In order to select which student you would like to learn more about, " +
        " please enter a number from 1 to 11.");
        userInput = Console.ReadLine();

        //Try to parse the string value, and if it
        if(int.TryParse(userInput, out int studentIndex))
        {
            if(studentIndex < 1 || studentIndex > names.Length)
            {
                 System.Console.WriteLine("Invalid number, please enter a number that coresponds to the students in the class");
            }
            else 
            {
                learnAboutStudent(names, hometowns, favoriteFoods, studentIndex);
                runProgram = questionUser(runProgram);
            }
        }
        else
        {
            System.Console.WriteLine("Invalid input, please try again.");
        } 
    } 
    //If user inputs 2, they want to search for a student by name
    else if(userInput == "2")
    {
        System.Console.WriteLine("In order to select which student you would like to learn more about," +
        " please enter that student's name.");
        userInput = Console.ReadLine();
        bool nameFound = true;
        for(int i = 0; i < names.Length; i++)
        {
            if(names[i].ToLower() == userInput.ToLower()){
                System.Console.WriteLine("This is the value of i: " + i);
                learnAboutStudent(names, hometowns, favoriteFoods, (i + 1));
                nameFound = true;
                runProgram = questionUser(runProgram);
                break;
            }
            nameFound = false;
        }
         
        if (nameFound == false){
            System.Console.WriteLine("Invalid name was entered, please try again");
        }
        
    }
    else if (userInput.ToLower() == "students")
    {
        for(int i = 0; i < names.Length; i++){
            System.Console.WriteLine($"Student #{i + 1} is: {names[i]}");
        }
    } 
    else
    {
        System.Console.WriteLine("Invalid input, please try again");
    }

} while(runProgram);

static bool questionUser(bool runProgram){
    string userInput;

    System.Console.WriteLine("Would you like to learn about another student? Please enter \"y/yes\" or \"n/no\"");
    userInput = Console.ReadLine();

    if(userInput.ToLower() == "yes" || userInput.ToLower() == "y")
    {
        return true;
    } 
    else if(userInput.ToLower() == "no" || userInput.ToLower() == "n")
    {
        return false;
    }
    else{
        System.Console.WriteLine("Invalid input, please try again");
    }
    return runProgram;
}

static void learnAboutStudent(string[] names, string[] hometowns, string[] favoriteFoods, int studentIndex){
    int fixIndexCount = studentIndex -1;
    bool validInput = true;

    do {
        System.Console.WriteLine($"What information would you like to know about {names[fixIndexCount]}? Please enter \"hometown\" " +
        "or \"favorite food\"");
        string userInput = Console.ReadLine();
        if (userInput.ToLower() == "hometown" || userInput.ToLower() == "home town")
            {
                System.Console.WriteLine($"The student {names[fixIndexCount]} is from {hometowns[fixIndexCount]}");
                break;
            } 
        else if(userInput.ToLower() == "favorite food" || userInput.ToLower() == "food")
            {
                System.Console.WriteLine($"The student {names[fixIndexCount]}\'s favorite food is {favoriteFoods[fixIndexCount]}");
                break;
            }
        else
            {
                System.Console.WriteLine("Invalid input, please try again.");
            }
        } while (validInput);
        
}