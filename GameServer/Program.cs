using Base;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace GameServer
{
    class Program
    {
        private static bool uniqueUser = true;
        private const int MESSAGE_TYPE_GET_MESSAGES = 1;

        private const int MESSAGE_TYPE_SEND_NEW_MESSAGE = 2;
        private const int MESSAGE_TYPE_READ_NEW_MESSAGE = 3;

        private const int MESSAGE_TYPE_GET_USER_REQUEST = 4;
        private const int MESSAGE_TYPE_GET_USER_SUCCESS = 5;
        private const int MESSAGE_TYPE_GET_USER_ERROR = 6;

        private const int MESSAGE_TYPE_INSERT_USER_REQUEST = 7;
        private const int MESSAGE_TYPE_INSERT_USER_SUCCESS = 8;
        private const int MESSAGE_TYPE_INSERT_USER_ERROR = 9;

        private const int MESSAGE_TYPE_RECOVERY_USER_PASSWORD_REQUEST = 10;
        private const int MESSAGE_TYPE_RECOVERY_USER_PASSWORD_SUCCESS = 11;
        private const int MESSAGE_TYPE_RECOVERY_USER_PASSWORD_ERROR = 12;

        private const int MESSAGE_TYPE_UPDATE_PASSWORD_REQUEST = 13;
        private const int MESSAGE_TYPE_UPDATE_PASSWORD_SUCCESS = 14;
        private const int MESSAGE_TYPE_UPDATE_PASSWORD_ERROR = 15;

        private const int MESSAGE_TYPE_MATCH_DATA_REQUEST = 16;
        private const int MESSAGE_TYPE_MATCH_DATA_SUCCESS = 17;
        private const int MESSAGE_TYPE_MATCH_DATA_WAITING = 18;

        static int totPlayersInMatch = 0;
        static List<ThreadClient> clients = new List<ThreadClient>();
        static void Main(string[] args)
        {
            Console.WriteLine("Servidor Aguardando conexões...");
            Server server = new Server("127.0.0.1", 5000);

            server.Start(OnClientConnect, OnClientReceiveMessage);
            Console.WriteLine("Servidor OK...");
        }
        static void OnClientConnect(object sender, EventArgs eventArgs)
        {
            ConnectEventArgs connectEventArgs = eventArgs as ConnectEventArgs;

            if (connectEventArgs != null)
            {
                ThreadClient client = connectEventArgs.Client;

                clients.Add(client);

                Console.WriteLine($"Cliente nº {clients.Count()} conectou-se.");
            }
        }
        private enum Type
        {
            Terra = 1,
            Pedra = 2,
            Item = 3,
            Unidade1 = 4,
            Unidade2 = 5,
            Unidade3 = 6
        }
        private static int[] InitializeArrayWithNoDuplicates(int start, int size)
        {
            Random rand = new Random(start);

            return Enumerable.Repeat<int>(0, size).Select((value, index) => new { i = index + start, rand = rand.Next() }).OrderBy(x => x.rand).Select(x => x.i).ToArray();
        }
        private static int[] GenerateMatchData()
        {
            int qtdUnidade1 = 80;
            int qtdUnidade2 = 60;
            int qtdUnidade3 = 40;
            int qtdItens = 20;
            int qtdPedra = 50;
            int qtdTerra = 100;
            int qtdPosicoes = 350;

            int index = 0;
            int[] indexes = InitializeArrayWithNoDuplicates(0, qtdPosicoes / 2);

            int[] itens = new int[qtdPosicoes];

            for (int i = 0; i < qtdUnidade1 / 2; i++)
            {
                itens[indexes[index++]] = (Int32)Type.Unidade1;
            }

            for (int i = 0; i < qtdUnidade2 / 2; i++)
            {
                itens[indexes[index++]] = (Int32)Type.Unidade2;
            }

            for (int i = 0; i < qtdUnidade3 / 2; i++)
            {
                itens[indexes[index++]] = (Int32)Type.Unidade3;
            }

            for (int i = 0; i < qtdTerra / 2; i++)
            {
                itens[indexes[index++]] = (Int32)Type.Terra;
            }

            for (int i = 0; i < qtdPedra / 2; i++)
            {
                itens[indexes[index++]] = (Int32)Type.Pedra;
            }

            for (int i = 0; i < qtdItens / 2; i++)
            {
                itens[indexes[index++]] = (Int32)Type.Item;
            }

            // --------------------------------------------------------------------------------------------------------------- //

            index = 0;
            indexes = InitializeArrayWithNoDuplicates(175, qtdPosicoes / 2);

            for (int i = 0; i < qtdUnidade1 / 2; i++)
            {
                itens[indexes[index++]] = (Int32)Type.Unidade1;
            }

            for (int i = 0; i < qtdUnidade2 / 2; i++)
            {
                itens[indexes[index++]] = (Int32)Type.Unidade2;
            }

            for (int i = 0; i < qtdUnidade3 / 2; i++)
            {
                itens[indexes[index++]] = (Int32)Type.Unidade3;
            }

            for (int i = 0; i < qtdTerra / 2; i++)
            {
                itens[indexes[index++]] = (Int32)Type.Terra;
            }

            for (int i = 0; i < qtdPedra / 2; i++)
            {
                itens[indexes[index++]] = (Int32)Type.Pedra;
            }

            for (int i = 0; i < qtdItens / 2; i++)
            {
                itens[indexes[index++]] = (Int32)Type.Item;
            }
            return itens;
        }
        static bool InsertUser(string name, string username, string password, string birthDate, string securityText)
        {
            bool result = false;

            using (SqlConnection connection = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=game;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                try
                {
                    connection.Open();

                    SqlCommand sqlCommand = connection.CreateCommand();

                    sqlCommand.CommandText = "INSERT INTO player (name, username, password, birthDate, securityText) values (@name, @username, @password, @birthDate, @securityText)";

                    sqlCommand.Parameters.Add(new SqlParameter("name", name));
                    sqlCommand.Parameters.Add(new SqlParameter("username", username));
                    sqlCommand.Parameters.Add(new SqlParameter("password", password));
                    sqlCommand.Parameters.Add(new SqlParameter("birthDate", birthDate));
                    sqlCommand.Parameters.Add(new SqlParameter("securityText", securityText));

                    sqlCommand.ExecuteNonQuery();

                    connection.Close();
                    uniqueUser = true;
                    result = true;
                    Console.WriteLine($"Usuário {username} inserido com sucesso no banco de dados!");
                }
                catch (SqlException sqlEx)
                {
                    if (sqlEx.Number == 2627)
                    {
                        uniqueUser = false;
                        result = false;
                        Console.WriteLine($"Usuário {username} não foi inserido no banco de dados. Usuário já existente!");
                    }
                    else
                    {
                        result = false;
                        Console.WriteLine($"Usuário {username} não foi inserido no banco de dados.");
                    }
                }
                catch (Exception)
                {
                    result = false;
                    Console.WriteLine($"Usuário {username} não foi inserido no banco de dados. Usuário já existente!");
                }
                return result;
            }

        }
        static dynamic GetUser(string username, string password)
        {
            dynamic result;

            using (SqlConnection connection = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=game;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                try
                {
                    connection.Open();

                    SqlCommand sqlCommand = connection.CreateCommand();

                    sqlCommand.CommandText = @"
						SELECT idPlayer
							  ,[name]
							  ,username
							  ,[password]
							  ,experience
							  ,birthDate
							  ,securityText
						  FROM player
						WHERE username = @username AND password = @password
					";

                    sqlCommand.Parameters.Add(new SqlParameter("username", username));
                    sqlCommand.Parameters.Add(new SqlParameter("password", password));

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.Read() == true)
                    {
                        result = new
                        {
                            type = MESSAGE_TYPE_GET_USER_SUCCESS,
                            userId = reader.GetInt32(reader.GetOrdinal("idPlayer")),
                            userName = reader.GetString(reader.GetOrdinal("username")),
                            name = reader.GetString(reader.GetOrdinal("name"))
                        };
                        Console.WriteLine($"Usuário {username} realizou login!");
                    }
                    else
                    {
                        result = null;
                        Console.WriteLine($"Usuário {username} falhou no login!");
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return result;
        }
        static dynamic GetValidateUser(string username, string birthDate, string securityText)
        {
            dynamic result;

            using (SqlConnection connection = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=game;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                try
                {
                    connection.Open();

                    SqlCommand sqlCommand = connection.CreateCommand();

                    sqlCommand.CommandText = @"
						SELECT idPlayer
						  FROM player
						WHERE username = @username AND birthDate = @birthDate AND securityText = @securityText
					";

                    sqlCommand.Parameters.Add(new SqlParameter("username", username));
                    sqlCommand.Parameters.Add(new SqlParameter("birthDate", birthDate));
                    sqlCommand.Parameters.Add(new SqlParameter("securityText", securityText));

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.Read() == true)
                    {
                        result = new
                        {
                            type = MESSAGE_TYPE_RECOVERY_USER_PASSWORD_SUCCESS,
                            idPlayer = reader.GetInt32(reader.GetOrdinal("idPlayer"))
                        };
                        Console.WriteLine($"As informações foram verificadas para o usuário {username}!");
                    }
                    else
                    {
                        result = null;
                        Console.WriteLine($"As informações não foram verificadas para o usuário {username}!");
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return result;
        }
        static bool UpdatePassword(Int32 idPlayer, String newPassword)
        {
            bool result = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=game;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
                {
                    connection.Open();

                    SqlCommand sqlCommand = connection.CreateCommand();

                    sqlCommand.CommandText = "UPDATE player SET password = @newPassword where idPlayer = @idPlayer";

                    sqlCommand.Parameters.Add(new SqlParameter("idPlayer", idPlayer));
                    sqlCommand.Parameters.Add(new SqlParameter("newPassword", newPassword));

                    sqlCommand.ExecuteNonQuery();

                    connection.Close();

                    result = true;

                    Console.WriteLine($"Senha alterado com sucesso. Jogador de ID {idPlayer}");
                }
            }
            catch (Exception ex)
            {
                result = false;
                Console.WriteLine($"Falha ao alterar senha do Jogador de ID {idPlayer}");
            }

            return result;
        }
        static bool InsertMessage(int idPlayer, string messageText)
        {
            bool result = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=game;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
                {
                    connection.Open();

                    SqlCommand sqlCommand = connection.CreateCommand();

                    sqlCommand.CommandText = "INSERT INTO [message] (idPlayer, text, dateTime) values (@idPlayer, @text, CURRENT_TIMESTAMP)";

                    sqlCommand.Parameters.Add(new SqlParameter("idPlayer", idPlayer));
                    sqlCommand.Parameters.Add(new SqlParameter("text", messageText));

                    sqlCommand.ExecuteNonQuery();

                    connection.Close();

                    result = true;
                }
            }
            catch
            {
                result = false;
            }

            return result;
        }
        static List<dynamic> GetMessages()
        {
            List<dynamic> result = new List<dynamic>();

            using (SqlConnection connection = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=game;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                try
                {
                    connection.Open();

                    SqlCommand sqlCommand = connection.CreateCommand();

                    sqlCommand.CommandText = @"
						SELECT 
                        plr.idPlayer,
						plr.name AS 'name', 
                        plr.userName,
                        msg.dateTime,
						msg.text
						FROM [message] msg JOIN [player] plr ON plr.idPlayer = msg.idPlayer 
						ORDER BY msg.dateTime
					";

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read() == true)
                    {
                        result.Add(new
                        {
                            type = MESSAGE_TYPE_READ_NEW_MESSAGE,
                            userName = reader.GetString(reader.GetOrdinal("userName")),
                            namePlayer = reader.GetString(reader.GetOrdinal("name")),
                            dateTime = reader.GetDateTime(reader.GetOrdinal("dateTime")).ToString("dd/MM/yyyy HH:mm:ss"),
                            messageText = reader.GetString(reader.GetOrdinal("text"))
                        });
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    result.Clear();
                }
            }

            return result;
        }
        static void StartMatch()
        {
            int isFirst = 1;
            int[] data = GenerateMatchData();

            foreach (ThreadClient client in clients)
            {
                client.SendMessage(new
                {
                    type = MESSAGE_TYPE_MATCH_DATA_SUCCESS,
                    data,
                    isFirst
                });

                isFirst = 0;
            }
        }
        static void OnClientReceiveMessage(object sender, EventArgs eventArgs)
        {
            MessageEventArgs messageEventArgs = eventArgs as MessageEventArgs;

            if (messageEventArgs != null)
            {
                Message message = messageEventArgs.Message;

                int type = message.GetInt32("type");
                ThreadClient client = sender as ThreadClient;

                switch (type)
                {
                    case MESSAGE_TYPE_GET_MESSAGES:
                        if (client != null)
                        {
                            List<dynamic> messages = GetMessages();

                            foreach (dynamic messageFromDB in messages)
                            {
                                client.SendMessage(messageFromDB);
                            }
                        }
                        break;
                    case MESSAGE_TYPE_SEND_NEW_MESSAGE:
                        int userIdNewMsg = message.GetInt32("userId");
                        string userName = message.GetString("userName");
                        string namePlayer = message.GetString("namePlayer");
                        string dateTime = message.GetString("dateTime");
                        string messageText = message.GetString("messageText");

                        if (InsertMessage(userIdNewMsg, messageText) == true)
                        {
                            foreach (ThreadClient clientNewMsg in clients)
                            {
                                clientNewMsg.SendMessage(new
                                {
                                    type = MESSAGE_TYPE_READ_NEW_MESSAGE,
                                    userName,
                                    namePlayer,
                                    dateTime,
                                    messageText
                                });
                            }
                        }
                        break;
                    case MESSAGE_TYPE_INSERT_USER_REQUEST:
                        if (client != null)
                        {

                            string name = message.GetString("name");
                            string username = message.GetString("username");
                            string password = message.GetString("password");
                            string birthDate = message.GetString("birthDate");
                            string securityText = message.GetString("securityText");

                            bool userInserted = InsertUser(name, username, password, birthDate, securityText);

                            if (userInserted == true)
                            {
                                client.SendMessage(new
                                {
                                    type = MESSAGE_TYPE_INSERT_USER_SUCCESS,
                                    success = "Usuário cadastrado com sucesso"
                                });
                            }
                            else
                            {
                                if (uniqueUser == false)
                                {
                                    client.SendMessage(new
                                    {
                                        type = MESSAGE_TYPE_INSERT_USER_ERROR,
                                        error = $"Já existe um usuário '{username}' cadastrado no sistema"
                                    });
                                }
                                else
                                {
                                    client.SendMessage(new
                                    {
                                        type = MESSAGE_TYPE_INSERT_USER_ERROR,
                                        error = "Falha ao tentar cadastrar o usuário, favor tentar novamente"
                                    });
                                }
                            }
                        }
                        break;
                    case MESSAGE_TYPE_GET_USER_REQUEST:
                        if (client != null)
                        {
                            string login = message.GetString("login");
                            string password = message.GetString("password");

                            dynamic userData = null;
                            bool hasException = false;

                            try
                            {
                                userData = GetUser(login, password);

                            }
                            catch
                            {
                                hasException = true;
                            }

                            if (hasException)
                            {
                                client.SendMessage(new
                                {
                                    type = MESSAGE_TYPE_GET_USER_ERROR,
                                    error = "Falha ao tentar fazer o login, favor tentar novamente"
                                });
                            }
                            else
                            {
                                if (userData != null)
                                {
                                    client.SendMessage(userData);
                                }
                                else
                                {
                                    client.SendMessage(new
                                    {
                                        type = MESSAGE_TYPE_GET_USER_ERROR,
                                        error = "Falha ao tentar fazer o login, usuário ou senha inválido"
                                    });
                                }
                            }
                        }
                        break;
                    case MESSAGE_TYPE_RECOVERY_USER_PASSWORD_REQUEST:
                        if (client != null)
                        {
                            string username = message.GetString("username");
                            string birthDate = message.GetString("birthDate");
                            string securityText = message.GetString("securityText");

                            dynamic recoveryData = null;
                            bool hasException = false;

                            try
                            {
                                recoveryData = GetValidateUser(username, birthDate, securityText);
                            }
                            catch
                            {
                                hasException = true;
                            }


                            if (hasException)
                            {
                                client.SendMessage(new
                                {
                                    type = MESSAGE_TYPE_RECOVERY_USER_PASSWORD_ERROR,
                                    error = "Falha ao recuperar dados, favor tentar novamente"
                                });
                            }
                            else
                            {
                                if (recoveryData != null)
                                {
                                    client.SendMessage(recoveryData);
                                }
                                else
                                {
                                    client.SendMessage(new
                                    {
                                        type = MESSAGE_TYPE_RECOVERY_USER_PASSWORD_ERROR,
                                        error = "Falha ao recuperar dados, favor tentar novamente"
                                    });
                                }
                            }
                        }
                        break;
                    case MESSAGE_TYPE_UPDATE_PASSWORD_REQUEST:
                        if (client != null)
                        {
                            int idPlayer = message.GetInt32("idPlayer");
                            string password = message.GetString("password");

                            bool updateResult = false;
                            bool hasException = false;

                            try
                            {
                                updateResult = UpdatePassword(idPlayer, password);
                            }
                            catch
                            {
                                hasException = true;
                            }


                            if (hasException)
                            {
                                client.SendMessage(new
                                {
                                    type = MESSAGE_TYPE_UPDATE_PASSWORD_ERROR,
                                    error = "Falha ao recuperar dados, favor tentar novamente"
                                });
                            }
                            else
                            {
                                if (updateResult == true)
                                {
                                    client.SendMessage(new
                                    {
                                        type = MESSAGE_TYPE_UPDATE_PASSWORD_SUCCESS
                                    });
                                }
                                else
                                {
                                    client.SendMessage(new
                                    {
                                        type = MESSAGE_TYPE_UPDATE_PASSWORD_ERROR,
                                        error = "Falha ao recuperar dados, favor tentar novamente"
                                    });
                                }
                            }
                        }
                        break;
                    case MESSAGE_TYPE_MATCH_DATA_REQUEST:
                        totPlayersInMatch++;

                        if (totPlayersInMatch == 2)
                        {
                            totPlayersInMatch = 0;
                            StartMatch();
                        }
                        else
                        {
                            client.SendMessage(new
                            {
                                type = MESSAGE_TYPE_MATCH_DATA_WAITING
                            });
                        }
                        break;
                }
            }
        }

    }
}
