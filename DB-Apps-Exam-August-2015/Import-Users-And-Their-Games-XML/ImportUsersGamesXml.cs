using System;
using System.Linq;
using EF_Mappings;
using System.Xml;

namespace Import_Users_And_Their_Games_XML
{
    class ImportUsersGamesXml
    {
        private static void Main()
        {
            var context = new DiabloEntities();

            XmlDocument doc = new XmlDocument();
            doc.Load("../../users-and-games.xml");

            XmlElement root = doc.DocumentElement;

            foreach (XmlNode xmlUser in root.ChildNodes)
            {
                User user = ExtractUserData(xmlUser);

                if (context.Users.Any(u => u.Username == user.Username))
                {
                    Console.WriteLine("User {0} already exists", user.Username);
                    continue;
                }
                else
                {
                    context.Users.Add(user);
                    Console.WriteLine("Successfully added user {0}", user.Username);
                }

                XmlNode gamesNode = xmlUser.SelectSingleNode("games");
                foreach (XmlNode xmlGame in gamesNode)
                {
                    
                    string[] joined = xmlGame.SelectSingleNode("joined-on").InnerText.Split('/').ToArray();
                    int year = int.Parse(joined[2]);
                    int month = int.Parse(joined[1]);
                    int day = int.Parse(joined[0]);
                    XmlNode xmlCharacter = xmlGame.SelectSingleNode("character");

                    string characterName = xmlCharacter.Attributes["name"].Value;
                    decimal characterCash = decimal.Parse(xmlCharacter.Attributes["cash"].Value);
                    int characterLevel = int.Parse(xmlCharacter.Attributes["level"].Value);
                    DateTime joinedOn = new DateTime(year, month, day);
                    string gameName = xmlGame.SelectSingleNode("game-name").InnerText;

                    UsersGame newGame = new UsersGame
                    {
                        User = user,
                        Cash = characterCash,
                        Level = characterLevel,
                        Character = context.Characters.FirstOrDefault(c => c.Name == characterName),
                        JoinedOn = joinedOn,
                        Game = context.Games.FirstOrDefault(g => g.Name == gameName)
                    };

                    context.UsersGames.Add(newGame);
                    Console.WriteLine("User {0} successfully added to game {1}", user.Username, gameName);
                }

                //save here to make sure either the user with all games is saved, or nothing
                context.SaveChanges();
            }
        }

        private static User ExtractUserData(XmlNode xmlUser)
        {
            string firstName = null;
            if (xmlUser.Attributes["first-name"] != null)
            {
                firstName = xmlUser.Attributes["first-name"].Value;
            }

            string lastName = null;
            if (xmlUser.Attributes["last-name"] != null)
            {
                lastName = xmlUser.Attributes["last-name"].Value;
            }

            string email = null;
            if (xmlUser.Attributes["email"] != null)
            {
                email = xmlUser.Attributes["email"].Value;
            }


            bool isDeleted = false;
            if (xmlUser.Attributes["is-deleted"].Value == "1")
            {
                isDeleted = true;
            }

            string username = xmlUser.Attributes["username"].Value;
            string ipAddress = xmlUser.Attributes["ip-address"].Value;

            string[] regDate = xmlUser.Attributes["registration-date"].Value.Split('/').ToArray();
            int year = int.Parse(regDate[2]);
            int month = int.Parse(regDate[1]);
            int day = int.Parse(regDate[0]);
            DateTime registrationDate = new DateTime(year, month, day);

            User user = new User
            {
                Username = username,
                IsDeleted = isDeleted,
                IpAddress = ipAddress,
                RegistrationDate = registrationDate,
                FirstName = firstName,
                LastName = lastName,
                Email = email
            };

            return user;
        }
    }
}