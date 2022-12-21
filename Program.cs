using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
namespace Бургерная
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream FS;
            User CurrentUser = new User();
            string UserPath = "Users.xml";
        
            FS = new FileStream(UserPath, FileMode.OpenOrCreate);
            FS.Close();
        
            User[] Users = LoadUser(UserPath,ref FS);
            FS.Close();
         
            Start(ref Users, ref FS, UserPath, ref CurrentUser);
        }
        public static void Register(ref User[] Users, ref FileStream FS, string FileName)
        {
            string login;
            string pass= null;
            string[] Name = new string[3];
            string PhoneNumber;
            string EMail;

            bool test = true;
            do
            {
                Console.Clear();
                int SpecialCount = 0;
                Console.WriteLine("Введите логин:\n");
                login = Console.ReadLine();
                if (login != null)
                {
                    break;
                }
                int Chk = 0;
                foreach (User user in Users)
                {
                    if (login == user.UserName)
                    {
                        Chk = 1;
                    }
                }
                if (Chk == 0)
                {
                    foreach (char ch in login)
                    {
                        if ((ch >= 65 && ch <= 90 || ch >= 97 && ch <= 122)) ;
                        else if (ch >= 48 && ch <= 57) ;
                        else SpecialCount++;
                    }
                    if (login.Length >= 8 && SpecialCount == 0)
                    {
                        test = false;
                        Console.WriteLine("Логин успешно выбран!");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Неподходящий логин, попробуйте ещё раз!");
                        Console.ReadKey();
                    }
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Данный пользователь уже существует!");
                    Console.ReadKey();
                }
            }
                while (test) ;
            if (login != "")
            {
                test = true;
                do
                {
                    bool test1 = true;
                    int NumbersCount = 0;
                    int CharsCount = 0;
                    int SpecialCount = 0;
                    Console.Clear();
                    Console.WriteLine("ВВедите пороль:\n");
                    do
                    {
                        ConsoleKeyInfo k = Console.ReadKey(true);
                        switch (k.Key)
                        {
                            case ConsoleKey.Enter:
                                test1 = false;
                                break;
                            default:

                                if (k.Key == ConsoleKey.Backspace)
                                {
                                    if (Console.CursorLeft != 0)
                                    {
                                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                                        Console.Write(" ");
                                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                                        pass = pass.Remove(pass.Length - 1);
                                    }
                                }

                                else
                                {
                                    pass += k.KeyChar;
                                    Console.Write("*");
                                }

                                break;
                        }

                    }
                    while (test1);
                    if (pass != "" && pass != null)
                    {
                        foreach (char ch in pass)
                        {
                            if ((ch >= 65 && ch <= 90 || ch >= 97 && ch <= 122)) CharsCount++;
                            else if (ch >= 48 && ch <= 57) NumbersCount++;
                            else if (ch >= 33 && ch <= 47) SpecialCount++;
                        }
                        if (NumbersCount > 2 && CharsCount > 2 && SpecialCount > 1)
                        {
                            test = false;
                            Console.WriteLine();
                            Console.WriteLine("Пороль успешно выбран!");
                            //Console.WriteLine(pass);
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Неподходящий пороль, попробуйте ещё раз!");
                            Console.ReadKey();
                            pass = null;
                        }
                    }

                }
                while (test);
                test = true;
                do
                {
                    Console.Clear();
                    int SpecialCount = 0;
                    Console.WriteLine("Введите ваше имя:\n");
                    Name[0] = Console.ReadLine();
                    foreach (char ch in Name[0])
                    {
                        if ((ch >= 65 && ch <= 90 || ch >= 97 && ch <= 122)) ;
                        else if (ch >= 48 && ch <= 57) ;
                        else SpecialCount++;
                    }
                    if (SpecialCount == 0)
                    {
                        test = false;
                        Console.WriteLine("Имя успешно выбрано!");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Неподходящее имя, попробуйте ещё раз!");
                        Console.ReadKey();
                    }
                    Console.Clear();
                }
                while (test);
                test = true;
                do
                {
                    Console.Clear();
                    int SpecialCount = 0;
                    Console.WriteLine("Введите вашу фамилию:\n");
                    Name[1] = Console.ReadLine();
                    foreach (char ch in Name[1])
                    {
                        if ((ch >= 65 && ch <= 90 || ch >= 97 && ch <= 122)) ;
                        else if (ch >= 48 && ch <= 57) ;
                        else SpecialCount++;
                    }
                    if (SpecialCount == 0)
                    {
                        test = false;
                        Console.WriteLine("Фамилия успешно выбрана!");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Неподходящая фамилия, попробуйте ещё раз!");
                        Console.ReadKey();
                    }
                    Console.Clear();
                }
                while (test);
                test = true;
                do
                {
                    Console.Clear();
                    int SpecialCount = 0;
                    Console.WriteLine("Введите отчество:\n");
                    Name[2] = Console.ReadLine();
                    foreach (char ch in Name[2])
                    {
                        if ((ch >= 65 && ch <= 90 || ch >= 97 && ch <= 122)) ;
                        else if (ch >= 48 && ch <= 57) ;
                        else SpecialCount++;
                    }
                    if (SpecialCount == 0)
                    {
                        test = false;
                        Console.WriteLine("Отчество успешно выбрано!");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Неподходящее отчество, попробуйте ещё раз!");
                        Console.ReadKey();
                    }
                    Console.Clear();
                }
                while (test);
                test = true;
                do
                {
                    Console.Clear();
                    int SpecialCount = 0;
                    Console.WriteLine("Введите номер телефона:\n");
                    PhoneNumber = Console.ReadLine();
                    foreach (char ch in PhoneNumber)
                    {
                        if (ch >= 48 && ch <= 57) ;
                        else SpecialCount++;
                    }
                    if (PhoneNumber.Length >= 11 && SpecialCount == 0)
                    {
                        test = false;
                        Console.WriteLine("Номер успешно выбран!");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Неподходящий номер, попробуйте ещё раз!");
                        Console.ReadKey();
                    }
                    Console.Clear();
                }
                while (test);
                test = true;
                do
                {
                    Console.Clear();
                    int SpecialCount = 0;
                    Console.WriteLine("Введите почту:\n");
                    EMail = Console.ReadLine();
                    foreach (char ch in EMail)
                    {
                        if ((ch >= 65 && ch <= 90 || ch >= 97 && ch <= 122 || ch >= 48 && ch <= 57 || ch == 46 || ch == 64)) ;
                        else SpecialCount++;
                    }
                    if (EMail.Length >= 8 && SpecialCount == 0)
                    {
                        test = false;
                        Console.WriteLine("Почта успешно выбран!");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Неподходящая почта, попробуйте ещё раз!");
                        Console.ReadKey();
                    }
                    Console.Clear();
                }
                while (test);
                Array.Resize(ref Users, Users.Length + 1);
                Users[Users.Length - 1] = new User();
                Users[Users.Length - 1].FirstName = Name[0];
                Users[Users.Length - 1].SecondName = Name[1];
                Users[Users.Length - 1].MiddleName = Name[2];
                Users[Users.Length - 1].PhoneNumber = PhoneNumber;
                Users[Users.Length - 1].EMail = EMail;
                Users[Users.Length - 1].UserName = login;
                Users[Users.Length - 1].UserPassword = pass;
                Users[Users.Length - 1].id = Users.Length - 1;
                SaveUser(FileName, Users, ref FS);
            }
        }
        public static void LogIn(ref User[] Users, ref User CurrentUser)
        {
            bool b = true;
            do
            {
                int TempID = 0;
                Console.Clear();
                Console.WriteLine("Введите логин:");
                int Chk = 0;
                string Login = Console.ReadLine();
                foreach (User user in Users)
                {
                   if (Login == user.UserName)
                   {
                        Chk = 1;
                        TempID = user.id;
                   }      
                }
                if (Chk == 0)
                {
                    Console.WriteLine("Пользователь не найден!");
                    Console.ReadKey();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Введите пороль:");
                    Chk = 0;
                    bool test1 = true;
                    string pass = null;
                    do
                    {
                        ConsoleKeyInfo k = Console.ReadKey(true);
                        switch (k.Key)
                        {
                            case ConsoleKey.Enter:
                                test1 = false;
                                break;
                            default:

                                if (k.Key == ConsoleKey.Backspace)
                                { if (Console.CursorLeft !=0)
                                    {
                                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                                        Console.Write(" ");
                                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                                        pass = pass.Remove(pass.Length - 1);
                                    }
                                }
                                else
                                {
                                    pass += k.KeyChar;
                                    Console.Write("*");
                                }

                                break;
                        }

                    }
                    while (test1);
                    foreach (User user in Users)
                    {
                        Chk = pass == user.UserPassword ? 1 : Chk;
                    }
                    if (Chk == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Неверный пороль!");
                        Console.ReadKey();
                    }
                    else
                    {
                        CurrentUser = Users[TempID];
                        //Console.WriteLine(CurrentUser.FirstName);
                        Console.ReadKey();
                        b = false;
                    }
                }
            } while (b);
        }
        public static void SaveUser (string FileName, User[] users, ref FileStream FS)
        {
            if (File.Exists(FileName)) File.Delete(FileName);
            XmlSerializer XmlSrl = new XmlSerializer(typeof(User[]));
            FS = new FileStream(FileName, FileMode.OpenOrCreate);
            XmlSrl.Serialize(FS, users);
            FS.Close();
        }
        public static void SaveProduct(string FileName, Product[] prod, ref FileStream FS)
        {
            if (File.Exists(FileName)) File.Delete(FileName);
            XmlSerializer XmlSrl = new XmlSerializer(typeof(Product[]));
            FS = new FileStream(FileName, FileMode.OpenOrCreate);
            XmlSrl.Serialize(FS, prod);
            FS.Close();
        }
        public static void SaveCompany(string FileName, ref FileStream FS)
        {
            if (File.Exists(FileName)) File.Delete(FileName);
        
            FS = new FileStream(FileName, FileMode.OpenOrCreate);
          
            FS.Close();
        }
        public static User[] LoadUser(string FileName, ref FileStream FS)
        {
            FS = new FileStream(FileName, FileMode.OpenOrCreate);
            XmlSerializer XmlSrl = new XmlSerializer(typeof(User[]));
            return (User[])XmlSrl.Deserialize(FS);
        }
      
       
        public static void Start(ref User[] Users, ref FileStream FS, string UserPath, ref User CurrentUser)
        {
            int IndexY = 1;
            ConsoleKeyInfo KeyInf;
            bool Wh = true;
            CurrentUser = new User();
            while (Wh)
            {
                Console.Clear();
                if (IndexY == 1)
               
                {
                  
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Вход");
                    Console.ResetColor();
                }
                KeyInf = Console.ReadKey(true);
                switch (KeyInf.Key)
                {
                 

                    case ConsoleKey.DownArrow:
                        if (IndexY == 2) IndexY--;
                        else IndexY++;
                        break;
                    case ConsoleKey.Enter:
                        if (IndexY == 1)
                        {
                            Console.Clear();
                            LogIn(ref Users, ref CurrentUser);
                            Wh = false;
                        }
                       
                        break;
                }
            }
            switch (CurrentUser.Rank)
            {
                case "User": UserMenu(ref Users, ref FS, ref CurrentUser); break;
                case "Admin": AdminMenu(ref Users, ref FS, ref CurrentUser); break;
                case "Storage": StorageGuyMenu(ref Users, ref FS, ref CurrentUser); break;
                case "Accountant": AccountantMenu(ref Users, ref FS, ref CurrentUser); break;
                case "Manager": ManagerMenu(ref Users, ref FS, ref CurrentUser); break;
            }
        }
        public static void UserMenu(ref User[] Users, ref FileStream FS, ref User CurrentUser)
        {
            bool DW = true;
            int index = 1;
            string UserPa = "Users.xml";
            string ProdPath = "Product.xml";
            ConsoleKeyInfo KeyInf;
            do
            {
            
                Console.Clear();
                Console.WriteLine($"Добро пожаловать {CurrentUser.UserName} в Бургерную!");
                Console.WriteLine("Выберите действие:");
               
                switch (index)
                {
                  
                    case 1:
                        Console.SetCursorPosition(0, 5);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Выйти");
                        Console.ResetColor();
                        break;
                }
                KeyInf = Console.ReadKey(true);
                switch (KeyInf.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (index > 1) index--;
                        else index = 4;
                        break;

                    case ConsoleKey.DownArrow:
                        if (index < 4) index++;
                        else index = 1;
                        break;
                    case ConsoleKey.Enter:
                        switch (index)
                        {
                            case 1: Start(ref Users, ref FS, UserPa, ref CurrentUser); break;
                        }
                
                        break;
                }
            } while (DW);
        }
        public static void AdminMenu (ref User[] Users, ref FileStream FS, ref User CurrentUser)
        {
            bool bra = true;
            int index = 0;
            ConsoleKeyInfo KeyInf;
            User LastDeleted = new User();
            while (bra)
            {
                SaveUser("Users.xml", Users, ref FS);
               
              
                Console.Clear();
                Console.WriteLine($"Добро пожаловать {CurrentUser.UserName} !\n\nВыберите функцию:");
                Console.WriteLine("Создать пользователя\nУдалить пользователя\nИзменить пользователя\nВосстановить последнего удалённого\nВыйти");
                switch (index)
                {
                    case 0:
                        Console.SetCursorPosition(0, 3);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Создать пользователя");
                        Console.ResetColor();
                        break;
                    case 1:
                        Console.SetCursorPosition(0, 4);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Удалить пользователя");
                        Console.ResetColor();
                        break;
                    case 2:
                        Console.SetCursorPosition(0, 5);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Изменить пользователя");
                        Console.ResetColor();
                        break;
                    case 3:
                        Console.SetCursorPosition(0, 6);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Восстановить последнего удалённого");
                        Console.ResetColor();
                        break;
                    case 4:
                        Console.SetCursorPosition(0, 7);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Выйти");
                        Console.ResetColor();
                        break;
                }
                KeyInf = Console.ReadKey(true);
                switch (KeyInf.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (index > 0) index--;
                        else index = 4;
                        break;

                    case ConsoleKey.DownArrow:
                        if (index < 4) index++;
                        else index = 0;
                        break;
                    case ConsoleKey.Enter:
                        switch(index)
                        {
                            case 0: Register(ref Users,ref FS, "Users.xml"); break;
                            case 1:
                                bool Bl = true;
                                int Indexx = 0;
                                while (Bl)
                                {
                                    
                                    Console.Clear();
                                    Console.WriteLine("Выберите пользователя, которого хотите удалить:");
                                    for(int i =0;i<Users.Length;i++)
                                    {
                                        if (Indexx == i)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.BackgroundColor = ConsoleColor.Yellow;
                                        }
                                        Console.WriteLine(Users[i].FirstName + " " + Users[i].SecondName);
                                        Console.ResetColor();
                                    }
                                    if (Indexx == Users.Length)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.BackgroundColor = ConsoleColor.Yellow;
                                    }
                                    Console.WriteLine("Выход");
                                    Console.ResetColor();
                                    Console.SetCursorPosition(0, 1 + Indexx);
                                    KeyInf = Console.ReadKey(true);
                                    switch (KeyInf.Key)
                                    {
                                        case ConsoleKey.UpArrow:
                                            if (Indexx > 0) Indexx--;
                                            else Indexx = Users.Length;
                                            break;

                                        case ConsoleKey.DownArrow:
                                            if (Indexx < Users.Length) Indexx++;
                                            else Indexx = 0;
                                            break;
                                        case ConsoleKey.Enter:
                                            if (Indexx == Users.Length) Bl = false;
                                            else
                                            {
                                                bool been = true;
                                                int indx = 0;
                                                while (been)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine($"\nВы уверены, что хотите удалить пользователя {Users[Indexx].FirstName} {Users[Indexx].SecondName}?");

                                                    switch (indx)
                                                    {
                                                        case 0:
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.BackgroundColor = ConsoleColor.Yellow;
                                                            Console.WriteLine("Да");
                                                            Console.ResetColor();
                                                            Console.WriteLine("Нет");
                                                            break;
                                                        case 1:
                                                            Console.WriteLine("Да");
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.BackgroundColor = ConsoleColor.Yellow;
                                                            Console.WriteLine("Нет");
                                                            Console.ResetColor();
                                                            break;
                                                    }
                                                    KeyInf = Console.ReadKey(true);
                                                    switch (KeyInf.Key)
                                                    {
                                                        case ConsoleKey.UpArrow:
                                                            if (indx == 1) indx--;
                                                            else indx = 1;
                                                            break;

                                                        case ConsoleKey.DownArrow:
                                                            if (indx == 0) indx++;
                                                            else indx = 0;
                                                            break;
                                                        case ConsoleKey.Enter:
                                                            if (indx == 0 && Users[Indexx].Rank != "Admin" && Users[Indexx].Rank != "User")
                                                            {
                                                                LastDeleted = Users[Indexx];
                                                                for (int i = Indexx; i < Users.Length - 1; i++)
                                                                {
                                                                    Users[i] = Users[i + 1];
                                                                    Users[i].id = i;
                                                                }
                                                                Array.Resize(ref Users, Users.Length-1);
                                                                Console.WriteLine("Пользователь удалён! Вы молодец!");
                                                                been = false; Bl = false;
                                                                Console.ReadKey(true);
                                                            }
                                                            else if (Users[Indexx].Rank == "Admin")
                                                            {
                                                                Console.WriteLine("Админа нельзя удалить!");
                                                                been = false; Bl = false;
                                                                Console.ReadKey();
                                                            }
                                                            else if (Users[Indexx].Rank == "User")
                                                            {
                                                                Console.WriteLine("Пользователя нельзя удалить!");
                                                                been = false; Bl = false;
                                                                Console.ReadKey();
                                                            }
                                                            break;
                                                    }
                                                }
                                            }
                                            break;
                                    }
                                }
                                break;
                            case 2:
                                 Bl = true;
                                 Indexx = 0;
                                while (Bl)
                                {
                                    Console.Clear();
                                    for (int i = 0; i < Users.Length; i++)
                                    {
                                        if (Indexx == i)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.BackgroundColor = ConsoleColor.Yellow;
                                        }
                                        Console.WriteLine(Users[i].FirstName + " " + Users[i].SecondName);
                                        Console.ResetColor();
                                    }
                                    if (Indexx == Users.Length)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.BackgroundColor = ConsoleColor.Yellow;
                                    }
                                    Console.WriteLine("Выход");
                                    Console.ResetColor();
                                    Console.SetCursorPosition(0, 1 + Indexx);
                                    KeyInf = Console.ReadKey(true);
                                    switch (KeyInf.Key)
                                    {
                                        case ConsoleKey.UpArrow:
                                            if (Indexx > 0) Indexx--;
                                            else Indexx = Users.Length;
                                            break;

                                        case ConsoleKey.DownArrow:
                                            if (Indexx < Users.Length) Indexx++;
                                            else Indexx = 0;
                                            break;
                                        case ConsoleKey.Enter:
                                            if (Indexx == Users.Length) Bl = false;
                                            else
                                            {
                                                string[] Text = {"Ранг","ФИО","Номер телефона","Почта","Возраст","Логин","Пороль","Зарплата","Выйти"};
                                                int indx = 0;
                                                bool BoolBera = true;
                                                while (BoolBera)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Что изменяем?");
                                                    for (int i = 0; i < Text.Length; i++)
                                                    {
                                                        if (indx == i)
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.BackgroundColor = ConsoleColor.Yellow;
                                                        }
                                                        Console.Write(Text[i]);
                                                        Users[Indexx].Info(Text[i]);
                                                        Console.ResetColor();
                                                    }
                                                    KeyInf = Console.ReadKey(true);
                                                    switch (KeyInf.Key)
                                                    {
                                                        case ConsoleKey.UpArrow:
                                                            if (indx > 0) indx--;
                                                            else indx = Text.Length-1;
                                                            break;

                                                        case ConsoleKey.DownArrow:
                                                            if (indx < Text.Length-1) indx++;
                                                            else indx = 0;
                                                            break;
                                                        case ConsoleKey.Enter:
                                                            switch (indx)
                                                            {
                                                                case 0:
                                                                    int indxs = 0;
                                                                    bool bebra = true;
                                                                    string[] Rangs = {"User","Admin","Storage","Accountant","Manager","Выйти"};
                                                                    while (bebra)
                                                                    {
                                                                        Console.Clear();
                                                                        for (int i = 0; i < Rangs.Length; i++)
                                                                        {
                                                                            if (indxs == i)
                                                                            {
                                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                                Console.BackgroundColor = ConsoleColor.Yellow;
                                                                            }
                                                                            Console.WriteLine(Rangs[i]);
                                                                            Console.ResetColor();
                                                                        }
                                                                        KeyInf = Console.ReadKey(true);
                                                                        switch (KeyInf.Key)
                                                                        {
                                                                            case ConsoleKey.UpArrow:
                                                                                if (indxs > 0) indxs--;
                                                                                else indxs = Rangs.Length-1;
                                                                                break;

                                                                            case ConsoleKey.DownArrow:
                                                                                if (indxs < Rangs.Length-1) indxs++;
                                                                                else indxs = 0;
                                                                                break;
                                                                            case ConsoleKey.Enter:
                                                                                if (indxs == Rangs.Length - 1) bebra = false;
                                                                                else
                                                                                {
                                                                                    Console.Clear();
                                                                                    Users[Indexx].Rank = Rangs[indxs];
                                                                                    Console.WriteLine($"Вы назначили новый ранг ({Rangs[indxs]}) для {Users[Indexx].FirstName} {Users[Indexx].SecondName} ");
                                                                                    Console.ReadKey();
                                                                                }
                                                                                break;
                                                                        }
                                                                    }
                                                                    break;
                                                                case 1:
                                                                    Console.Clear();
                                                                    bool test = true;
                                                                    string[] Name = new string[3];
                                                                    do
                                                                    {
                                                                        Console.Clear();
                                                                        int SpecialCount = 0;
                                                                        Console.WriteLine("Введите ваше имя:\n");
                                                                        Name[0] = Console.ReadLine();
                                                                        foreach (char ch in Name[0])
                                                                        {
                                                                            if ((ch >= 65 && ch <= 90 || ch >= 97 && ch <= 122)) ;
                                                                            else if (ch >= 48 && ch <= 57) ;
                                                                            else SpecialCount++;
                                                                        }
                                                                        if (SpecialCount == 0)
                                                                        {
                                                                            test = false;
                                                                            Console.WriteLine("Имя успешно выбрано!");
                                                                            Console.ReadKey();
                                                                        }
                                                                        else
                                                                        {
                                                                            Console.WriteLine("Неподходящее имя, попробуйте ещё раз!");
                                                                            Console.ReadKey();
                                                                        }
                                                                        Console.Clear();
                                                                    }
                                                                    while (test);
                                                                    test = true;
                                                                    do
                                                                    {
                                                                        Console.Clear();
                                                                        int SpecialCount = 0;
                                                                        Console.WriteLine("Введите вашу фамилию:\n");
                                                                        Name[1] = Console.ReadLine();
                                                                        foreach (char ch in Name[1])
                                                                        {
                                                                            if ((ch >= 65 && ch <= 90 || ch >= 97 && ch <= 122)) ;
                                                                            else if (ch >= 48 && ch <= 57) ;
                                                                            else SpecialCount++;
                                                                        }
                                                                        if (SpecialCount == 0)
                                                                        {
                                                                            test = false;
                                                                            Console.WriteLine("Фамилия успешно выбрана!");
                                                                            Console.ReadKey();
                                                                        }
                                                                        else
                                                                        {
                                                                            Console.WriteLine("Неподходящая фамилия, попробуйте ещё раз!");
                                                                            Console.ReadKey();
                                                                        }
                                                                        Console.Clear();
                                                                    }
                                                                    while (test);
                                                                    test = true;
                                                                    do
                                                                    {
                                                                        Console.Clear();
                                                                        int SpecialCount = 0;
                                                                        Console.WriteLine("Введите отчество:\n");
                                                                        Name[2] = Console.ReadLine();
                                                                        foreach (char ch in Name[2])
                                                                        {
                                                                            if ((ch >= 65 && ch <= 90 || ch >= 97 && ch <= 122)) ;
                                                                            else if (ch >= 48 && ch <= 57) ;
                                                                            else SpecialCount++;
                                                                        }
                                                                        if (SpecialCount == 0)
                                                                        {
                                                                            test = false;
                                                                            Console.WriteLine("Отчество успешно выбрано!");
                                                                            Console.ReadKey();
                                                                        }
                                                                        else
                                                                        {
                                                                            Console.WriteLine("Неподходящее отчество, попробуйте ещё раз!");
                                                                            Console.ReadKey();
                                                                        }
                                                                        Console.Clear();
                                                                    } while (test);
                                                                    Users[Indexx].FirstName = Name[0];
                                                                    Users[Indexx].SecondName = Name[1];
                                                                    Users[Indexx].MiddleName = Name[2];
                                                                    break;
                                                                case 2:
                                                                    Console.Clear();
                                                                    string PhoneNumber;
                                                                    test = true;
                                                                    do
                                                                    {
                                                                        Console.Clear();
                                                                        int SpecialCount = 0;
                                                                        Console.WriteLine("Введите номер телефона:\n");
                                                                        PhoneNumber = Console.ReadLine();
                                                                        foreach (char ch in PhoneNumber)
                                                                        {
                                                                            if (ch >= 48 && ch <= 57) ;
                                                                            else SpecialCount++;
                                                                        }
                                                                        if (PhoneNumber.Length >= 11 && SpecialCount == 0)
                                                                        {
                                                                            test = false;
                                                                            Console.WriteLine("Номер успешно выбран!");
                                                                            Console.ReadKey();
                                                                        }
                                                                        else
                                                                        {
                                                                            Console.WriteLine("Неподходящий номер, попробуйте ещё раз!");
                                                                            Console.ReadKey();
                                                                        }
                                                                        Console.Clear();
                                                                    }
                                                                    while (test);
                                                                    Users[Indexx].PhoneNumber = PhoneNumber;
                                                                    break;
                                                                case 3:
                                                                    Console.Clear();
                                                                    string EMail;
                                                                    test = true;
                                                                    do
                                                                    {
                                                                        Console.Clear();
                                                                        int SpecialCount = 0;
                                                                        Console.WriteLine("Введите почту:\n");
                                                                        EMail = Console.ReadLine();
                                                                        foreach (char ch in EMail)
                                                                        {
                                                                            if ((ch >= 65 && ch <= 90 || ch >= 97 && ch <= 122 || ch >= 48 && ch <= 57 || ch == 46 || ch == 64)) ;
                                                                            else SpecialCount++;
                                                                        }
                                                                        if (EMail.Length >= 8 && SpecialCount == 0)
                                                                        {
                                                                            test = false;
                                                                            Console.WriteLine("Почта успешно выбран!");
                                                                            Console.ReadKey();
                                                                        }
                                                                        else
                                                                        {
                                                                            Console.WriteLine("Неподходящая почта, попробуйте ещё раз!");
                                                                            Console.ReadKey();
                                                                        }
                                                                        Console.Clear();
                                                                    }
                                                                    while (test);
                                                                    Users[Indexx].EMail = EMail;
                                                                    break;
                                                                case 4:
                                                                    Console.Clear();
                                                                    string[] Age = new string[3];
                                                                    int[] AgeInt = new int[3];
                                                                    while (!(int.TryParse(Age[0],out AgeInt[0]) && int.TryParse(Age[1], out AgeInt[1]) && int.TryParse(Age[2], out AgeInt[2])))
                                                                    {
                                                                        Console.WriteLine("Введите год рождения:");
                                                                        Age[0] = Console.ReadLine();
                                                                        Console.WriteLine("Введите месяц рождения");
                                                                        Age[1] = Console.ReadLine();
                                                                        Console.WriteLine("Введите день рождения");
                                                                        Age[2] = Console.ReadLine();
                                                                    }
                                                                    for (int i =0;i<3;i++) Users[Indexx].age[i] = AgeInt[2 - i];
                                                                    break;
                                                                case 5:
                                                                    string login;
                                                                    test = true;
                                                                    do
                                                                    {
                                                                        Console.Clear();
                                                                        int SpecialCount = 0;
                                                                        Console.WriteLine("Введите логин:\n");
                                                                        login = Console.ReadLine();
                                                                        if (login != null)
                                                                        {
                                                                            break;
                                                                        }
                                                                        int Chk = 0;
                                                                        foreach (User user in Users)
                                                                        {
                                                                            if (login == user.UserName)
                                                                            {
                                                                                Chk = 1;
                                                                            }
                                                                        }
                                                                        if (Chk == 0)
                                                                        {
                                                                            foreach (char ch in login)
                                                                            {
                                                                                if ((ch >= 65 && ch <= 90 || ch >= 97 && ch <= 122)) ;
                                                                                else if (ch >= 48 && ch <= 57) ;
                                                                                else SpecialCount++;
                                                                            }
                                                                            if (login.Length >= 8 && SpecialCount == 0)
                                                                            {
                                                                                test = false;
                                                                                Console.WriteLine("Логин успешно выбран!");
                                                                                Console.ReadKey();
                                                                            }
                                                                            else
                                                                            {
                                                                                Console.WriteLine("Неподходящий логин, попробуйте ещё раз!");
                                                                                Console.ReadKey();
                                                                            }
                                                                            Console.Clear();
                                                                        }
                                                                        else
                                                                        {
                                                                            Console.WriteLine("Данный пользователь уже существует!");
                                                                            Console.ReadKey();
                                                                        }
                                                                    }
                                                                    while (test);
                                                                    Users[Indexx].UserName = login;
                                                                    break;
                                                                case 6:
                                                                    string pass = "";
                                                                    test = true;
                                                                    do
                                                                    {
                                                                        bool test1 = true;
                                                                        int NumbersCount = 0;
                                                                        int CharsCount = 0;
                                                                        int SpecialCount = 0;
                                                                        Console.Clear();
                                                                        Console.WriteLine("ВВедите пороль:\n");
                                                                        do
                                                                        {
                                                                            ConsoleKeyInfo k = Console.ReadKey(true);
                                                                            switch (k.Key)
                                                                            {
                                                                                case ConsoleKey.Enter:
                                                                                    test1 = false;
                                                                                    break;
                                                                                default:

                                                                                    if (k.Key == ConsoleKey.Backspace)
                                                                                    {
                                                                                        if (Console.CursorLeft != 0)
                                                                                        {
                                                                                            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                                                                                            Console.Write(" ");
                                                                                            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                                                                                            pass = pass.Remove(pass.Length - 1);
                                                                                        }
                                                                                    }

                                                                                    else
                                                                                    {
                                                                                        pass += k.KeyChar;
                                                                                        Console.Write("*");
                                                                                    }

                                                                                    break;
                                                                            }

                                                                        }
                                                                        while (test1);
                                                                        if (pass != "" && pass != null)
                                                                        {
                                                                            foreach (char ch in pass)
                                                                            {
                                                                                if ((ch >= 65 && ch <= 90 || ch >= 97 && ch <= 122)) CharsCount++;
                                                                                else if (ch >= 48 && ch <= 57) NumbersCount++;
                                                                                else if (ch >= 33 && ch <= 47) SpecialCount++;
                                                                            }
                                                                            if (NumbersCount > 2 && CharsCount > 2 && SpecialCount > 1)
                                                                            {
                                                                                test = false;
                                                                                Console.WriteLine();
                                                                                Console.WriteLine("Пороль успешно выбран!");
                                                                                //Console.WriteLine(pass);
                                                                                Console.ReadKey();
                                                                            }
                                                                            else
                                                                            {
                                                                                Console.WriteLine();
                                                                                Console.WriteLine("Неподходящий пороль, попробуйте ещё раз!");
                                                                                Console.ReadKey();
                                                                                pass = null;
                                                                            }
                                                                        }

                                                                    }
                                                                    while (test);
                                                                    Users[Indexx].UserPassword = pass;
                                                                    break;
                                                                case 7:
                                                                    test = true;
                                                                    do
                                                                    {
                                                                        Console.Clear();
                                                                        Console.WriteLine("Введите новую зарплату:");
                                                                        string NewSalary = Console.ReadLine();
                                                                        int NewSalaryInt;
                                                                        if (int.TryParse(NewSalary,out NewSalaryInt) && NewSalaryInt>=0)
                                                                        {
                                                                            Users[Indexx].Salary = NewSalaryInt;
                                                                            test = false;
                                                                            Console.WriteLine("Зарплата узпешно измененна!");
                                                                            Console.ReadKey(true);
                                                                        }
                                                                        else Console.WriteLine("Ошибка!"); 

                                                                    } while (test);
                                                                    break;
                                                                case 8: BoolBera = false; break;
                                                            }
                                                            break;
                                                    }
                                                    }
                                            }
                                            break;
                                    }
                                }
                                break;
                            case 3:
                                bool Bt = true;
                                int ind = 0;
                                string[] text = {"Да","Нет"};
                                while (Bt)
                                {
                                    Console.Clear();
                                    LastDeleted.Info();
                                    
                                    for (int i = 0; i < text.Length; i++)
                                    {
                                        if (ind == i)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.BackgroundColor = ConsoleColor.Yellow;
                                        }
                                        Console.WriteLine(text[i]);
                                        Console.ResetColor();
                                    }
                                    KeyInf = Console.ReadKey(true);
                                    switch (KeyInf.Key)
                                    {
                                        case ConsoleKey.UpArrow:
                                            if (ind > 0) ind--;
                                            else ind = text.Length - 1;
                                            break;

                                        case ConsoleKey.DownArrow:
                                            if (ind < text.Length - 1) ind++;
                                            else ind = 0;
                                            break;
                                        case ConsoleKey.Enter:
                                            if (ind == 1) Bt = false;
                                            else
                                            {
                                                if (LastDeleted.FirstName != "" && LastDeleted.FirstName != null)
                                                {
                                                    Console.Clear();
                                                    Array.Resize(ref Users, Users.Length + 1);
                                                    Users[Users.Length - 1] = new User();
                                                    for (int i = Users.Length - 1; i > LastDeleted.id; i--) Users[i] = Users[i - 1];
                                                    Users[LastDeleted.id] = LastDeleted;
                                                    LastDeleted = new User();
                                                    Console.WriteLine("Пользватель успешно востановлен!");
                                                    Console.ReadKey(true);
                                                }
                                            }
                                            break;
                                    }
                                }
                                break;
                            case 4: Start(ref Users, ref FS, "Users.xml", ref CurrentUser); break;
                        }
                        break;
                }
            }
        }
       
        public static void StorageGuyMenu(ref User[] Users, ref FileStream FS, ref User CurrentUser)
        { 
            bool DW = true;
            int index = 1;
            string UserPa = "Users.xml";
            string ProdPath = "Product.xml";
            ConsoleKeyInfo KeyInf;
            do
            {
              
                Console.Clear();
                Console.WriteLine($"Добро пожаловать {CurrentUser.UserName} Должность: {CurrentUser.Rank}!");
                Console.WriteLine("Выберите действие:");

                switch (index)
                {

                    case 1:
                        Console.SetCursorPosition(0, 5);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Выйти");
                        Console.ResetColor();
                        break;
                }
                KeyInf = Console.ReadKey(true);
                switch (KeyInf.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (index > 1) index--;
                        else index = 4;
                        break;

                    case ConsoleKey.DownArrow:
                        if (index < 4) index++;
                        else index = 1;
                        break;
                    case ConsoleKey.Enter:
                        switch (index)
                        {
                            case 1: Start(ref Users, ref FS, UserPa, ref CurrentUser); break;
                        }

                        break;
                }
            } while (DW);

        }
        public static void AccountantMenu(ref User[] Users, ref FileStream FS, ref User CurrentUser)
        {
            bool DW = true;
            int index = 1;
            string UserPa = "Users.xml";
            string ProdPath = "Product.xml";
            ConsoleKeyInfo KeyInf;
            do
            {
          
                Console.Clear();
                Console.WriteLine($"Добро пожаловать {CurrentUser.UserName} Должность: {CurrentUser.Rank}!");
                Console.WriteLine("Выберите действие:");

                switch (index)
                {

                    case 1:
                        Console.SetCursorPosition(0, 5);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Выйти");
                        Console.ResetColor();
                        break;
                }
                KeyInf = Console.ReadKey(true);
                switch (KeyInf.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (index > 1) index--;
                        else index = 4;
                        break;

                    case ConsoleKey.DownArrow:
                        if (index < 4) index++;
                        else index = 1;
                        break;
                    case ConsoleKey.Enter:
                        switch (index)
                        {
                            case 1: Start(ref Users, ref FS, UserPa, ref CurrentUser); break;
                        }

                        break;
                }
            } while (DW);
        }
        public static void ManagerMenu(ref User[] Users, ref FileStream FS, ref User CurrentUser)
        {
            bool DW = true;
            int index = 1;
            string UserPa = "Users.xml";
            string ProdPath = "Product.xml";
            ConsoleKeyInfo KeyInf;
            do
            {
               
                Console.Clear();
                Console.WriteLine($"Добро пожаловать {CurrentUser.UserName} Должность: {CurrentUser.Rank}!");
                Console.WriteLine("Выберите действие:");

                switch (index)
                {

                    case 1:
                        Console.SetCursorPosition(0, 5);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Выйти");
                        Console.ResetColor();
                        break;
                }
                KeyInf = Console.ReadKey(true);
                switch (KeyInf.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (index > 1) index--;
                        else index = 4;
                        break;

                    case ConsoleKey.DownArrow:
                        if (index < 4) index++;
                        else index = 1;
                        break;
                    case ConsoleKey.Enter:
                        switch (index)
                        {
                            case 1: Start(ref Users, ref FS, UserPa, ref CurrentUser); break;
                        }

                        break;
                }
            } while (DW);

        }
    }
    [Serializable]
    public class User
    {
        public string Rank = "User";
        public int id;

        public string FirstName;
        public string SecondName;
        public string MiddleName;

        public string PhoneNumber;
        public string EMail;

        public int[] age = new int[3];

        public string UserName;
        public string UserPassword;


        public Product[] CurrentProducts = new Product[1];

        public int Salary;
        public int[] SalaryForTime = new int[2];
        public void Info(string pos)
        {
            switch (pos)
            {
                case "Ранг": Console.WriteLine(": " + Rank); break;
                case "ФИО": Console.WriteLine(": " + $"{FirstName} {SecondName} {MiddleName}"); break;
                case "Номер телефона": Console.WriteLine(":" + PhoneNumber); break;
                case "Почта": Console.WriteLine(": " + EMail); break;
                case "Возраст": Console.WriteLine(": " + $"{age[0]}.{age[1]}.{age[2]}"); break;
                case "Логин": Console.WriteLine(": " + UserName); break;
                case "Пороль": Console.WriteLine(": " + UserPassword); break;
                case "Зарплата": Console.WriteLine(": " + Salary); break;
            }
        }
        public void Info()
        {
            Console.WriteLine("Ранг: " + Rank);
            Console.WriteLine("ФИО: " + $"{FirstName} {SecondName} {MiddleName}");
            Console.WriteLine("Номер телефона: " + PhoneNumber);
            Console.WriteLine("Почта: " + EMail);

            Console.WriteLine("Логин: " + UserName);
            Console.WriteLine("Пороль: " + UserPassword);
        }
    } 
}