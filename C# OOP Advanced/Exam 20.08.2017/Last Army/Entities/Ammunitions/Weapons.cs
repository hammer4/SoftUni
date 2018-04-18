using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Last_Army
{
    public abstract class Weapons : Ammunitions
    {
        private int caliber;
        private double shootDistance;
        private int bullets;

        protected Weapons(string name, double weight)
            : base(name, weight)
        {
        }

        protected Weapons(string name, double weight, int number, int caliber, double shootDistance, int bullets) 
            : base(name, weight, number)
        {
            this.caliber = caliber;
            this.shootDistance = shootDistance;
            this.Bullets = bullets;
        }

        public int Caliber
        {
            get { return caliber; }
            set { caliber = value; }
        }

        public double ShootDistance
        {
            get { return shootDistance; }
            set { shootDistance = value; }
        }

        public int Bullets
        {
            get { return bullets; }
            set { bullets = value; }
        }
    }
}