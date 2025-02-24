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
                Console.WriteLine("7 - Изход");

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
                        return;
                    case "7":
                        Console.WriteLine();
                        return;
                    default:
                        Console.WriteLine("Невалиден избор.");
                        break;
                }
            }
            Console.ReadLine();
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
                        int rowsAffected = comand.ExecuteNonQuery();
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

                        int rowsAffected = comand.ExecuteNonQuery();

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
                        int rowsAffected = comand.ExecuteNonQuery();

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
                        int rowsAffected = comand.ExecuteNonQuery();

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
                        int rowsAffected = comand.ExecuteNonQuery();

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
            string insert = "INSERT INTO [Teathers] ([Name], [Year_Creation], [City])VALUES ('Градски Театър', 1900, 'София'),('Национален Театър', 1850, 'Пловдив'),('Кралски театър', 1888, 'Лондон'),('Бродвей театър', 1903, 'Ню Йорк');";
            string insert1 = "INSERT INTO [Actors] ([First_Name], [Last_Name], [Birthday], [Education], [City])VALUES ('Иван', 'Иванов', '1980-01-01', 'Висше изкуство', 'София'), ('Петър', 'Петров', '1990-05-15', 'Театрално образование', 'Варна'),('Иван', 'Петров', '1985-06-15', 'Национална академия за театър и филм', 'София'),('Ема', 'Джонсън', '1992-09-22', 'Лондонска театрална академия', 'Лондон');";
            string insert2 = "INSERT INTO [Plays] ([Title], [Years])VALUES ('Хамлет', 1600),('Ромео и Жулиета', 1597),('Женитба', 1842),('Макбет', 1606);";
            string insert3 = "INSERT INTO [Proprietary] ([Clothes], [Subjects], [Electronics])VALUES('Костюми', 'Реквизит', 'Светлини'),('Сцени', 'Реквизит', 'Звук'),('Костюми класически', 'Театрални реквизити', 'Звукова апаратура'),('Модерни костюми', 'Сценични декори', 'Осветителни тела');";
            string insert4 = "INSERT INTO [Unite] ([Id_Teathers], [Id_Actors])VALUES (1, 1),(2, 2),(1, 3), (3, 3);";
            string insert5 = "INSERT INTO [Unite_Plays] ([Id_Plays], [Id_Actors])VALUES(1, 1),(2, 1),(3, 2),(4, 3);";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand comand = new SqlCommand(insert, conn))
                {
                    try
                    {
                        int rowsAffected = comand.ExecuteNonQuery();
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
                        int rowsAffected = comand.ExecuteNonQuery();

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
                        int rowsAffected = comand.ExecuteNonQuery();

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
                        int rowsAffected = comand.ExecuteNonQuery();

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
                        int rowsAffected = comand.ExecuteNonQuery();

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
                        int rowsAffected = comand.ExecuteNonQuery();
                        Console.WriteLine($"Успешно добавихте {rowsAffected} запис(а) в таблицата Teathers.");
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
                        int rowsAffected = comand.ExecuteNonQuery();
                        Console.WriteLine($"Успешно добавихте {rowsAffected} запис(а) в таблицата Actors.");
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
                        int br = comand.ExecuteNonQuery();
                        Console.WriteLine($"Успешно добавихте {br} запис(а) в таблицата Plays.");
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
                        int rowsAffected = comand.ExecuteNonQuery();
                        Console.WriteLine($"Успешно добавихте {rowsAffected} запис(а) в таблицата Proprietary.");
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
                        int rowsAffected = comand.ExecuteNonQuery();
                        Console.WriteLine($"Успешно добавихте {rowsAffected} запис(а) в таблицата Unite.");
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
            int id_Plays = int.Parse(Console.ReadLine());

            Console.Write("Ад актьор: ");
            int id_Actors = int.Parse(Console.ReadLine());

            string sql = "INSERT INTO Unite (Id_Plays, Id_Actors) VALUES (@Id_Plays, @Id_Actors)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand comand = new SqlCommand(sql, connection))
                {
                    comand.Parameters.AddWithValue("@Id_Plays", id_Plays);
                    comand.Parameters.AddWithValue("@Id_Actors", id_Actors);

                    try
                    {
                        connection.Open();
                        int rowsAffected = comand.ExecuteNonQuery();
                        Console.WriteLine($"Успешно добавихте {rowsAffected} запис(а) в таблицата Unite.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Грешка: " + ex.Message);
                    }
                }
            }
        }
    }
}
