using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp77_interface_chapter2
{
    interface IHasInfo
    {
        void ShowInfo();
    }

    interface IWeapon
    {
        int Damage { get; }
        void Fire();
    }

    /// <summary>
    /// Абстрактное оружие
    /// </summary>
    abstract class Weapon : IHasInfo, IWeapon
    {
        /// <summary>
        /// Абстрактное свойство
        /// </summary>
        public abstract int Damage { get; }

        /// <summary>
        /// Абстрактный метод Fire 
        /// (абстрактные методы не имеют реализации, такие методы могут находится только в абстрактных классах)
        /// </summary>
        public abstract void Fire();

        /// <summary>
        /// 
        /// </summary>
        public void ShowInfo()
        {
            //Выводим в консоль имя типа данных и урон наносимый оружием
            //GetType метод типа Object
            Console.WriteLine($"{GetType().Name} Damage: {Damage}");
        }
    }

    class Gun : Weapon
    {
        public override int Damage { get { return 5; } }

        public override void Fire()
        {
            Console.WriteLine("Пыщ!");
        }
    }

    class LaserGun : Weapon
    {
        public override int Damage { get { return 8; } }
        public override void Fire()
        {
            Console.WriteLine("Пиу!");
        }
    }

    class Bow : Weapon
    {
        ///<summary>
        /// эта запись является лямбда выражением, она равнозначна записи: public override int Damage { get { return 3; } }
        /// </summary>
        public override int Damage => 3;

        public override void Fire()
        {
            Console.WriteLine("Чпуньк!");
        }
    }
    class Player
    {
        public void Fire(IWeapon weapon)
        {
            weapon.Fire();
        }

        /// <summary>
        ///Проверка информации об оружии которое будет использоваться
        /// </summary>
        public void CheckInfo(IHasInfo hasInfo)
        {
            hasInfo.ShowInfo();
        }
    }

    class Box : IHasInfo
    {
        public void ShowInfo()
        {
            Console.WriteLine("Йа коробко");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            Player player = new Player();

            //Массив типа Weapon элементами которого являются объекты классов: Gun, LaserGun, Bow.
            //Так как эти классы унаследованы от класса Weapon, то мы можем их помещать в массив типа Weapon
            //Хоть мы не можем создавать экземпляр абстрактного класса Weapon, мы можем использовать его в качестве ссылки,
            //как тип данных, для того чтобы хранить в нем его наследников
            Weapon[] inventory = { new Gun(), new LaserGun(), new Bow() };

            foreach (var item in inventory)
            {
                player.CheckInfo(item);
                player.Fire(item);
                Console.WriteLine();
            }
            player.CheckInfo(new Box());
        }
    }
}
