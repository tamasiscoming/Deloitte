public class SQLLogic
{
    /*
     1.      Adatbázis
    Adott 2 hasonló tábla - nem minden oszlop van felsorolva

    User
    Login (PRIMARY KEY CLUSTERED) [nvarchar](32) NOT NULL
    Name [nvarchar](128) NOT NULL
    Lastlogin [datetime2](7) NULL

    User
    Login_ID (PRIMARY KEY CLUSTERED) [nvarchar](64) NOT NULL
    Full_name [nvarchar](96) NOT NULL
    LoginDate [datetime] NULL

    Tételezzük fel, hogy a két tábla azonos COLLATION-t használ.

    Feladat 1: Szükségünk van minden userre egyszer a listánkban mely mindkét táblában előfordul, 
    Login-ra,  
    névre, 
    és a valódi utolsó login dátumra.

    Feladat 2: Szükségünk van minden userre mely valamelyik táblából hiányzik, 
    Login-ra, 
    névre, 
    és a valódi utolsó login dátumra.
    */

    public static void Run()
    {
        Console.WriteLine("---------SQL TASK---------\n");
        List<UserA> usersOfA = GetUserAMockData();
        List<UserB> usersOfB = GetUserBMockData();

        PrintListToConsole(usersOfA, "User A List:");
        PrintListToConsole(usersOfB, "User B List:");

        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
        Console.Clear();

        Console.WriteLine("Feladat 1: Szükségünk van minden userre egyszer a listánkban mely mindkét táblában előfordul, \nLogin-ra, névre és a valódi utolsó login dátumra.\n");
        List<object> task1res = Task1(usersOfA, usersOfB);
        PrintListToConsole(task1res, "Task 1 Result:");

        Console.WriteLine("Feladat 2: Szükségünk van minden userre mely valamelyik táblából hiányzik, \nLogin-ra, névre és a valódi utolsó login dátumra.\n");
        List<object> task2res = Task2(usersOfA, usersOfB);
        PrintListToConsole(task2res, "Task 2 Result:");

    }

    public static void PrintListToConsole<T>(List<T> users, string header)
    {
        Console.WriteLine($"{header}");

        foreach (var userObj in users)
        {
            if (userObj.GetType() == typeof(UserA))
            {
                var user = userObj as UserA;
                Console.WriteLine($"Name: {user.Name}, Login: {user.Login}, LastLogin: {user.LastLogin}");
            }

            if (userObj.GetType() == typeof(UserB))
            {
                var user = userObj as UserB;
                Console.WriteLine($"Name: {user.FullName}, Login: {user.LoginID}, LastLogin: {user.LoginDate}");
            }
        }

        Console.WriteLine();
    }

    private static List<object> Task1(List<UserA> usersOfA, List<UserB> usersOfB)
     {
        List<object> result = new List<object>();

        foreach (var item in usersOfA)
        {
            if (usersOfB.Where(t => t.Equals(item)).Any() == false)
                continue;

            result.Add(item);
        }

        return result;
    }

    private static List<object> Task2(List<UserA> usersOfA, List<UserB> usersOfB)
    {
        List<object> task2result = new List<object>();

        task2result.AddRange(usersOfA.Where(userA => usersOfB.Where(userB => userB.Equals(userA)).Any() == false).ToList<object>());
        task2result.AddRange(usersOfB.Where(userB => usersOfA.Where(userA => userA.Equals(userB)).Any() == false).ToList<object>());

        return task2result;
    }

    private static List<UserA> GetUserAMockData()
    {
        DateTime now = DateTime.Now;
        List<UserA> usersOfA = new List<UserA>
            {
                new UserA() { Name = "John Doe COMMON", Login = "JDA", LastLogin = now.AddMonths(new Random().Next(-500, 0)) }, // Same Name with usersOfB[0]
                new UserA() { Name = "John Doe A", Login = "JDCOMMON", LastLogin = now.AddMonths(new Random().Next(-500, 0)) }, // Same Login with usersOfB[1]
                new UserA() { Name = "John Doe 2A", Login = "JD 2A", LastLogin = now.AddMonths(-1) }, // Same LastLogin with usersOfB[2]
                new UserA() { Name = "John Doe", Login = "JD", LastLogin = now }, // Same Name, Login, LastLogin with usersOfB[3]
                new UserA() { Name = "John Doe2", Login = "JD2", LastLogin = now.AddDays(1) }, // Same Name, Login, LastLogin with usersOfB[4]
                new UserA() { Name = "John Doe3", Login = "JD3", LastLogin = now.AddDays(1) }, // Same Name, Login, LastLogin with usersOfB[5]
                new UserA() { Name = "John Doe4", Login = "JD4", LastLogin = now.AddDays(1) }, // Same Name, Login, LastLogin with usersOfB[6]
                new UserA() { Name = "John Doe 3A", Login = "JD 3A", LastLogin = now.AddMonths(new Random().Next(-500, 0)).AddSeconds(new Random().Next(-1000000000, 0)) } // Different Full_name, Login_ID, LoginDate with usersOfB
            };

        return usersOfA;
    }
    private static List<UserB> GetUserBMockData()
    {
        DateTime now = DateTime.Now;
        List<UserB> usersOfB = new List<UserB>
            {
                new UserB() { FullName = "John Doe COMMON", LoginID = "JDB", LoginDate = now.AddMonths(new Random().Next(-500, 0)) }, // Same FullName with usersOfA[0]
                new UserB() { FullName = "John Doe B", LoginID = "JDCOMMON", LoginDate = now.AddMonths(new Random().Next(-500, 0)) }, // Same LoginID with usersOfA[1]
                new UserB() { FullName = "John Doe 2B", LoginID = "JD 2B", LoginDate = now.AddMonths(-1) }, // Same LoginDate with usersOfA[2]
                new UserB() { FullName = "John Doe", LoginID = "JD", LoginDate = now }, // Same FullName, LoginID, LoginDate with usersOfA[3]
                new UserB() { FullName = "John Doe2", LoginID = "JD2", LoginDate = now.AddDays(1) }, // Same FullName, LoginID, LoginDate with usersOfA[4]
                new UserB() { FullName = "John Doe3", LoginID = "JD3", LoginDate = now.AddDays(1) }, // Same FullName, LoginID, LoginDate with usersOfA[5]
                new UserB() { FullName = "John Doe4", LoginID = "JD4", LoginDate = now.AddDays(1) }, // Same FullName, LoginID, LoginDate with usersOfA[6]
                new UserB() { FullName = "John Doe 3B", LoginID = "JD 3B", LoginDate = now.AddMonths(new Random().Next(-500, 0)).AddSeconds(new Random().Next(-1000000000, 0)) } // Different Full_name, Login_ID, LoginDate with usersOfA
            };

        return usersOfB;
    }
}



