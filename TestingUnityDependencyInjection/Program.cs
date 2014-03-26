using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace TestingUnityDependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            IPlayer player1 = Factory.CreateInstance();
            player1.PlayerName = "Pepe";
            player1.TeamName = "Spain";
            player1.DisplayDetails();

            IPlayer player2 = Factory.CreateInstance();
            player2.PlayerName = "Pierre";
            player2.TeamName = "France";
            player2.DisplayDetails();

            Console.ReadLine();

        }
    }
    public interface IPlayer
    {
        string PlayerName { get; set; }
        string TeamName { get; set; }
        void DisplayDetails();
    }
    public class Player : IPlayer
    {
        private string playerName;
        private string teamName;
        public string PlayerName
        {
            get { return playerName; }
            set { this.playerName = value; }
        }

        public string TeamName
        {
            get { return teamName;}
            set { this.teamName = value; }
        }

        public void DisplayDetails()
        {
            Console.WriteLine("Player Name = \t" + playerName + " \tPlayer Team Name = \t" + teamName);
        }
    }
    public class MockPlayer : IPlayer
    {
        private string playerName;
        private string teamName;
        public string PlayerName
        {
            get { return playerName; }
            set { this.playerName = value; }
        }

        public string TeamName
        {
            get { return teamName; }
            set { this.teamName = value; }
        }

        public void DisplayDetails()
        {
            Console.WriteLine("Mock Player Name = \t" + playerName + " \tPlayer Team Name = \t" + teamName);
        }
    }
    public class Factory
    {
        public static IPlayer CreateInstance()
        {
            IUnityContainer _container = new UnityContainer();
            _container.RegisterType(typeof(IPlayer), typeof(Player));
            _container.RegisterType(typeof(IPlayer), typeof(MockPlayer));
            IPlayer player = _container.Resolve<IPlayer>();
            return player;
        }
        

    }
}
