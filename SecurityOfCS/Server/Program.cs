using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

class Account
{
    public string login;
    public string password;
    public string Action;
}

internal class Program
{
    public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCS;Integrated Security=True";
    public static TcpListener serverSocket = new(IPAddress.Parse("127.0.0.1"), 7000);
    public static TcpClient clientSocket = new();
    public static NetworkStream stream;
    private static void Main(string[] args)
    {
        try
        {
            serverSocket.Start();
            Console.WriteLine("Сервер запущен");

            while (true)
            {
                clientSocket = serverSocket.AcceptTcpClient();
                stream = clientSocket.GetStream();

                byte[] bytesIn = new byte[256];
                int length = stream.Read(bytesIn, 0, bytesIn.Length);
                string request = Encoding.UTF8.GetString(bytesIn, 0, length);
                

                string action = GetData(request).Action;
                if(action == "1") //регистрация нового пользователя
                {
                    CreateNewAccount(GetData(request).login, GetData(request).password);
                }
                if(action == "2") //авторизация пользователя
                {

                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
    static Account GetData(string registrationData)
    {
        Account account = new();

        (account.Action, account.login, account.password) = (registrationData.Split(' ')[0], registrationData.Split(' ')[1], registrationData.Split(' ')[2]);
        return account;
    }
    static string GetHashMD5(string str)
    {
        var md5 = MD5.Create();
        var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
        return Convert.ToBase64String(hash);
    }
    static string GenerateCallWord()
    {
        Random random = new Random();
        Random rand = random;
        int stringlen = rand.Next(4, 10);
        int randValue;
        string str = "";
        char letter;
        for (int i = 0; i < stringlen; i++)
        {
            randValue = rand.Next(0, 26);
            letter = Convert.ToChar(randValue + 65);
            str += letter;
        }
        return str;
    }
    static void CreateNewAccount(string login, string password)
    {
        byte[] bytesOut = new byte[256];
        string answer = "";
        using (SqlConnection connection = new(connectionString))
        {
            string callWord = GenerateCallWord();
            string hashPassword = GetHashMD5(password);
            string hashCallWord = GetHashMD5(callWord);
            string hashPW = GetHashMD5(hashPassword + hashCallWord);

            connection.Open();
            SqlCommand command = new()
            {
                Connection = connection,
                CommandText = @"INSERT INTO Registration VALUES (@login, @hashPassword, @callWord)"
            };
            command.Parameters.Add("@login", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@hashPassword", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@callWord", SqlDbType.NVarChar, 50);

            try
            {
                command.Parameters["@login"].Value = login;
                command.Parameters["@hashPassword"].Value = hashPW;
                command.Parameters["@callWord"].Value = callWord;
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                answer = "Такой логин уже существует";
                Console.WriteLine("Аккаунт не создан");
                bytesOut = Encoding.UTF8.GetBytes(answer);
                stream.Write(bytesOut, 0, bytesOut.Length);
                stream.Flush();
                clientSocket.Close();
                return;
            }
        }
        answer = "Аккаунт успешно создан!";
        Console.WriteLine("Аккаунт создан");
        bytesOut = Encoding.UTF8.GetBytes(answer);
        stream.Write(bytesOut, 0, bytesOut.Length);
        stream.Flush();
        clientSocket.Close();
    }
}

