using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    interface ICharacter
    {
        int Health { get; set; }

        void Attack();
    }

    class HumanArcher : ICharacter
    {
        public int Health { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Attack()
        {
            Console.WriteLine("HumanArcher: Attack");
        }
    }
    class HumanWarrior : ICharacter
    {
        public int Health { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Attack()
        {
            Console.WriteLine("HumanWarrior: Attack");
        }
    }

    class OrkArcher : ICharacter
    {
        public int Health { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Attack()
        {
            Console.WriteLine("OrkArcher: Attack");
        }
    }
    class OrkWarrior : ICharacter
    {
        public int Health { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Attack()
        {
            Console.WriteLine("OrkWarrior: Attack");
        }
    }

    class ElfArcher : ICharacter
    {
        public int Health { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Attack()
        {
            Console.WriteLine("ElfArcher: Attack");
        }
    }
    class ElfWarrior : ICharacter
    {
        public int Health { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Attack()
        {
            Console.WriteLine("ElfWarrior: Attack");
        }
    }

    interface ICharactersRace
    {
        ICharacter CreateArcher();
        ICharacter CreateWarrior();
    }

    class HumanCharactersRace : ICharactersRace
    {
        public ICharacter CreateArcher()
        {
            return new HumanArcher();
        }

        public ICharacter CreateWarrior()
        {
            return new HumanWarrior();
        }
    }

    class OrkCharactersRace : ICharactersRace
    {
        public ICharacter CreateArcher()
        {
            return new OrkArcher();
        }

        public ICharacter CreateWarrior()
        {
            return new OrkWarrior();
        }
    }

    class ElfCharactersRace : ICharactersRace
    {
        public ICharacter CreateArcher()
        {
            return new ElfArcher();
        }

        public ICharacter CreateWarrior()
        {
            return new ElfWarrior();
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            int action = -1;

            Console.WriteLine("[1] Human");
            Console.WriteLine("[2] Ork");
            Console.WriteLine("[3] Elf");
            action = int.Parse(Console.ReadLine());

            ICharactersRace charactersRaceFactory = null;

            switch(action)
            {
                case 1:
                    charactersRaceFactory = new HumanCharactersRace();
                    break;
                case 2:
                    charactersRaceFactory = new OrkCharactersRace();
                    break;
                case 3:
                    charactersRaceFactory = new ElfCharactersRace();
                    break;
            }

            Console.WriteLine("[1] Archer");
            Console.WriteLine("[2] Warrior");
            action = int.Parse(Console.ReadLine());
            ICharacter character = null;


            switch (action)
            {
                case 1:
                    character = charactersRaceFactory.CreateArcher();
                    break;
                case 2:
                    character = charactersRaceFactory.CreateWarrior();
                    break;
            }

            character.Attack();



            Console.Read();
        }
    }
}
