using Microsoft.Data.SqlClient;

namespace Proekt1
{
    public class Program
    {
        static string connectionString = "Data Source=STUDENT20;Initial Catalog=DatabaseFirst;Integrated Security=True;Trust Server Certificate=True";

        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Създадени ли са таблиците (1-да/0-не): ");
            int a = int.Parse(Console.ReadLine());

            bool isCreate = a == 1;
            if (!isCreate)
            {
                DefaultCreate();
            }

            Console.Write("Сийднати ли са таблиците (1-да/0-не): ");
            int b = int.Parse(Console.ReadLine());

            bool isSeed = b == 1;
            if (!isSeed)
            {
                DefaltSeed();
            }
               
            while (true)
            {
                Console.WriteLine("Избери действие:");
                Console.WriteLine("1 - Добави Театър");
                Console.WriteLine("2 - Добави Актьор");
                Console.WriteLine("3 - Добави Представление");
                Console.WriteLine("4 - Добави Реквизит");
                Console.WriteLine("5 - Свързване на Театъра с Актьорите:");
                Console.WriteLine("6 - Свързване на пиеси с Актьорите:");
                Console.WriteLine("7 - Намиране на актьор по име:");
                Console.WriteLine("8 - Изпечатване на всички театри:");
                Console.WriteLine("9 - Намери в кой театър кои актьори играят:");
                Console.WriteLine("10 - Намиране по град колго броя актьори са в него и техните имена:");
                Console.WriteLine("11 - Намери театър по ваведена година");
                Console.WriteLine("12 - Намери театър по ваведен град");
                Console.WriteLine("15 - Изход");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTheater();
                        break;
                    case "2":
                        AddActor();
                        break;
                    case "3":
                        AddPlays();
                        break;
                    case "4":
                        AddProprietary();
                        break;
                    case "5":
                        AddUnite();
                        break;
                    case "6":
                        AddUnite_Plays();
                        break;
                    case "7":
                        Zaqvka1();
                        break;
                    case "8":
                        Zaqvka2();
                        break;
                    case "9":
                        Zaqvka3();
                        break;
                    case "10":
                        Zaqvka4();
                        break;
                    case "11":
                        Zaqvka5();
                        break;
                    case "12":
                        Zaqvka6();
                        break;
                    case "15":
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("Невалиден избор.");
                        break;

                    Console.ReadLine();
                }
            }
        }

        static void DefaultCreate()
        {
            string create = "CREATE TABLE [Teathers]([Id_Teathers] INT PRIMARY KEY IDENTITY(1,1),[Name] NVARCHAR(200) NOT NULL,[Year_Creation] INT CHECK (Year_Creation >1400 AND Year_Creation <2025) NOT NULL,[City] NVARCHAR(200) NOT NULL);";
            string create1 = "CREATE TABLE [Actors]([Id_Actors] INT PRIMARY KEY IDENTITY(1,1),[First_name] NVARCHAR(100) NOT NULL,[Last_name] NVARCHAR(100) NOT NULL,[Birthday] DATETIME2,[Education] NVARCHAR(500) NOT NULL,[City] NVARCHAR(100) NOT NULL);";
            string create2 = "CREATE TABLE [Plays]([Id_plays] INT PRIMARY KEY IDENTITY(1,1),[Title] NVARCHAR(500) NOT NULL,[Years] INT CHECK (Years >1400 AND Years <2025) NOT NULL,);";
            string create3 = "CREATE TABLE [Proprietary]([Id_Proprietary] INT PRIMARY KEY IDENTITY(1,1),[Clothes] NVARCHAR(500) NOT NULL,[Subjects] NVARCHAR(500) NOT NULL,[Electronics] NVARCHAR(200) NOT NULL);";
            string create4 = "CREATE TABLE[Unite]([Id_Unite] INT PRIMARY KEY IDENTITY(1,1),[Id_Teathers] INT FOREIGN KEY REFERENCES [Teathers](Id_Teathers),[Id_Actors] INT FOREIGN KEY REFERENCES [Actors](Id_Actors));";
            string create5 = "CREATE TABLE[Unite_Plays]([Id_Unite] INT PRIMARY KEY IDENTITY(1,1),[Id_Plays] INT FOREIGN KEY REFERENCES [Plays](Id_plays),[Id_Actors] INT FOREIGN KEY REFERENCES [Actors](Id_Actors));";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand comand = new SqlCommand(create, conn))
                {
                    try
                    {
                       comand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Грешка: " + ex.Message);
                    }
                }
                using (SqlCommand comand = new SqlCommand(create1, conn))
                {
                    try
                    {
                       comand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Грешка: " + ex.Message);
                    }
                }
                using (SqlCommand comand = new SqlCommand(create2, conn))
                {
                    try
                    {
                        comand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Грешка: " + ex.Message);
                    }
                }
                using (SqlCommand comand = new SqlCommand(create3, conn))
                {
                    try
                    {
                        comand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Грешка: " + ex.Message);
                    }
                }
                using (SqlCommand comand = new SqlCommand(create4, conn))
                {
                    try
                    {
                       comand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Грешка: " + ex.Message);
                    }
                }
            }
        }


        static void DefaltSeed()
        {
            string insert = "INSERT INTO [Teathers] ([Name], [Year_Creation], [City]) VALUES (N'Градски Театър', 1900, N'София'), (N'Национален Театър', 1850, N'Пловдив'), (N'Кралски театър', 1888, N'Лондон'), (N'Бродвей театър', 1903, N'Ню Йорк');";

            string insert1 = "INSERT INTO [Actors] ([First_Name], [Last_Name], [Birthday], [Education], [City]) VALUES (N'Иван', N'Иванов', '1980-01-01', N'Висше изкуство', N'София'), (N'Петър', N'Петров', '1990-05-15', N'Театрално образование', N'Варна'), (N'Иван', N'Петров', '1985-06-15', N'Национална академия за театър и филм', N'София'), (N'Ема', N'Джонсън', '1992-09-22', N'Лондонска театрална академия', N'Лондон');";

            string insert2 = "INSERT INTO [Plays] ([Title], [Years]) VALUES (N'Хамлет', 1600), (N'Ромео и Жулиета', 1597), (N'Женитба', 1842), (N'Макбет', 1606);";

            string insert3 = "INSERT INTO [Proprietary] ([Clothes], [Subjects], [Electronics]) VALUES (N'Костюми', N'Реквизит', N'Светлини'), (N'Сцени', N'Реквизит', N'Звук'), (N'Костюми класически', N'Театрални реквизити', N'Звукова апаратура'), (N'Модерни костюми', N'Сценични декори', N'Осветителни тела');";

            string insert4 = "INSERT INTO [Unite] ([Id_Teathers], [Id_Actors]) VALUES (1, 1), (2, 2), (1, 3), (3, 3);";

            string insert5 = "INSERT INTO [Unite_Plays] ([Id_Plays], [Id_Actors]) VALUES (1, 1), (2, 1), (3, 2), (4, 3);";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand comand = new SqlCommand(insert, conn))
                {
                    try
                    {
                        comand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Грешка: " + ex.Message);
                    }
                }
                using (SqlCommand comand = new SqlCommand(insert1, conn))
                {
                    try
                    {
                         comand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Грешка: " + ex.Message);
                    }
                }
                using (SqlCommand comand = new SqlCommand(insert2, conn))
                {
                    try
                    {
                        comand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Грешка: " + ex.Message);
                    }
                }
                using (SqlCommand comand = new SqlCommand(insert3, conn))
                {
                    try
                    {
                        comand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Грешка: " + ex.Message);
                    }
                }
                using (SqlCommand comand = new SqlCommand(insert4, conn))
                {
                    try
                    {
                        comand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Грешка: " + ex.Message);
                    }
                }
            }
        }

        static void AddTheater()
        {

            Console.Write("Име на театъра: ");
            string name = Console.ReadLine();

            Console.Write("Година на създаване: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Град: ");
            string city = Console.ReadLine();

            string insert = "INSERT INTO Teathers (Name, Year_Creation, City) VALUES (@Name, @Year, @City)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand comand = new SqlCommand(insert, conn))
                {
                    comand.Parameters.AddWithValue("@Name", name);
                    comand.Parameters.AddWithValue("@Year", year);
                    comand.Parameters.AddWithValue("@City", city);

                    try
                    {
                        conn.Open();
                        comand.ExecuteNonQuery();
                        Console.WriteLine($"Успешно добавихте запис в таблицата Teathers.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Грешка: " + ex.Message);
                    }
                }
            }
        }

        static void AddActor()
        {
            Console.Write("Име: ");
            string firstName = Console.ReadLine();

            Console.Write("Фамилия: ");
            string lastName = Console.ReadLine();

            Console.Write("Дата на раждане: ");
            DateTime birthday = DateTime.Parse(Console.ReadLine());

            Console.Write("Образование: ");
            string education = Console.ReadLine();

            Console.Write("Град: ");
            string city = Console.ReadLine();

            string sql = "INSERT INTO Actors (First_name, Last_name, Birthday, Education, City) VALUES (@FirstName, @LastName, @Birthday, @Education, @City)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand comand = new SqlCommand(sql, connection))
                {
                    comand.Parameters.AddWithValue("@FirstName", firstName);
                    comand.Parameters.AddWithValue("@LastName", lastName);
                    comand.Parameters.AddWithValue("@Birthday", birthday);
                    comand.Parameters.AddWithValue("@Education", education);
                    comand.Parameters.AddWithValue("@City", city);

                    try
                    {
                        connection.Open();
                        comand.ExecuteNonQuery();
                        Console.WriteLine($"Успешно добавихте запис в таблицата Actors.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Грешка: " + ex.Message);
                    }
                }
            }
        }

        static void AddPlays()
        {
            Console.Write("Заглавие: ");
            string title = Console.ReadLine();

            Console.Write("Година: ");
            int year = int.Parse(Console.ReadLine());

            string sql = "INSERT INTO Plays (Title, Years) VALUES (@Title, @Years)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand comand = new SqlCommand(sql, connection))
                {
                    comand.Parameters.AddWithValue("@Title", title);
                    comand.Parameters.AddWithValue("@Years", year);

                    try
                    {
                        connection.Open();
                        comand.ExecuteNonQuery();
                        Console.WriteLine($"Успешно добавихте запис в таблицата Plays.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Грешка: " + ex.Message);
                    }
                }
            }
        }

        static void AddProprietary()
        {
            Console.Write("Дрехи: ");
            string clothes = Console.ReadLine();

            Console.Write("Предмети: ");
            string subjects = Console.ReadLine();

            Console.Write("Електроника: ");
            string electronics = Console.ReadLine();

            string sql = "INSERT INTO Proprietary (Clothes, Subjects, Electronics) VALUES (@Clothes, @Subjects, @Electronics)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand comand = new SqlCommand(sql, connection))
                {
                    comand.Parameters.AddWithValue("@Clothes", clothes);
                    comand.Parameters.AddWithValue("@Subjects", subjects);
                    comand.Parameters.AddWithValue("@Electronics", electronics);

                    try
                    {
                        connection.Open();
                        comand.ExecuteNonQuery();
                        Console.WriteLine($"Успешно добавихте запис в таблицата Proprietary.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Грешка: " + ex.Message);
                    }
                }
            }
        }

        static void AddUnite()
        {
            Console.Write("Ад театър: ");
            int id_Teathers = int.Parse(Console.ReadLine());

            Console.Write("Ад актьор: ");
            int id_Actors = int.Parse(Console.ReadLine());

            string sql = "INSERT INTO Unite (Id_Teathers, Id_Actors) VALUES (@Id_Teathers, @Id_Actors)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand comand = new SqlCommand(sql, connection))
                {
                    comand.Parameters.AddWithValue("@Id_Teathers", id_Teathers);
                    comand.Parameters.AddWithValue("@Id_Actors", id_Actors);

                    try
                    {
                        connection.Open();
                        comand.ExecuteNonQuery();
                        Console.WriteLine($"Успешно добавихте запис в таблицата Unite.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Грешка: " + ex.Message);
                    }
                }
            }
        }

        static void AddUnite_Plays()
        {
            Console.Write("Ад театър: ");
            int id_plays = int.Parse(Console.ReadLine());

            Console.Write("Ад актьор: ");
            int id_actors = int.Parse(Console.ReadLine());

            string sql = "INSERT INTO Unite_Plays (Id_Plays, Id_Actors) VALUES (@Id_Plays, @Id_Actors)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand comand = new SqlCommand(sql, connection))
                {
                    comand.Parameters.AddWithValue("@Id_Plays", id_plays);
                    comand.Parameters.AddWithValue("@Id_Actors", id_actors);

                    try
                    {
                        connection.Open();
                        comand.ExecuteNonQuery();
                        Console.WriteLine($"Успешно добавихте запис в таблицата Unite_Plays.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Грешка: " + ex.Message);
                    }
                }
            }
        }

        static void Zaqvka1()
        {
            Console.WriteLine("Ваведете името което искате да проверите дали съществува:");
            string name = Console.ReadLine();
            string sql = $"SELECT COUNT(*)\r\nFROM [Actors]\r\nWHERE [First_name] = '{name}';";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            using (connection)
            {
                using (SqlCommand comand = new SqlCommand(sql, connection))
                {
                    
                    using (SqlDataReader reader = comand.ExecuteReader())
                    {
                        
                        while (reader.Read())
                        {
                            Console.WriteLine($"Има {reader[0]} актьор(и) с името {name} ");
                        }
                    }
                }
            }
        }

        static void Zaqvka2()
        {
            Console.WriteLine("Всички театри ваведени в системата:");
            string sql = $"SELECT *\r\nFROM [Teathers];";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            using (connection)
            {
                using (SqlCommand comand = new SqlCommand(sql, connection))
                {

                    using (SqlDataReader reader = comand.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader[1]}");
                        }
                    }
                }
            }
        }

        static void Zaqvka3()
        {
            Console.WriteLine("Ваведете teatyr, в който искате да видите актьорския състав :");
            string name = Console.ReadLine();
            string sql = $"SELECT a.First_name, a.Last_name\r\nFROM Teathers t\r\nJOIN Unite u ON t.Id_Teathers = u.Id_Teathers\r\nJOIN Actors a ON u.Id_Actors = a.Id_Actors\r\nWHERE t.[Name] = N'{name}'";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            using (connection)
            {
                using (SqlCommand comand = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = comand.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader[0]} {reader[1]}");
                        }
                    }
                }
            }
        }

        static void Zaqvka4()
        {
            Console.WriteLine("Ваведете град :");
            string city = Console.ReadLine();
            string sql = $"SELECT \r\n    t.City,\r\n    COUNT(DISTINCT a.Id_Actors) AS ActorsCount\r\nFROM Teathers t\r\nJOIN Unite u ON t.Id_Teathers = u.Id_Teathers\r\nJOIN Actors a ON u.Id_Actors = a.Id_Actors\r\nWHERE t.City = N'{city}'\r\nGROUP BY t.City;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            using (connection)
            {
                using (SqlCommand comand = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = comand.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader[1]}");
                        }
                    }
                }
            }
        }

        static void Zaqvka5()
        {
            Console.WriteLine("Ваведете година :");
            int year = int.Parse(Console.ReadLine());
            string sql = $"SELECT Name, Year_Creation, City\r\nFROM Teathers \r\nWHERE Year_Creation = '{year}';";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            using (connection)
            {
                using (SqlCommand comand = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = comand.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader[2]}");
                        }
                    }
                }
            }
        }

        static void Zaqvka6()
        {
            Console.WriteLine("Ваведете град :");
            string city = Console.ReadLine();
            string sql = $"SELECT [Name], Year_Creation, City\r\nFROM Teathers \r\nWHERE City = N'{city}';";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            using (connection)
            {
                using (SqlCommand comand = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = comand.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader[0]}");
                        }
                    }
                }
            }
        }


        //1.Намиране на брой актьори по име
        //2.Изпечатване на всички театри
        //3.Намери в кой театър кои актьори играят 
        //4.Намиране по град колго броя актьори са в него
        //5.Намери театрите по ваведена година
        //6.Намери театъра по ваведен град
        //Намери по театър, в този театър кои песи се играят
        //Намери по пиеса, кои актьори играят
        //Брой актьори във всеки град:


    }
}
