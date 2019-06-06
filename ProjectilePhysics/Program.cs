using System;
using RayTracerChallenge.Math;

namespace ProjectilePhysics
{
    class Program
    {
        static void Main(string[] args)
        {
            var projectile = new Projectile(
                Toople.Point(0, 1f, 0),
                Toople.Vector(1f, 1f, 1f).Normalize()*4
            );

            var environment = new Environment(
                Toople.Vector(0, -0.1f, 0),
                Toople.Vector(-0.01f, 0, 0));

            var simulation = new Simulation(environment, projectile);
            var ticks = simulation.Run();
            Console.WriteLine($"IMPACT! in {ticks} ticks"); 
        }
    }

    public class Simulation
    {
        private Environment _environment;
        private Projectile _projectile;

        public Simulation(Environment environment, Projectile projectile)
        {
            _environment = environment;
            _projectile = projectile;
        }

        public int Run()
        {

            var ticks = 0;
            while (_projectile.Position.Y > 0)
            {
                Console.WriteLine($"Tick: {ticks} -- position {_projectile.PrintPosition()}");
                _projectile = Tick(_environment, _projectile);
                ticks++;
            }

            return ticks;
        }
        private static Projectile Tick(Environment env, Projectile p)
        {
            var position = p.Position + p.Velocity;
            var velocity = p.Velocity + env.Gravity + env.Wind;
            return new Projectile(position, velocity);
        }
    }

    public class Projectile
    {
        public Toople Position { get; }
        public Toople Velocity { get; }

        public Projectile(Toople position, Toople velocity)
        {
            Position = position;
            Velocity = velocity;
        }
        public string PrintPosition()
        {
            return $"({Position.X}, {Position.Y}, {Position.Z})";
        }
    }

    public class Environment
    {
        public Toople Gravity { get; }
        public Toople Wind { get; }

        public Environment(Toople gravity, Toople wind)
        {
            Gravity = gravity;
            Wind = wind;
        }
    }
}