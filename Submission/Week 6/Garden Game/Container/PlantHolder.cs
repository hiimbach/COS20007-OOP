using System;
using System.Collections.Generic;
using System.Text;

namespace Garden_Game
{
    class PlantHolder
    {
        Seed _seed;
        int _days_without_water;
        int _days_remaining;
        double _price;
        bool _seeded;
        bool _alive;
        double _water_today;
        double _holder_price;
        // Bridge Design Patter
        WaterDemand _seed_type;
        string _name;


        public PlantHolder(string name, double holder_price)
        {
            _days_without_water = 0;
            _days_remaining = 0;
            _seeded = false;
            _holder_price = holder_price;
            _name = name;
        }
        public void PHRecover(Seed seed, int days_remain, int days_without_water, double water_today)
        {
            this.AddSeed(seed);
            _days_without_water = days_without_water;
            _days_remaining = days_remain;
            _water_today = water_today;
        }

        public void AddSeed(Seed seed)
        {
            if (Seeded == false)
            {
                _seed = seed;
                _seeded = true;

                _days_remaining = _seed.DaysToGrow;
                _price = 0;
                _alive = true;
                _water_today = 0;
                if (_seed.MilliliterWaterPerDay == 0)
                {
                    _seed_type = WaterDemand.DontNeedWater;
                }
                else
                {
                    _seed_type = WaterDemand.NeedWater;
                }

            }
            else
            {
                Console.WriteLine("This plot has been seeded.");
            }

        }

        //Template Method Design Pattern    
        public void OneDayPass()
        {
            if (_seeded)
            {
                CheckWatered();
                CheckDone();
                if (_alive && DaysRemaining > 0)
                {
                    _days_remaining -= 1;
                }
                _water_today = 0;
            }

        }

        public virtual void CheckDone()
        {
            if (DaysRemaining == Seed.DaysToGrow)
            {
                _price = Seed.SellPrice;
            }
        }

        internal void CheckWatered()
        {
            if (_seed_type == WaterDemand.DontNeedWater)
            {
                return;
            }
            if (_water_today < Seed.MilliliterWaterPerDay)
            {
                _days_without_water += 1;
            }
            else
            {
                _days_without_water = 0;
            }

            if (_days_without_water == 2)
            {
                Dead();
            }
        }

        internal void Dead()
        {
            _alive = false;
            _price = 0;
        }
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public virtual double HolderPrice
        {
            get { return _holder_price; }
            set { _holder_price = value; }
        }

        public int DaysRemaining
        {
            get { return _days_remaining; }
            set { _days_remaining = value; }

        }

        public virtual string ShortDescription
        {
            get { 
                if (Seeded)
                {
                    if (_alive)
                    {
                        return $"{Name}: {_seed.Name}";
                    }
                    else
                    {
                        return $"{Name}: Dead plant";
                    }
                }
                else
                {
                    return $"{Name}: Empty";
                }
                
            }
                
        }

        public string LongDescription
        {
            get {
                if (Seeded)
                {
                    if (Fully_Growth)
                    {
                        return "Goodjob! This plant is fully-growth. You can sell it in selling state to gain moneyy!";
                    }
                    else
                    {
                        if (_alive)
                        {
                            string statement = $"Name: {Seed.Name}";
                            if (_seed_type == WaterDemand.NeedWater)
                            {
                                statement += $"(water used today: {_water_today}/{Seed.MilliliterWaterPerDay} ml)\n";
                            }
                            else
                            {
                                statement += "(you don't need to water this plant)\n";

                            }
                            return statement + $"Selling Price: {_price}$\n{_days_remaining} days remaining\n{_days_without_water} days without water";
                        }
                        else
                        {
                            Garden.GoToGarden().ResetPlantHolder(this);
                            return "You gain nothing from the laziness, let's plant again!";
                        }
                    }
                    
                }
                else
                {
                    return "Please plant something here";
                }
                
            }
        }
        public Seed Seed
        {
            get { return _seed; }
            set { _seed = value; }
        }
        public bool Seeded
        {
            get { return _seeded; }
        }
        public virtual HolderType HolderType
        {
            get { return HolderType.FlowerPot; }
        }
        public string Name { get => _name; set { _name = value; } }
        public double WaterToday { get => _water_today; set { _water_today = value; }}
        public bool Fully_Growth
        {
            get
            {
                if (DaysRemaining == 0 && Seeded)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public int DaysWithoutWater
        {
            get { return _days_without_water; }
        }
    }

}
